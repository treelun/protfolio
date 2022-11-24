using UnityEngine;
using UnityEngine.EventSystems;

public class Status : MonoBehaviour
{
    string BtnName;

    public void Btn_ChooseYourStat()
    {
        //Ŭ���� ��ư�� �̸��� ������
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        BtnName = clickObject.name;
        //��ư�� �̸��� �־���
        InitPlayerStat(BtnName);
    }

    void InitPlayerStat(string _BtnName)
    {
        //��ư�� �̸��� ���� ������ ����Ʈ�� 0���� ũ��
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
