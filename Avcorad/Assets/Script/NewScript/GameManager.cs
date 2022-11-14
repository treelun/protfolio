using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
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
        else
        {
            Destroy(this.gameObject);
        }
    }

    Player mainPlayer;

    public GameObject mainCamera;
    public GameObject menuCamera;

    public GameObject enemySpawnPoint;
    public GameObject playerSpawnPoint;

    public GameObject titleMenu;
    public GameObject MouseCon;
    private void Update()
    {
        //I ���������� �������� �κ��丮 / esc�������� pause/ K �������� (��ųâ)
    }
    public void GameStart()
    {
        menuCamera.SetActive(false);
        mainCamera.SetActive(true);

        titleMenu.SetActive(false);

        enemySpawnPoint.SetActive(true);
        playerSpawnPoint.SetActive(true);
        MouseCon.SetActive(true);
    }
    public void GameExit()
    {
        Application.Quit();
    }

    void Init()
    {

    }
}
