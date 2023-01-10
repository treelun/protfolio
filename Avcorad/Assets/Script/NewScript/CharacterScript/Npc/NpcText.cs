using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NpcTextnameSpace;
using Cinemachine;
using TMPro;

public class NpcText : MonoBehaviour
{
    public List<ElfNpc> elfNpcsText;

    public GameObject NpcTextBackGround;
    public TextMeshProUGUI NpcTextbox;
    public CinemachineVirtualCamera virtualCamera;
    AudioSource audioSource;
    public AudioSource startAudio;

    public int textIndex = 0;

    private Vector3 targetTransform;

    Animator animator;

    float delta;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > 5f)
        {
            delta = 0f;
            startAudio.Play();
        }

    }
    public void ShowText(int _num)
    {
        textIndex = _num;
        animator.SetTrigger("Talk");
        NextText();
        virtualCamera.LookAt = this.transform;
        audioSource.Play();
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
            targetTransform = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            transform.LookAt(targetTransform);
            if (Input.GetMouseButtonDown(0))
            {
                if (textIndex < elfNpcsText.Count)
                    NextText();
                else if (elfNpcsText[textIndex - 1].textState == TextState.No)
                {
                    NpcTextBackGround.gameObject.SetActive(false);
                    GameManager.Instance.mainPlayer.playerData.Mystate = PlayerEntity.State.Move;
                    Debug.Log("대화종료");
                    animator.SetTrigger("Idle");
                    virtualCamera.LookAt = null;
                }
            }
        }
    }

}
