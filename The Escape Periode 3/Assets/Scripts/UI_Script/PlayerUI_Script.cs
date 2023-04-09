using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI_Script : MonoBehaviour
{
    int maxDash = 1;
    int MinDash = 0;

    public Slider mySlider;
    public Image myHealthimage_01;
    public Image myHealthimage_02;
    public Image myHealthimage_03;
    public TextMeshProUGUI myScore_UI;

    PlayerMovement myPlayerScript;
    PlayerHealth myPlayerHealthScript;
    Score myScoreScript;

    void Start()
    {
        myScoreScript = FindObjectOfType<Score>();
        myPlayerScript = FindObjectOfType<PlayerMovement>();
        myPlayerHealthScript = FindObjectOfType<PlayerHealth>();
        mySlider.value = maxDash;
    }

    void Update()
    {
        CanDashSlider();
        PlayerHealth_UI();
    }

    void PlayerHealth_UI()
    {
        if (myPlayerHealthScript.health <= 2)
        {
            myHealthimage_03.enabled = false;
        }
        if (myPlayerHealthScript.health <= 1)
        {
            myHealthimage_02.enabled = false;
        }
        if (myPlayerHealthScript.health <= 0)
        {
            myHealthimage_01.enabled = false;
        }
    }

    public void AddScoreUI()
    {
        int pointsToAdd = 0;
        myScoreScript.score += pointsToAdd;
        myScore_UI.text = myScoreScript.score.ToString();
    }

    void CanDashSlider()
    {
        if (myPlayerScript.canDash == true)
        {
            mySlider.value = maxDash;
        }
        if (myPlayerScript.canDash == false)
        {
            mySlider.value = MinDash;
        }
    }
}
