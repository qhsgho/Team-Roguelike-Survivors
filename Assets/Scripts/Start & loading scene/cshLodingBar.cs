using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class cshLodingBar : MonoBehaviour
{
    static string nextScene;
    [SerializeField] Image progressBar;// ����ٷ� ���Ǵ� �̹��� 

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess() { 
        yield return null; 
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene); 
        op.allowSceneActivation = false; 
        float timer = 0.0f; while (!op.isDone) { 
            yield return null; 
            timer += Time.deltaTime; 
            if (op.progress < 0.9f) { 
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer); 
                if (progressBar.fillAmount >= op.progress) { timer = 0f; } 
            } else { 
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer); 
                if (progressBar.fillAmount == 1.0f) { 
                    op.allowSceneActivation = true; yield break; } 
            } 
        } 
    }

    /*IEnumerator LoadSceneProcess()
     {

         AsyncOperation op =  SceneManager.LoadSceneAsync(nextScene); // Async �񵿱���ȣ��, ���� �ҷ����鼭 �ٸ� �ൿ ����
         op.allowSceneActivation = false; // scene �񵿱� �ҷ��ö� �ε��� ������ �ڵ����� ���� scene���� �Ѱ����� ����
                                          // fasle 90�ۼ�Ʈ�� �ε� �� �� ��ٸ�, true�� ����� ������ �Ϸ�
                                          //false ���� 1.�������� scene�� �ʹ� ������, 2.�ε�ȭ�鿡���� scene�� �ҷ����� ���� �ƴ�, �뷮�� Ŀ���� ���� ���� ������ ����� �ε�
         float timer = 0f;
         while (!op.isDone) //�ε��� �� ���� ������ �ݺ��ϸ鼭
         {
             yield return null; // �� �� �ݺ� �� ������ ����Ƽ������ ������� �ѱ�, �ȳѱ�� �ݺ����� ������ ������ ����ٰ� ������ �ȵ�

             if(op.progress < 0.9f)
             {
                 progressBar.fillAmount = op.progress;
             }
             else
             {
                 timer += Time.unscaledDeltaTime;
                 progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                 if(progressBar.fillAmount >= 1f)
                 {
                     op.allowSceneActivation = true;
                     yield break;
                 }

             }
         }
    }*/
}

