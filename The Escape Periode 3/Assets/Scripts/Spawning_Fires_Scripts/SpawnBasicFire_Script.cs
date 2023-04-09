//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBasicFire_Script : MonoBehaviour
{
    [SerializeField] float spawningTime = 3f;

    [SerializeField] GameObject[] fireSpawnPoints;
    [SerializeField] GameObject basicFire;

    bool isSpawning = true;

    Vector3 randomFirePosition;

    int index;

    [Header("DestroyFires")]
    int fireIndex;
    int howLongIsDestroyTime;
    int[] destroyTime = new int[] { 35, 60 };

    void Update()
    {
        SpawnRandomPoint();
    }
    void SpawnRandomPoint()
    {
        if (isSpawning == true)
        {
            index = Random.Range(0, fireSpawnPoints.Length);
            //Debug.Log(index);
            randomFirePosition = fireSpawnPoints[index].transform.position;
            SpawnFire();
            StartCoroutine(SpawnDelay());
        }
    }

    //void HasSpawnedAtPosition()
    //{
        
    //}

    IEnumerator SpawnDelay()
    {
        isSpawning = false;
        yield return new WaitForSeconds(spawningTime);
        isSpawning = true;
    }

    void SpawnFire()
    {
        fireIndex = Random.Range(0,destroyTime.Length);
        howLongIsDestroyTime = destroyTime[fireIndex];
        var fire = Instantiate(basicFire, randomFirePosition, Quaternion.identity);
        Destroy(fire, howLongIsDestroyTime);
    }
}
