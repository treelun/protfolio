using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField] Slider HpBar;
    [SerializeField] Slider StaBar;
    [SerializeField] Slider ExpBar;

    [SerializeField] TextMeshProUGUI TextHpBar;
    [SerializeField] TextMeshProUGUI TextStaBar;
    [SerializeField] TextMeshProUGUI TextLevel;
    [SerializeField] TextMeshProUGUI Coin;

    // Update is called once per frame
    void Update()
    {
        HpBar.value = GameManager.Instance.mainPlayer.playerData.Hp / GameManager.Instance.mainPlayer.playerData.maxHp;
        StaBar.value = GameManager.Instance.mainPlayer.playerData.Sta / GameManager.Instance.mainPlayer.playerData.maxSta;
        ExpBar.value = GameManager.Instance.mainPlayer.playerData.currentExp / GameManager.Instance.mainPlayer.playerData.requiredExp;
        TextHpBar.text = GameManager.Instance.mainPlayer.playerData.Hp.ToString("F0") + "/" + GameManager.Instance.mainPlayer.playerData.maxHp;
        TextStaBar.text = GameManager.Instance.mainPlayer.playerData.Sta.ToString("F0") + "/" + GameManager.Instance.mainPlayer.playerData.maxSta;
        TextLevel.text = "Lv. " + GameManager.Instance.mainPlayer.playerData.playerLevel;
        Coin.text = "Coin : " + GameManager.Instance.inventory.coin;
    }
}
