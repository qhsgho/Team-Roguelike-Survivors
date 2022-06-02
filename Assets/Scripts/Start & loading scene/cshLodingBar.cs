using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class cshLodingBar : MonoBehaviour
{
    static string nextScene;
    [SerializeField] Image progressBar;// 진행바로 사용되는 이미지 

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

         AsyncOperation op =  SceneManager.LoadSceneAsync(nextScene); // Async 비동기적호출, 신을 불러오면서 다른 행동 가능
         op.allowSceneActivation = false; // scene 비동기 불러올때 로딩이 끝나면 자동으로 다음 scene으로 넘가는지 설정
                                          // fasle 90퍼센트만 로드 한 후 기다림, true로 변경시 나머지 완료
                                          //false 이유 1.생각보다 scene이 너무 빠를때, 2.로딩화면에서는 scene만 불러오는 것이 아님, 용량이 커지면 따로 에셋 번들을 만들어 로딩
         float timer = 0f;
         while (!op.isDone) //로딩이 다 되지 않을때 반복하면서
         {
             yield return null; // 한 번 반복 될 때마다 유니티엔진에 제어권을 넘김, 안넘기면 반복문이 끝나기 전에는 진행바가 진행이 안됨

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

