using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroybyContact : MonoBehaviour
{
    public GameObject explotion;
    public GameObject playerexplo;
    public int scorevalue;
    private gamecontroller GC;
    void OnTriggerEnter(Collider other) 
    {
        
        if(other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explotion,transform.position,transform.rotation);

        if(other.tag == "Player")
        {
            Instantiate(playerexplo,other.transform.position,other.transform.rotation);
            GC.GameOver();
        }
        
        //GetComponent<gamecontroller>().AddScore(scorevalue);
        GC.AddScore(scorevalue);  
        Destroy(other.gameObject);
        Destroy(gameObject);

        // void Start() 
        // {
        //     // GetComponent<GameObject
        // }
    }
}
