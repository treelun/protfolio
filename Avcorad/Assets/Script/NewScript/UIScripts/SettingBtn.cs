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
        //����ȭ������ �̵�
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
