using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject normalSet;
    public GameObject voidSet;
    public GameObject normalBG;
    public GameObject voidBG;
    public GameObject hurtiesNormal;
    public GameObject hurtiesVoid;

    public GameObject SFX;
    public GameObject pauseMenu;

    public Image blackScreen;

    int curLevel;
    public int levelsComplete;
    public bool canLoadNext;
    public int nextLevel;
    private void Start()
    {
        PlayerPrefs.SetInt("LevelComplete", 0);

        canLoadNext = true;

        Cursor.lockState = CursorLockMode.Locked;

        curLevel = SceneManager.GetActiveScene().buildIndex;
        nextLevel = curLevel + 1;

        if (curLevel > levelsComplete)
        {
            PlayerPrefs.SetInt("LevelsComplete", curLevel);
        }

        levelsComplete = PlayerPrefs.GetInt("LevelsComplete");

        blackScreen.CrossFadeAlpha(0, 2f, false);

        normalSet.active = true;
        voidSet.active = false;

        normalBG.active = true;
        voidBG.active = false;

        hurtiesNormal.active = true;
        hurtiesVoid.active = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Fading());
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.active)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            pauseMenu.active = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.active)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            pauseMenu.active = false;
        }
    }
    void SetScene()
    {
        if (normalSet.active)
        {
            voidSet.active = true;
            normalSet.active = false;

            normalBG.active = false;
            voidBG.active = true;

            hurtiesNormal.active = false;
            hurtiesVoid.active = true;
        }
        else if (voidSet.active)
        {
            normalSet.active = true;
            voidSet.active = false;

            normalBG.active = true;
            voidBG.active = false;

            hurtiesNormal.active = true;
            hurtiesVoid.active = false;
        }
    }

    IEnumerator Fading()
    {
        blackScreen.CrossFadeAlpha(1, .5f, false);
        yield return new WaitForSeconds(.5f);
        SetScene();
        blackScreen.CrossFadeAlpha(0, .5f, false);
        StopCoroutine("Fading");
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        StopCoroutine("Wait");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canLoadNext)
        {
            canLoadNext = false;
            if(curLevel == 5)
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
            }
        }
    }

    public void Restart(bool dead)
    {
        if(dead)
        {
            SFX.GetComponent<Audio>().DeathSound();
            int curLevel = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(curLevel, LoadSceneMode.Single);
        }
    }
    #region PauseMenu
    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        pauseMenu.active = false;
    }
    #endregion
}
