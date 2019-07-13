using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeCollecotr : MonoBehaviour {
    GameObject[] pipeHolders;
    float distance = 3f, lastPipesX, pipeMin = -3f, pipeMax = 3f;

    void Awake() {
        float worldHeight = Camera.main.orthographicSize * 2.0f;
        float worldWidth = worldHeight / Screen.height * Screen.width;
        pipeHolders = GameObject.FindGameObjectsWithTag("PipeHolder");

        for (int i = 0; i < pipeHolders.Length; i++) {
            Vector3 temp = pipeHolders[i].transform.position;
            temp.x = worldWidth / 2f + i * distance;
        }

        lastPipesX = pipeHolders[0].transform.position.x;
        for (int i = 0; i < pipeHolders.Length; i++) {
            Vector3 temp = pipeHolders[i].transform.position;
            temp.y = Random.Range(pipeMin, pipeMax);
            pipeHolders[i].transform.position = temp;
            if (lastPipesX < pipeHolders[i].transform.position.x) {
                lastPipesX = pipeHolders[i].transform.position.x;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "PipeHolder") {
            Vector3 temp = target.transform.position;
            temp.x = lastPipesX + distance;
            temp.y = Random.Range(pipeMin, pipeMax);
            target.transform.position = temp;
            lastPipesX = temp.x;
        }
    }
}
