using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    float CameraRotateX;

    CinemachineVirtualCamera virtualCamera;
    CinemachineComposer composer;

    public Slider enemyHpbarSlider;

    RaycastHit hit;

    Transform enemy;

    public Transform rayPoint;
    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        composer = virtualCamera.GetCinemachineComponent<CinemachineComposer>();
        if (virtualCamera.LookAt == null)
        {
            virtualCamera.LookAt = FindObjectOfType<Player>().transform;
        }
    }


    void Update()
    {
        if (GameManager.Instance.mainPlayer.playerData.Mystate != PlayerEntity.State.UseUi)
        {
            CameraRotateX += Input.GetAxis("Mouse Y") * 0.05f;
            composer.m_ScreenY = CameraRotateX;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (Physics.SphereCast(rayPoint.position,5f, rayPoint.forward, out hit, 50f))
            {
                if (hit.transform.tag == "Enemy")
                {
                    enemy = hit.transform;
                }

                if (enemy == null)
                    return;

                float distance = Vector3.Distance(rayPoint.position, enemy.position);
                if (distance < 20f)
                {
                    virtualCamera.LookAt = enemy.transform;
                }
            }
        }

        if(enemy != null)
        {
            float distance = Vector3.Distance(rayPoint.position, enemy.position);
            if (distance >= 20f)
            {
                virtualCamera.LookAt = FindObjectOfType<Player>().transform;
            }
        }
    }

}
