using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] //serile�tirme i�lemi.Unity ara y�z�nden de�erlere ula�abilmek i�in yazd�k.
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{

    AudioSource audioPlayer;

    Rigidbody physic;
    [SerializeField] int speed;
    [SerializeField] int tilt;
    [SerializeField] float nextFire;
    [SerializeField] float fireRate;

    public Boundary boundary; // Boundary class �ndan nesne �rettik.

    public GameObject shot;
    public GameObject shotSpawn;

    void Start()
    {
        physic = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Bolt spawn etme i�lemi.
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            audioPlayer.Play(); // Ate�leme i�leminden hemen sonra ses dosyam�z�n oynat�lmas�n� istiyoruz.
        }
        
    }
    private void FixedUpdate()
    {

        // Hareket kontrolleri
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        physic.velocity = movement*speed;



        // Hareket s�n�rlar�n�n belirlenemsi
        // Gemimizin hareket edece�i s�n�rl� b�lgeyi belirlerken Mathf.Clamp() methodundan yararland�k.
        Vector3 position = new Vector3(
            Mathf.Clamp(physic.position.x, boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(physic.position.z, boundary.zMin, boundary.zMax)
            ); 

        physic.position = position;


        //Player Gemisinin sa�-sol E�im Animasyonu
        physic.rotation = Quaternion.Euler(0, 0, physic.velocity.x * tilt);

    }
}
