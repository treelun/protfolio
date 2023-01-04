using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtnController : MonoBehaviour
{
    public GameObject soundOption;
    public GameObject btns;
    public void StartBtn()
    {
        LodingSceneContoller.LoadScene("OpeningScene");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void OptionBtn()
    {
        btns.SetActive(false);
        soundOption.SetActive(true);
    }

    public void BackBtn()
    {
        btns.SetActive(true);
        soundOption.SetActive(false);
    }
}
