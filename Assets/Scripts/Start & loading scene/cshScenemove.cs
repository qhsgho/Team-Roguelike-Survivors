using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cshScenemove : MonoBehaviour
{
    public void OnClickStartButton()
    {
        cshLodingBar.LoadScene("FieldScene");
    }

    public void OnClickSettingButton()
    {
        GameObject.Find("Canvas").transform.Find("AudioCanvas").gameObject.SetActive(true);

    }

    public void OnclickExitButton()
    {
        Debug.Log("Quit");
        Application.Quit();

    }
}
