using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject LoadingScene;
    public GameObject mainMenu;
    public Slider loadingSlider;
    public void LoadLevelBtn(string levelToLoad)
    {
        mainMenu.SetActive(false);
        LoadingScene.SetActive(true);
        StartCoroutine(LoadScene(levelToLoad));

    }
    IEnumerator LoadScene(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        while (!loadOperation.isDone)
        {
            float progessValue = Mathf.Clamp01(loadOperation.progress/0.9f);
            loadingSlider.value = progessValue;
            yield return null;
        }
    }
}
