using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    private float Ghost_speed = 6f;
    private float distance_for_player;
    private float aggro_range = 15f;
    private Transform player_position;
    // Start is called before the first frame update
    void Start()
    {
        player_position = GameObject.Find("Sans").transform;
    }

    // Update is called once per frame
    void Update()
    {
       distance_for_player = Vector3.Distance(transform.position, player_position.position);
        if (distance_for_player < aggro_range)
        {
            transform.LookAt(player_position);
            transform.Translate(Vector3.forward * Time.deltaTime * Ghost_speed);


        }

    }
    
 
}
