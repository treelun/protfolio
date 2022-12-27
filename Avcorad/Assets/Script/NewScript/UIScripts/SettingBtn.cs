using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBtn : MonoBehaviour
{
    public void ContinueBtn()
    {
        Time.timeScale = 1f;
        GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.Move;
        gameObject.SetActive(false);
    }

    public void BackMain()
    {
        //메인화면으로 이동
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
