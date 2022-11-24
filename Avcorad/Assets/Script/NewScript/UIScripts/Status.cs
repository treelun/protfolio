using UnityEngine;
using UnityEngine.EventSystems;

public class Status : MonoBehaviour
{
    string BtnName;

    public void Btn_ChooseYourStat()
    {
        //클릭한 버튼의 이름을 가져옴
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        BtnName = clickObject.name;
        //버튼의 이름을 넣어줌
        InitPlayerStat(BtnName);
    }

    void InitPlayerStat(string _BtnName)
    {
        //버튼의 이름이 같고 레벨업 포인트가 0보다 크면
        if (_BtnName == "StrBtn" && GameManager.Instance.mainPlayer.playerData.levelupPoint > 0)
        {
            GameManager.Instance.mainPlayer.playerData.levelupPoint--;
            GameManager.Instance.mainPlayer.playerData.str++;
            GameManager.Instance.mainPlayer.playerData.playerAttackForce += GameManager.Instance.mainPlayer.playerData.str * 0.1f;
        }
        else if (_BtnName == "AgiBtn" && GameManager.Instance.mainPlayer.playerData.levelupPoint > 0)
        {
            GameManager.Instance.mainPlayer.playerData.levelupPoint--;
            GameManager.Instance.mainPlayer.playerData.agi++;
            GameManager.Instance.mainPlayer.playerData.playerMoveSpeed += GameManager.Instance.mainPlayer.playerData.agi * 1.1f;
        }
        else if (_BtnName == "HealthBtn" && GameManager.Instance.mainPlayer.playerData.levelupPoint > 0)
        {
            GameManager.Instance.mainPlayer.playerData.levelupPoint--;
            GameManager.Instance.mainPlayer.playerData.Health++;
            GameManager.Instance.mainPlayer.playerData.maxHp += GameManager.Instance.mainPlayer.playerData.Health * 10f;
            GameManager.Instance.mainPlayer.playerData.maxSta += GameManager.Instance.mainPlayer.playerData.Health * 5f;
        }
    }
}
