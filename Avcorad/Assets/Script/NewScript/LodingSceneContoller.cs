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
        //���� �ε��� �������� �ڵ����� �ҷ��� ���� ��ȯ���� ������
        //false�� �����ϸ� 90%�� �ε��ѵ� ����������
        //�ٽ� allowSceneActivation �� true�� �����ϸ� �׶� ������ �κ��� �ҷ����� ���� ��ȯ����
        //false�� �ϴ� ������ �ϳ��� �ε��� �ʹ������Ǿ� �ε������� ������ ���̳�, ���丮���� ����� ���޵��� ������ ����
        //ū������Ʈ�� ��쿡�� ���¹���� ������ �ҷ����� �Ǵµ� true�� ������� ������ �������ϼ�����, �׷������� �̿���
        //�����ϱ����ؼ� false�� ��
        op.allowSceneActivation = false;

        float timer = 0f;

        while (!op.isDone)
        {
            yield return null;

            //op.progress�� ���൵�� ��Ÿ�� 90%�� �ɶ����� �ε��ٸ� ä����
            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                //90%�� ������ �ε��ٸ� 100%�� 1�ʿ� ���� ä����(�����δ� �ε��� �ȵǾ�����)
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                //���⿡�� �ε��� �� ����
                if (progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
