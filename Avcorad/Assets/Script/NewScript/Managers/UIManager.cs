using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else if (transform.parent != null && transform.root != null)
        {
            DontDestroyOnLoad(this.transform.root.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    public PopupUI _inventoryPopup;
    public PopupUI _skillPopUp;
    public PopupUI _characterInfoPopup;
    public PopupUI _pausePopup;

    //�ν�����â���� Ű�ڵ忡 �ִ� �ڵ尪���� �����ͼ� ������ ���� �����Ҽ�����
    [Space]
    public KeyCode _escapeKey = KeyCode.Escape;
    public KeyCode _inventoryKey = KeyCode.I;
    public KeyCode _skillKey = KeyCode.K;
    public KeyCode _charInfoKey = KeyCode.C;

    /// <summary> �ǽð� �˾� ���� ��ũ�� ����Ʈ </summary>
    private LinkedList<PopupUI> _activePopupLlist;

    /// <summary> ��ü �˾� ��� </summary>
    private List<PopupUI> _allPopupList;
    private void Start()
    {
        _activePopupLlist = new LinkedList<PopupUI>();
        Init();
        InitCloseAll();
    }

    private void Update()
    {
        ToggleKeyDownAction(_inventoryKey, _inventoryPopup);
        ToggleKeyDownAction(_skillKey, _skillPopUp);
        ToggleKeyDownAction(_charInfoKey, _characterInfoPopup);
        ToggleKeyDownAction(_escapeKey, _pausePopup);
        if (Input.GetKeyDown(_escapeKey))
        {
            Time.timeScale = 0;
        }
    }

    void Init()
    {
        //����Ʈ �ʱ�ȭ
        _allPopupList = new List<PopupUI>()
        {
            _inventoryPopup, _skillPopUp,_characterInfoPopup,_pausePopup
        };

        //��� �˾��� �̺�Ʈ ���
        foreach (var Popup in _allPopupList)
        {
            //��� ��Ŀ�� �̺�Ʈ
            //���ٽ� ()�� �Ű����� {}�� ������ ��� Onfocus�� action��
            Popup.OnFocus += () =>
            {
                //�����ִ��� �����
                _activePopupLlist.Remove(Popup);
                //ù��°�� �ű��
                _activePopupLlist.AddFirst(Popup);
                //������
                RefreshAllPopupDepth();

            };
            //�ݱ��ư �̺�Ʈ
            //AddListener��ư�� event�� �Ҵ��ϴ� �޼���
            //�Ű����������ٸ� �ٷ� ����� �޼����̸��� �Ѱ��ָ������
            //���⼭�� �ݾƾ� �� â�� �Ű������� �ʿ��ϹǷ� ���ٽ� ���
            Popup._closeButton.onClick.AddListener(() => ClosePopup(Popup));
        }
    }
    private void InitCloseAll()
    {
        foreach (var Popup in _allPopupList)
        {
            ClosePopup(Popup);
        }
    }

    /// <summary> ����Ű �Է¿� ���� �˾� ���ų� �ݱ� </summary>
    private void ToggleKeyDownAction(in KeyCode key, PopupUI Popup)
    {
        if (Input.GetKeyDown(key))
            ToggleOpenClosePopup(Popup);
    }

    /// <summary> �˾��� ����(opened/closed)�� ���� ���ų� �ݱ� </summary>
    private void ToggleOpenClosePopup(PopupUI Popup)
    {
        if (!Popup.gameObject.activeSelf) OpenPopup(Popup);
        else ClosePopup(Popup);
    }

    /// <summary> �˾��� ���� ��ũ�帮��Ʈ�� ��ܿ� �߰� </summary>
    private void OpenPopup(PopupUI Popup)
    {
        GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.UseUi;
        _activePopupLlist.AddFirst(Popup);
        Popup.gameObject.SetActive(true);
        RefreshAllPopupDepth();
        if (GameManager.Instance.mainPlayer.playerData.Mystate == PlayerEntity.State.Attack)
        {
            GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.UseUi;
        }
        
    }

    /// <summary> �˾��� �ݰ� ��ũ�帮��Ʈ���� ���� </summary>
    private void ClosePopup(PopupUI Popup)
    {
        GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.Move;
        _activePopupLlist.Remove(Popup);
        Popup.gameObject.SetActive(false);
        RefreshAllPopupDepth();
    }

    /// <summary> ��ũ�帮��Ʈ �� ��� �˾��� �ڽ� ���� ���ġ </summary>
    private void RefreshAllPopupDepth()
    {
        foreach (var Popup in _activePopupLlist)
        {
            //���̾��Ű������ UI������Ʈ�� ������ �ٲپ� ���� ���̰Բ���
            Popup.transform.SetAsFirstSibling();
        }
    }

}
