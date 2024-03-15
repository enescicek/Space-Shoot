using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject hazard;
    public int spawnCount;
    public float spawnWait;
    public float startSpawn;
    public float waveWait;

    public Text scoreText;
    public int score;

    public Text gameOverText;
    public Text restartText;
    public Text quitText;

    private bool gameOver;
    private bool restart;

    IEnumerator spawnValues() // coroutine kullan�lan metodlar IEnumerator olmal�d�r.
    {
        yield return new WaitForSeconds(startSpawn);
        while (true)
        { 
            
            for (int i=0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 0, 10);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);

                //coroutine
                yield return new WaitForSeconds(spawnWait); // kodu spawnWait kadar bekletecek.
                                                            // Asteroidlerin aynanda olusmas�n� engellemek i�in yazd�k.

                // coroutinler ve methodlar aras�nda 3 temel fark vard�r:
                // 1 - coroutinler IEnumerator d�nd�rmek zorundalar.
                // 2 - coroutinler en az 1 adet yield ifadesi bulunmal�d�r.
                // 3 - coroutinler �a��r�l�rken mutlaka StartCoroutine() methodu ile �a��r�lmal�d�rlar.

            }
            yield return new WaitForSeconds(waveWait);
            if(gameOver == true)
            {
                restartText.text = "Press 'R' for Restart";
                quitText.text = "Press 'Q' for quit";
                restart = true;
                break;
            }
        }

    }

    // score i�lemleri
    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "SCORE : " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER";
        gameOver = true;
    }

    void Start()
    {
        gameOverText.text = "";
        restartText.text = "";
        quitText.text = "";
        gameOver = false;
        restart = false;

        StartCoroutine(spawnValues()); // coroutine ler bu �ekilde �a��r�l�r.
    }

    void Update()
    {
        if(restart == true)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
    }


}
