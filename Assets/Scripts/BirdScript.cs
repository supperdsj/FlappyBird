using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour {
    public static BirdScript instance;
    Rigidbody2D myRigidBody;
    Animator anim;

    float forwardSpeed = 3f, bounceSpeed = 4f;

    public bool didFlap;
    public bool isAlive;

    Button flapButton;

    AudioSource audioSource;
    [SerializeField]
    AudioClip flapClip, pointClip, diedClip;

    public int score;

    void Awake() {
        score = 0;
        audioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (instance == null) {
            instance = this;
        }

        isAlive = true;
        flapButton = GameObject.FindGameObjectWithTag("FlapButton").GetComponent<Button>();
        flapButton.onClick.AddListener(() => FlapTheBird());
        SetCameraOffsetX();
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
                myRigidBody.velocity = new Vector2(0, bounceSpeed);
                audioSource.PlayOneShot(flapClip);
                anim.SetTrigger("Flap");
            }

            if (myRigidBody.velocity.y >= 0) {
                float angle = Mathf.Lerp(0, 90, myRigidBody.velocity.y / 8);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            else {
                float angle = Mathf.Lerp(0, -90, -myRigidBody.velocity.y / 8);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }

    public void FlapTheBird() {
        didFlap = true;
    }

    void SetCameraOffsetX() {
        CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
    }

    public float GetPositionX() {
        return transform.position.x;
    }

    void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == "Ground" || target.gameObject.tag == "Pipe") {
            if (isAlive) {
                isAlive = false;
                anim.SetTrigger("Died");
                audioSource.PlayOneShot(diedClip);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "PipeHolder") {
            score++;
            audioSource.PlayOneShot(pointClip);
        }
    }

}
