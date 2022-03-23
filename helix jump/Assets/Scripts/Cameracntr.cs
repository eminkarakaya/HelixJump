using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracntr : MonoBehaviour
{
    public float kameraDurmaYeri;
    rastgeleEngelSpawn rastgeleEngelSpawn;
    public Transform ball;
    void Start()
    {
        rastgeleEngelSpawn = GameObject.FindObjectOfType<rastgeleEngelSpawn>();
        ball = GameObject.Find("Ball").GetComponent<Transform>();
    }
    
    public void CamFollow()
    {
        
        if(ball.transform.position.y < rastgeleEngelSpawn.kameraDurmaYeri)
        {
            transform.position = new Vector3(ball.transform.position.x,ball.transform.position.y+1,-4);
        }
    }

    void Update()
    {
        CamFollow();
    }
}
