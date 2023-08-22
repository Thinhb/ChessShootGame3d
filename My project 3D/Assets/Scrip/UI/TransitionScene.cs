using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartButtom()
    {
        SceneManager.LoadScene("ScenePlayer");
    }
    public void BackButtom()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
