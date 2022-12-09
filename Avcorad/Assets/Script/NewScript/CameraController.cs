using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraController : MonoBehaviour
{
    float CameraRotateX;

    float rotateMaximum = 1.5f;
    float rotateMinimum = -0.5f;

    CinemachineVirtualCamera virtualCamera;
    CinemachineComposer composer;
    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        composer = virtualCamera.GetCinemachineComponent<CinemachineComposer>();
    }


    void Update()
    {
        if (virtualCamera.LookAt == null)
        {
            virtualCamera.LookAt = FindObjectOfType<Player>().transform;
        }
        else if (virtualCamera.LookAt == FindObjectOfType<Player>().transform)
        {
            composer.m_TrackedObjectOffset.x = 0.5f;
            composer.m_TrackedObjectOffset.y = 1f;
        }
        if (GameManager.Instance.mainPlayer.playerData.Mystate != LivingEntity.State.UseUi)
        {
            CameraRotateX += Input.GetAxis("Mouse Y") * 0.05f;
            composer.m_ScreenY = CameraRotateX;
        }
    }
}
