using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] //serileþtirme iþlemi.Unity ara yüzünden deðerlere ulaþabilmek için yazdýk.
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

    public Boundary boundary; // Boundary class ýndan nesne ürettik.

    public GameObject shot;
    public GameObject shotSpawn;

    void Start()
    {
        physic = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Bolt spawn etme iþlemi.
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            audioPlayer.Play(); // Ateþleme iþleminden hemen sonra ses dosyamýzýn oynatýlmasýný istiyoruz.
        }
        
    }
    private void FixedUpdate()
    {

        // Hareket kontrolleri
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        physic.velocity = movement*speed;



        // Hareket sýnýrlarýnýn belirlenemsi
        // Gemimizin hareket edeceði sýnýrlý bölgeyi belirlerken Mathf.Clamp() methodundan yararlandýk.
        Vector3 position = new Vector3(
            Mathf.Clamp(physic.position.x, boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(physic.position.z, boundary.zMin, boundary.zMax)
            ); 

        physic.position = position;


        //Player Gemisinin sað-sol Eðim Animasyonu
        physic.rotation = Quaternion.Euler(0, 0, physic.velocity.x * tilt);

    }
}
