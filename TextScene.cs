using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TextScene : MonoBehaviour
{
    public float _textVal = 0;

    public Text pressSpace;
    public Text textOne;
    public Text textTwo;
    public Text textThree;
    public Text empty;

    private void Start()
    {
        _textVal = 0;
        textTwo.CrossFadeAlpha(0, 0, false);
        textThree.CrossFadeAlpha(0, 0, false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _textVal += 1;
        }

        if(_textVal == 1)
        {
            StartCoroutine(Fade(textOne, _textVal, textTwo));
        }
        else if(_textVal == 2)
        {
            StartCoroutine(Fade(textTwo, _textVal, textThree));
        }
        else if(_textVal == 3)
        {
            StartCoroutine(Fade(textThree, _textVal, empty));
        }
    }

    IEnumerator Fade(Text subjectOne, float cycle, Text subjectTwo)
    {
        subjectOne.CrossFadeAlpha(0, .4f, false);
        yield return new WaitForSeconds(1);
        subjectTwo.CrossFadeAlpha(1, .4f, false);
        if(cycle == 3)
        {
            LoadNextScene();
        }
        StopCoroutine(Fade(subjectOne, cycle, subjectTwo));
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
