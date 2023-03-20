//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] float spawnTime = 3f;

    [SerializeField] GameObject scoreObject;
    [SerializeField] GameObject[] RandomPoints;
    [SerializeField] GameObject scoreItem;

    Vector3 randomPointsPosition;

    int index;
    bool isSpawnTime = true;

    void Start()
    {
        
    }
    void Update()
    {
        MakeRandomChoice();
    }

    void MakeRandomChoice()
    {
        if (isSpawnTime == true)
        {
            index = Random.Range(0, RandomPoints.Length);
            Debug.Log(index);
            randomPointsPosition = RandomPoints[index].transform.position;
            SpawnObject();
            StartCoroutine(DelayBeforeSpawn());
        }
    }

    IEnumerator DelayBeforeSpawn()
    {
        isSpawnTime = false;
        yield return new WaitForSeconds(spawnTime);
        isSpawnTime = true;
    }

    void SpawnObject()
    {
        Instantiate(scoreItem, randomPointsPosition, Quaternion.identity);
    }
}
