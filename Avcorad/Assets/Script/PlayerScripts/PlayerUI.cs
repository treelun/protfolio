using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public CharaterData playerData;
    [SerializeField] Slider HpBar;
    [SerializeField] Slider MpBar;
    [SerializeField] Slider StaBar;

    [SerializeField] TextMeshProUGUI TextHpBar;
    [SerializeField] TextMeshProUGUI TextMpBar;
    [SerializeField] TextMeshProUGUI TextStaBar;

    public PlayerMove character;


    float maxHp;
    float startHp;

    float maxMp;
    float startMp;
    
    float maxSta;
    float startSta;


    private void Start()
    {
        maxHp = character.maxHp;
        maxSta = character.maxSta;
    }

    private void Update()
    {
        HpBar.value = playerData.startingHp / maxHp;
        StaBar.value = playerData.startingStamina / maxSta;
        TextHpBar.text = playerData.startingHp.ToString("F0") + "/" + maxHp;
        TextStaBar.text = playerData.startingStamina.ToString("F0") + "/" + maxSta;
    }

}
