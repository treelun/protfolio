using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NpcTextnameSpace;
using UnityEngine.UI;
using TMPro;

public class NpcText : MonoBehaviour
{
    public List<ElfNpc> elfNpcsText;

    public GameObject NpcTextBackGround;
    public TextMeshProUGUI NpcTextbox;

    int textIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textIndex < elfNpcsText.Count)
                NextText();
            else if (elfNpcsText[textIndex - 1].textState == TextState.No)
            {
                NpcTextBackGround.gameObject.SetActive(false);
                GameManager.Instance.mainPlayer.playerData.Mystate = LivingEntity.State.Move;
            }
        }

    }
    public void ShowText(int _num)
    {
        textIndex = _num;
        NextText();
    }
    public void NextText()
    {
        NpcTextbox.text = elfNpcsText[textIndex].TextString;
        textIndex++;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            transform.LookAt(other.transform);
        }
        
    }
}
