
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText Score_text;
    public GUIText Restart_text;
    public GUIText Gameover_text;

    private bool gameOver;
    private bool restart;
    private int Score;

    void Start ()
    {
        gameOver = false;
        restart = false;
        Restart_text.text = "";
        Gameover_text.text = "";
        Score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves ());
    }

    private void Update()
    {
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("testScene",LoadSceneMode.Single);
                
            }
        }
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds (waveWait);

            if(gameOver)
            {
                /*Restart_text.text = "Press 'R' for Restart";
                restart = true;
                break;*/
                SceneManager.LoadScene(0);

            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        Score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        Score_text.text = "Score:" + Score;
    }

    public void GameOver ()
    {
        Gameover_text.text = "Game Over!";
        gameOver = true;
    }
}