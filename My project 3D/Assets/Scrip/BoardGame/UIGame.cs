using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIGame : MonoBehaviour
{
    public GameObject UIStop;
    public GameObject UIWin;
    public Text UITextWin;
    public void displayUIStrop()
    {
        Time.timeScale = 0f;    
        UIStop.SetActive(true);
    }
    public void displayUIWin(string textWin)
    {
        UITextWin.text = textWin;
        Time.timeScale = 0f;
        UIWin.SetActive(true);
    }
    public void TurnOfUIStop()
    {
        Time.timeScale = 1f;
        UIStop.SetActive(false);
    }
    public void RestartButtom()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
