using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Status : MonoBehaviour
{
    public string BtnName;

    [SerializeField] TextMeshProUGUI StrStat;
    [SerializeField] TextMeshProUGUI AgiStat;
    [SerializeField] TextMeshProUGUI HealthStat;
    [SerializeField] TextMeshProUGUI StatusPoint;
    [SerializeField] TextMeshProUGUI LevelText;

    [SerializeField] TextMeshProUGUI AttackPower;
    [SerializeField] TextMeshProUGUI AttackSpeed;
    [SerializeField] TextMeshProUGUI Health;
    [SerializeField] TextMeshProUGUI Stamina;
    [SerializeField] TextMeshProUGUI MoveSpeed;
    private void Update()
    {
        StrStat.text = GameManager.Instance.mainPlayer.playerData.str.ToString("f0");
        AgiStat.text = GameManager.Instance.mainPlayer.playerData.agi.ToString("f0");
        HealthStat.text = GameManager.Instance.mainPlayer.playerData.Health.ToString("f0");
        StatusPoint.text = GameManager.Instance.mainPlayer.playerData.levelupPoint.ToString("f0");
        LevelText.text = "Lv. " + GameManager.Instance.mainPlayer.playerData.playerLevel;

        AttackPower.text = "" + GameManager.Instance.mainPlayer.playerData.playerAttackForce.ToString("F1");
        AttackSpeed.text = "" + GameManager.Instance.mainPlayer.playerData.playerAttackSpeed.ToString("F1");
        Health.text = "" + GameManager.Instance.mainPlayer.playerData.maxHp;
        Stamina.text = "" + GameManager.Instance.mainPlayer.playerData.maxSta;
        MoveSpeed.text = "" + GameManager.Instance.mainPlayer.playerData.playerMoveSpeed.ToString("F1");
    }
    public void Btn_ChooseYourStat()
    {
        //클릭한 버튼의 이름을 가져옴
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        BtnName = clickObject.name;
        //버튼의 이름을 넣어줌
        GameManager.Instance.mainPlayer.playerData.InitPlayerStat(BtnName);
    }



}
