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

    IEnumerator spawnValues() // coroutine kullanýlan metodlar IEnumerator olmalýdýr.
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
                                                            // Asteroidlerin aynanda olusmasýný engellemek için yazdýk.

                // coroutinler ve methodlar arasýnda 3 temel fark vardýr:
                // 1 - coroutinler IEnumerator döndürmek zorundalar.
                // 2 - coroutinler en az 1 adet yield ifadesi bulunmalýdýr.
                // 3 - coroutinler çaðýrýlýrken mutlaka StartCoroutine() methodu ile çaðýrýlmalýdýrlar.

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

    // score iþlemleri
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

        StartCoroutine(spawnValues()); // coroutine ler bu þekilde çaðýrýlýr.
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
