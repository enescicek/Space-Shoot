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

        // angularVelocity : açýsal hýz - dönme iþlemi için kullanacaðýz.
        // Random.insideUnitSphere : Her obje için en baþta random bir vector3 deðeri verir.
        //                           Bu sayede her asteroid ayný þekilde dönüyormuþ gibi gözükmez.
        physic.angularVelocity = Random.insideUnitSphere * speed;
    }
}
