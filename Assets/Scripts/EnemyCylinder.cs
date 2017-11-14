using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCylinder : MonoBehaviour {

    //public permette modifiche al programmatore dall ide unity
    public float speed = 8;            // variabile per applicare velocità alla fisica
    public Transform target;  // variabile per far inseguire al enemy il target puntato

    // Use this for initialization call one a time
    void Start()
    {
        target = GameObject.FindWithTag("Giocatore").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
