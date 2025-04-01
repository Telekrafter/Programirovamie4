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
    private float vertical;
    private bool isMove;
    public GameObject Game_Over_Screen;
    public GameObject Game_Win_Screen;
    public int Health = 100;
    public Health_bar health_bar;
    private float vertical_mouse = 0f;
    private float horizontal_mouse = 0f;
    public AudioSource ghost_sound_die;
    public AudioSource coin_sound;
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
        vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime * skeleton_speed);
            isMove = true;
            skelet_idet_bejit.Play("Walk");
        }
        else
        {
            skelet_idet_bejit.Play("Idle");
        }

        if (Input.GetKey(KeyCode.Space) && ONground)
        {
            ONground = false;
           
            rb.AddForce(new Vector3(0, 1000 ,0), ForceMode.Impulse);
            

        }
        if (Health == 0)
        {
            Game_Over_Screen.SetActive(true);

        }
        vertical_mouse -= Input.GetAxis("Mouse Y") * 2f;
        horizontal_mouse += Input.GetAxis("Mouse X") * 2f;
        transform.eulerAngles = new Vector3(0f, horizontal_mouse, 0f);

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("ground"))
        {
            ONground = true;
            
        }
        if (collision.gameObject.CompareTag("die"))
        {
           Game_Over_Screen.SetActive(true);
        }
        if (collision.gameObject.CompareTag("win"))
        {
            Game_Win_Screen.SetActive(true);
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            coin_sound.Play();
            monet++;
            text_board.text = "Черепов:" + monet.ToString();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("ghost"))
        {
            ghost_sound_die.Play();
            Health -= 20;
            health_bar.set_health(Health);
            
            Destroy(other.gameObject);
            

        }
    }
    
}   
