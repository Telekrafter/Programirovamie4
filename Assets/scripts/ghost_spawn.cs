using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_spawn : MonoBehaviour
{
    public GameObject ghost;
    private int count_spawn1 = 5;
    private int count_spawn2 = 5;
    private int count_spawn3 = 5;
    private int count_spawn4 = 5;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count_spawn1 > 0)
        {
            count_spawn1 -= 1;
            Vector3 position = new Vector3(Random.Range(-184, -167), 155, Random.Range(-347, -352));
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 0), 0);
            Instantiate(ghost, position, rotation);
        }
        if (count_spawn2 > 0)
        {
            count_spawn2 -= 1;
            Vector3 position = new Vector3(Random.Range(121, 120), 138, Random.Range(-206, -175));
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 0), 0);
            Instantiate(ghost, position, rotation);
        }
        if (count_spawn3 > 0)
        {
            count_spawn3 -= 1;
            Vector3 position = new Vector3(Random.Range(121, 120), 138, Random.Range(-206, -175));
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 0), 0);
            Instantiate(ghost, position, rotation);
        }
    }
}
