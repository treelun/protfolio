using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Status : MonoBehaviour
{
    public string BtnName;

    [SerializeField] TextMeshProUGUI AttackPower;
    [SerializeField] TextMeshProUGUI AttackSpeed;
    [SerializeField] TextMeshProUGUI Health;
    [SerializeField] TextMeshProUGUI Stamina;
    [SerializeField] TextMeshProUGUI MoveSpeed;
    private void Update()
    {
        AttackPower.text = "" + GameManager.Instance.mainPlayer.playerData.playerAttackForce.ToString("F1");
        AttackSpeed.text = "" + GameManager.Instance.mainPlayer.playerData.playerAttackSpeed.ToString("F1");
        Health.text = "" + GameManager.Instance.mainPlayer.playerData.maxHp;
        Stamina.text = "" + GameManager.Instance.mainPlayer.playerData.maxSta;
        MoveSpeed.text = "" + GameManager.Instance.mainPlayer.playerData.playerMoveSpeed.ToString("F1");
    }
    public void Btn_ChooseYourStat()
    {
        //Ŭ���� ��ư�� �̸��� ������
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        BtnName = clickObject.name;
        //��ư�� �̸��� �־���
        GameManager.Instance.mainPlayer.playerData.InitPlayerStat(BtnName);
    }



}
