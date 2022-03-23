using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;
public class rastgeleEngelSpawn : MonoBehaviour
{
    [SerializeField] private int _puan = 0;
    public static Action<int> OnPuanCollected;
    public float kameraDurmaYeri;
    public float speed = 5;
    public int artArdaGecme = 0;
    public List<GameObject> engeller = new List<GameObject>();
    public List<GameObject> pasifEngeller = new List<GameObject>();
    
    public bool carpti;
    //public GameObject engel;
    public GameObject silindir;
    public float engellerArasiMesafe = 9;
    public float jumpPower = 10;
    System.Random random = new System.Random();
    public void EngelOlustur(GameObject gameObject)
    {
        int rnd = random.Next(0,180);
        engellerArasiMesafe += 3;
        gameObject.transform.position = new Vector3(0,-engellerArasiMesafe,0);
        gameObject.transform.rotation = Quaternion.Euler(0,rnd,0);
        gameObject.SetActive(true);
        pasifEngeller.Remove(gameObject);
    }
    public void EngelSil(GameObject other)
    {
        artArdaGecme++;
        pasifEngeller.Add(other);
        other.SetActive(false);
        
    }    
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "hazir")
        {
            int rnd = random.Next(0,pasifEngeller.Count);
            EngelOlustur(pasifEngeller[rnd]);
            EngelSil(other.gameObject);
            _puan++;
            OnPuanCollected?.Invoke(_puan);
        }
        else if(other.gameObject.tag == "kirmizi")
        {
            if(!DusmeBoostCheck())
            {
                SceneManager.LoadScene("SampleScene");
            }
            else
            {
                other.gameObject.transform.parent.gameObject.SetActive(false);
                carpti = true;
                artArdaGecme =0;   
                StartCoroutine(Yukari());
            }
        }
        else if(other.gameObject.tag == "Siyah")
        {
            kameraDurmaYeri = other.gameObject.transform.position.y;
            carpti = true;
            
            StartCoroutine(Yukari());
            if(DusmeBoostCheck())
            {
                other.gameObject.transform.parent.gameObject.SetActive(false);
                artArdaGecme =0;
            }
            // GetComponent<Rigidbody>().AddForce(Vector3.up*jumpPower*Time.deltaTime*50);
        }
        

    }
    void Start()
    {
        
    }
    public bool DusmeBoostCheck()
    {
        if(artArdaGecme >= 3)
        {
            return true;
        }
        return false;
    }

    IEnumerator Yukari()
    {
        yield return new WaitForSeconds(0.3f);
        carpti = false;
    }
    public void Movement()
    {
        if(!carpti)
        {
            if(DusmeBoostCheck())
            {
                speed = 7;
                GetComponent<MeshRenderer>().material.color = Color.red;
            }    
            else
            {
                speed = 5;
                GetComponent<MeshRenderer>().material.color = Color.green;
                
            }
            transform.Translate(Vector3.down*Time.deltaTime*speed);
        }
        else
        {
            artArdaGecme = 0;
            transform.Translate(-Vector3.down*Time.deltaTime*speed);
        }   
    }

    void Update()
    {
        Movement();
    }
}
