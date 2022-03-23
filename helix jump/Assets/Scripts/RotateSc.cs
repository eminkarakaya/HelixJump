using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSc : MonoBehaviour
{
    GameObject [] array = new GameObject [5];
    rastgeleEngelSpawn rastgeleEngelSpawn;
    float mouseX;
    public void RotateScene()
    {
      if(Input.GetMouseButton(0))
      {
        mouseX = Input.GetAxis("Mouse X");
      }
      if(Input.GetMouseButtonUp(0))
      {
        mouseX = 0;
      }
      array = GameObject.FindGameObjectsWithTag("hazir");
      for (int i = 0; i < array.Length; i++)
      {
        array[i].transform.Rotate(0,-mouseX*7,0);
      }
      
    }
    void Start()
    {

    }

    void Update()
    {
        RotateScene();
    }
}
