using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamecontroller : MonoBehaviour
{
    public GameObject hazard;
    public GameObject player;
    public Vector3 spawnvalue;
    public int hcount;
    public int score;
    public float spawnwait, startwait, wavewait;
    public Text scoretext;
    public Text retext;
    public Text GOtext;
    public bool GO;
    public bool RE;
    void Start()
    {
        score = 0;
        GO = false;
        RE = false;
        retext.text = "";
        GOtext.text = "";
        UpdateScore();
        StartCoroutine (Spawn_wave());
    }
    void Update() 
    {
        if(RE)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene",LoadSceneMode.Additive);
            }
        }
    }
    IEnumerator  Spawn_wave()
    {
        yield return new WaitForSeconds(startwait);
        while(true)
        {   
            yield return new WaitForSeconds(startwait);
            for(int i=0;i< hcount;i++ )
            {   
                Vector3 spawnpos = new Vector3(Random.Range(-spawnvalue.x,spawnvalue.x),spawnvalue.y,spawnvalue.z);
                Quaternion spawnrot = Quaternion.identity;
                Instantiate(hazard,spawnpos,spawnrot);
                yield return new WaitForSeconds (spawnwait);
            }
            yield return new WaitForSeconds(wavewait);
            if (GO == true)
            {
                retext.text = "Press R for Restart!!!";
                RE = true;
                break;
            }
        }
    }

    public void AddScore(int newscorevalue)
    {
        score += newscorevalue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoretext.text = "Score: "+score;
    }
    public void GameOver()
    {
        scoretext.text = "Game Over";
        GO = true;
    }
}
