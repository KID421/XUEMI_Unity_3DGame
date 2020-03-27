using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
    [Header("載入畫面")]
    public GameObject loadingPanel;
    [Header("載入文字")]
    public Text textLoading;
    [Header("載入圖片")]
    public Image imageLoading;
    [Header("提示文字")]
    public GameObject tip;

    private IEnumerator Loading()
    {
        loadingPanel.SetActive(true);
        AsyncOperation ao = SceneManager.LoadSceneAsync("蓋房子");
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            textLoading.text = (ao.progress / 0.9f * 100).ToString("F0") + " %";
            imageLoading.fillAmount = ao.progress / 0.9f;
            yield return null;

            if (ao.progress >= 0.9f)
            {
                tip.SetActive(true);

                if (Input.anyKey) ao.allowSceneActivation = true;
            }
        }
    }

    public void StartLoading()
    {
        StartCoroutine(Loading());
    }
}
