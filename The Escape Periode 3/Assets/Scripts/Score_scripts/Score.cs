//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] float spawnTime = 3f;

    [SerializeField] GameObject scoreObject;
    [SerializeField] GameObject[] RandomPoints;
    [SerializeField] GameObject scoreItem;

    PlayerUI_Script myPlayerUI_Script;

    public int score = 0;
    public int highScore;

    Vector3 randomPointsPosition;

    int index;
    bool isSpawnTime = true;

    public TextMeshProUGUI highScoreText;
    public Image myImage;
    public TextMeshProUGUI myText;

    void Start()
    {
        myPlayerUI_Script = FindObjectOfType<PlayerUI_Script>();
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

    }

    void Update()
    {
        MakeRandomChoice();
        HighScore();
        ResetHighScore();
    }

    public void AddToScore()
    {
        score = score + 1;
        myPlayerUI_Script.AddScoreUI();
        //Debug.Log(score);
    }

    void MakeRandomChoice()
    {
        if (isSpawnTime == true)
        {
            index = Random.Range(0, RandomPoints.Length);
            //Debug.Log(index);
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

    void HighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        }
    }

    public void ResetHighScore()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerPrefs.DeleteKey("HighScore");
            highScoreText.text = 0000.ToString();
            Destroy(myImage);
            Destroy(myText);
        }
    }
}
