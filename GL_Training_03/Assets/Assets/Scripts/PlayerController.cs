using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary 
{
     public float xMin,xMax,zMin,zMax;
}
public class PlayerController : MonoBehaviour
{
    public float speed;
    public Boundary boundary;
    public float tilt;
    public GameObject shot;
    public Transform shotspawn;
    public float firerate;
    private float nextfire;
    void Update() 
    {
        if(Input.GetButton("Fire1") && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            Instantiate(shot,shotspawn.position,shotspawn.rotation);
            GetComponent<AudioSource>().Play();
        }        
    }
    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        Vector3 move = new Vector3 (moveH,0.0f,moveV);
        GetComponent<Rigidbody>().velocity = move*speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x,boundary.xMin,boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z,boundary.zMin,boundary.zMax)
        );
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f,0.0f,GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}
