using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlotSelectBtn : MonoBehaviour
{
    public Button btn1, btn2, btn3, btn4, btn5;

    int setint;
    // Start is called before the first frame update
    void Start()
    {
        btn1.onClick.AddListener(() => Setint(0));
    }

    void Setint(int _num)
    {
        setint = _num;
    }
}
