using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {

    public static BirdScript instance;
    Rigidbody2D myRigidBody;
    Animator anim;

    float forwardSpeed=3f, bounceSpeed=4f;

    bool didFlap;
    bool isAlive;
    void Awake() {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (instance == null) {
            instance = this;
        }

        isAlive = true;
    }

    void FixedUpdate() {
        if (isAlive) {
            Vector3 temp = transform.position;
            temp.x += forwardSpeed * Time.deltaTime;
            print(temp.x);
            print(forwardSpeed);
            print(Time.deltaTime);
            transform.position = temp;
            if (didFlap) {
                didFlap = false;
                myRigidBody.velocity=new Vector2(0,bounceSpeed);
                anim.SetTrigger("Flap");
            }
        }
    }

    public void FlapTheBird() {
        didFlap = true;
    }
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
