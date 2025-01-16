using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class sleket_move : MonoBehaviour
{
    private int monet;
    public TextMeshProUGUI text_board;
    private int skeleton_speed = 5;
    private Animator skelet_idet_bejit;
    Rigidbody rb;
    private bool ONground;
    private float horizontal;
    public GameObject Game_Over_Screen;
    // Start is called before the first frame update
    void Start()
    {
        monet = 0;

        text_board.text = "Черепов:" + monet.ToString();
        skelet_idet_bejit = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        ONground = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * skeleton_speed);
            skelet_idet_bejit.Play("Walk");

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * skeleton_speed);
            skelet_idet_bejit.Play("Walk");

        }


        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * skeleton_speed);
            skelet_idet_bejit.Play("Walk");

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * skeleton_speed);
            skelet_idet_bejit.Play("Walk");

        }
        else
        {
            skelet_idet_bejit.Play("Idle");

        }   
        if (Input.GetKey(KeyCode.Space) && ONground)
        {
            ONground = false;
            Debug.Log("space");
            rb.AddForce(new Vector3(0, 1000 ,0), ForceMode.Impulse);
            

        }
        transform.Rotate(Vector3.up * Time.deltaTime * skeleton_speed * horizontal);

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("ground"))
        {
            ONground = true;
            Debug.Log("spaceddd");
        }
        if (collision.gameObject.CompareTag("die"))
        {
           Game_Over_Screen.SetActive(true);


        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Debug.Log(monet);
            monet++;
            text_board.text = "Черепов:" + monet.ToString();
            Destroy(other.gameObject);
        }

    }
    
}   
