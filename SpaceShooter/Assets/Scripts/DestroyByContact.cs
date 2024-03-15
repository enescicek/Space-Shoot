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
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>(); // script üzerinden gameobjeye eriþme iþlemi
    }

    void OnTriggerEnter(Collider other)
    {
        // Boundary nin collider ý ve asteroid iç içe oldugundan oyun baþlar baþlamaz asteroid yok oluyordu.
        // Boundary e tag ekleyerek bu durumu çözdük. 
        if (other.gameObject.tag == "Boundary")
        {
            return;
        }

        // Çarpan þey geminin kendisiyse geminin patlama effekti gösterilsin.
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        
        Instantiate(asteroidExplosion, transform.position, transform.rotation); // Asteroid vuruldugunda patla effecti.
        
        Destroy(other.gameObject); // Lazer asteroide çarpýnca lazer yok olacak.
        Destroy(gameObject); // Lazer asteroide çarpýnca asteroid yok olacak.
        gameController.UpdateScore();
    }
}
