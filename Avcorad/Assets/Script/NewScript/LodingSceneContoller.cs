using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LodingSceneContoller : MonoBehaviour
{

    static string nextScene;

    [SerializeField]
    Image progressBar;


    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        //씬의 로딩이 끝났을때 자동으로 불러온 씬을 전환할지 설정함
        //false로 설정하면 90%만 로딩한뒤 멈춰있으며
        //다시 allowSceneActivation 을 true로 변경하면 그때 나머지 부분을 불러오며 씬을 전환해줌
        //false로 하는 이유중 하나는 로딩이 너무빨리되어 로딩씬에서 보여줄 팁이나, 스토리등이 제대로 전달되지 않을수 있음
        //큰프로젝트일 경우에는 에셋번들로 나눠서 불러오게 되는데 true로 했을경우 에셋이 꺠져보일수있음, 그런현상을 미연에
        //방지하기위해서 false로 둠
        op.allowSceneActivation = false;

        float timer = 0f;

        while (!op.isDone)
        {
            yield return null;

            //op.progress는 진행도를 나타냄 90%가 될때까지 로딩바를 채워줌
            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                //90%만 차있을 로딩바를 100%로 1초에 걸쳐 채워줌(실제로는 로딩이 안되어있음)
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                //여기에서 로딩을 다 해줌
                if (progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
