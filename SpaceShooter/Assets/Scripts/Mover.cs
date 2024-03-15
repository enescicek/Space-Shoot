using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    Rigidbody physic;
    [SerializeField] float speed ;

    void Start()
    {
        // Bolt objesine hareket kazandırdık.
        physic = GetComponent<Rigidbody>();
        physic.velocity = transform.forward * speed;
    }

    
}
