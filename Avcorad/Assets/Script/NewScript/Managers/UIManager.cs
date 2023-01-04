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

    //인스펙터창에서 키코드에 있는 코드값들을 가져와서 보여줌 직접 설정할수있음
    [Space]
    public KeyCode _escapeKey = KeyCode.Escape;
    public KeyCode _inventoryKey = KeyCode.I;
    public KeyCode _skillKey = KeyCode.K;
    public KeyCode _charInfoKey = KeyCode.C;

    /// <summary> 실시간 팝업 관리 링크드 리스트 </summary>
    private LinkedList<PopupUI> _activePopupLlist;

    /// <summary> 전체 팝업 목록 </summary>
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
        //리스트 초기화
        _allPopupList = new List<PopupUI>()
        {
            _inventoryPopup, _skillPopUp,_characterInfoPopup,_pausePopup
        };

        //모든 팝업에 이벤트 등록
        foreach (var Popup in _allPopupList)
        {
            //헤더 포커스 이벤트
            //람다식 ()는 매개변수 {}는 실행할 놈들 Onfocus는 action임
            Popup.OnFocus += () =>
            {
                //원래있던걸 지우고
                _activePopupLlist.Remove(Popup);
                //첫번째로 옮기고
                _activePopupLlist.AddFirst(Popup);
                //재정렬
                RefreshAllPopupDepth();

            };
            //닫기버튼 이벤트
            //AddListener버튼에 event를 할당하는 메서드
            //매개변수가없다면 바로 기능할 메서드이름을 넘겨주면되지만
            //여기서는 닫아야 할 창의 매개변수가 필요하므로 람다식 사용
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

    /// <summary> 단축키 입력에 따라 팝업 열거나 닫기 </summary>
    private void ToggleKeyDownAction(in KeyCode key, PopupUI Popup)
    {
        if (Input.GetKeyDown(key))
            ToggleOpenClosePopup(Popup);
    }

    /// <summary> 팝업의 상태(opened/closed)에 따라 열거나 닫기 </summary>
    private void ToggleOpenClosePopup(PopupUI Popup)
    {
        if (!Popup.gameObject.activeSelf) OpenPopup(Popup);
        else ClosePopup(Popup);
    }

    /// <summary> 팝업을 열고 링크드리스트의 상단에 추가 </summary>
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

    /// <summary> 팝업을 닫고 링크드리스트에서 제거 </summary>
    private void ClosePopup(PopupUI Popup)
    {
        GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.Move;
        _activePopupLlist.Remove(Popup);
        Popup.gameObject.SetActive(false);
        RefreshAllPopupDepth();
    }

    /// <summary> 링크드리스트 내 모든 팝업의 자식 순서 재배치 </summary>
    private void RefreshAllPopupDepth()
    {
        foreach (var Popup in _activePopupLlist)
        {
            //하이어라키에서의 UI오브젝트의 순서를 바꾸어 위에 보이게끔함
            Popup.transform.SetAsFirstSibling();
        }
    }

}
