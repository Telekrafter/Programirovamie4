using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moneta : MonoBehaviour
{
    private int monet;
    public TextMeshProUGUI text_board;
    // Start is called before the first frame update
    void Start()
    {
        monet = 0;

        text_board.text = "Черепов:" + monet.ToString();
    }

   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(monet);
        monet ++;
        text_board.text = "Черепов:" + monet.ToString();
        Destroy(gameObject);


    }
}
