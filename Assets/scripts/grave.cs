using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grave : MonoBehaviour
{
    public GameObject ghost;
    public GameObject[] graves;
    // Start is called before the first frame update
    void Start()
    {
        graves = GameObject.FindGameObjectsWithTag("grave");
        for (int i = 0; i < graves.Length; i++)
        {
            

        }



    }

   
}
