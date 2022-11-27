using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelect;

    public GameObject LevelTwoButt;
    public GameObject levelThreeButt;

    public Image blackScreen;

    public int temp;

    bool waiting = false;
    private void Start()
    {
        Time.timeScale = 1;
        temp = PlayerPrefs.GetInt("LevelsComplete");
        mainMenu.active = true;
        levelSelect.active = false;
        blackScreen.CrossFadeAlpha(0, .5f, false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && mainMenu.active == true)
        {
            blackScreen.CrossFadeAlpha(1, .5f, false);
            QuitGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && levelSelect.active == true)
        {
            MainScreen();
        }

        if (temp > 1)
        {
            LevelTwoButt.GetComponent<Button>().interactable = true;
        }
        else
        {
            LevelTwoButt.GetComponentInChildren<Button>().interactable = false;
        }
        if (temp > 2)
        {
            levelThreeButt.GetComponent<Button>().interactable = true;
        }
        else
        {
            levelThreeButt.GetComponent<Button>().interactable = false;
        }
    }
    public void LevelSelect()
    {
        mainMenu.active = false;
        levelSelect.active = true;
    }

    public void MainScreen()
    {
        mainMenu.active = true;
        levelSelect.active = false;
    }

    public void QuitGame()
    {
            Application.Quit();
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        temp = 0;
    }

    public void Level1()
    {
        blackScreen.CrossFadeAlpha(1, .5f, false);
        StartCoroutine(Wait());
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        blackScreen.CrossFadeAlpha(1, .5f, false);
        StartCoroutine(Wait());
        SceneManager.LoadScene(2);
    }

    public void Level3()
    {
        blackScreen.CrossFadeAlpha(1, .5f, false);
        StartCoroutine(Wait());
        SceneManager.LoadScene(3);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }
}
