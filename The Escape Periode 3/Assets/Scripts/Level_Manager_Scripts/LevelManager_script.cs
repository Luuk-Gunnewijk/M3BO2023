using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager_script : MonoBehaviour
{
    [Header("ButtonPressedSound")]
    [SerializeField] AudioClip ButtonClip;
    [SerializeField][Range(0f, 1f)] float ButtonVolume = 1f;

    [SerializeField] int LevelDelay = 2;

    bool isLoadLevelDelay = false;
    public void LoadMainMenu()
    {
        if (isLoadLevelDelay == false)
        {
            StartCoroutine(LoadLevelDelay());
        }
        if (isLoadLevelDelay == true)
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }

    public void LoadNextLevel()
    {
        AudioSource.PlayClipAtPoint(ButtonClip, Camera.main.transform.position, ButtonVolume);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        AudioSource.PlayClipAtPoint(ButtonClip, Camera.main.transform.position, ButtonVolume);
        Application.Quit();
        Debug.Log("Quiting game");
    }

    IEnumerator LoadLevelDelay()
    {
        isLoadLevelDelay = false;
        yield return new WaitForSeconds(LevelDelay);
        isLoadLevelDelay = true;
    }
}
