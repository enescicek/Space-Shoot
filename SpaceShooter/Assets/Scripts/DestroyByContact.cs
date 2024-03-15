using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject asteroidExplosion;
    public GameObject playerExplosion;

    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>(); // script �zerinden gameobjeye eri�me i�lemi
    }

    void OnTriggerEnter(Collider other)
    {
        // Boundary nin collider � ve asteroid i� i�e oldugundan oyun ba�lar ba�lamaz asteroid yok oluyordu.
        // Boundary e tag ekleyerek bu durumu ��zd�k. 
        if (other.gameObject.tag == "Boundary")
        {
            return;
        }

        // �arpan �ey geminin kendisiyse geminin patlama effekti g�sterilsin.
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        
        Instantiate(asteroidExplosion, transform.position, transform.rotation); // Asteroid vuruldugunda patla effecti.
        
        Destroy(other.gameObject); // Lazer asteroide �arp�nca lazer yok olacak.
        Destroy(gameObject); // Lazer asteroide �arp�nca asteroid yok olacak.
        gameController.UpdateScore();
    }
}
