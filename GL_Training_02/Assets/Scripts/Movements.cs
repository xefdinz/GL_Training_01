using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movements : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count;
    public Text counttext;
    public Text wintext;
    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        wintext.text = "";
    }
    void FixedUpdate()
    {
    float moveH = Input.GetAxis("Horizontal");
    float moveV = Input.GetAxis("Vertical");
    Vector3 move = new Vector3 (moveH,0.0f,moveV);
    rb.AddForce(move*speed);
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count+1;
            SetCountText();
        }        
    }
    void SetCountText()
    {
        counttext.text = "Count :"+ count.ToString();
        if(count>=16)
        {
            wintext.text="You Win!!!";
        }
    }
}
