﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour {
    GameObject[] backgrounds;
    GameObject[] grounds;
    float lastBGX, lastGroundX;

    void Awake() {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        grounds= GameObject.FindGameObjectsWithTag("Ground");
        lastBGX = backgrounds[0].transform.position.x;
        lastGroundX = grounds[0].transform.position.x;
        for (int i = 1; i < backgrounds.Length; i++) {
            if (lastBGX < backgrounds[i].transform.position.x) {
                lastBGX = backgrounds[i].transform.position.x;
            }
        }
        for (int i = 1; i < grounds.Length; i++) {
            if (lastGroundX < grounds[i].transform.position.x) {
                lastGroundX = grounds[i].transform.position.x;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Background") {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D) target).size.x;
            temp.x = lastBGX + width;
            target.transform.position = temp;
            lastBGX = temp.x;
        }else if (target.tag == "Ground") {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D) target).size.x;
            temp.x = lastGroundX + width;
            target.transform.position = temp;
            lastGroundX = temp.x;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
