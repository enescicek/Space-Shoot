using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater : MonoBehaviour
{
    Rigidbody physic;
    [SerializeField] int speed ;
    void Start()
    {
        physic = GetComponent<Rigidbody>();

        // angularVelocity : a��sal h�z - d�nme i�lemi i�in kullanaca��z.
        // Random.insideUnitSphere : Her obje i�in en ba�ta random bir vector3 de�eri verir.
        //                           Bu sayede her asteroid ayn� �ekilde d�n�yormu� gibi g�z�kmez.
        physic.angularVelocity = Random.insideUnitSphere * speed;
    }
}
