using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGame : MonoBehaviour
{
    public Transform positionChess1;
    public Transform positionChess2;
    public Transform positionUIScore1;
    public Transform positionUIScore2;
    public ParticleSystem[] particlesEffect;
    public int score = 0;
    public GameObject chess;
    public bool checkAwake;
    UIGame uiGame;
    private void Awake()
    {
        Time.timeScale = 1f;
        checkAwake = false;
        instantiateChessPlayer1();
        instantiateChessPlayer2();
        instanceParticles();
        uiGame=FindObjectOfType<UIGame>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()   
    {
        Score();
    }
    void instantiateChessPlayer1()
    {
        for (int i=0;i<3;i++)
        {
            Instantiate(chess, positionChess1.transform.position+new Vector3(i*1.5f,0f,0f), Quaternion.identity);
        }
        for (int i = 0; i < 2; i++)
        {
            Instantiate(chess, positionChess1.transform.position + new Vector3(0.7f+1.5f * i, 0f, 1f), Quaternion.identity);
        }
    }
    void instantiateChessPlayer2()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(chess, positionChess2.transform.position + new Vector3(i * 1.5f, 0f, 0f), Quaternion.identity);
        }
        for (int i = 0; i < 2; i++)
        {
            Instantiate(chess, positionChess2.transform.position + new Vector3(0.7f + 1.5f * i, 0f, -1f), Quaternion.identity);
        }
    }
    public void Score()
    {
        if (score==5)
        {
            uiGame.displayUIWin("Player 2 win");
        }
        if (score==-5)
        {
            uiGame.displayUIWin("Player 1 win");
        }
    }
    public void instanceParticles()
    {
        for (int i = 0; i < particlesEffect.Length; i++)
        {
            //particlesEffect[i].Play();
          
        }
    }
    public void incrementScorePlayer1()
    {
        if (checkAwake)
        {
            score++;
            int randomUI = Random.RandomRange(0, particlesEffect.Length);
            particlesEffect[randomUI].transform.position = positionUIScore1.transform.position;
            if (particlesEffect[randomUI].gameObject.active == false)
            {
                particlesEffect[randomUI].gameObject.SetActive(true);
            }
            else
            {
                particlesEffect[randomUI].Play();
            }
        }
    }
    public void incrementScorePlayer2()
    {
        if (checkAwake)
        {
            score--;
            int randomUI = Random.RandomRange(0, particlesEffect.Length);
            particlesEffect[randomUI].transform.position = positionUIScore2.transform.position;
            //particlesEffect[randomUI].Play();
            if (particlesEffect[randomUI].gameObject.active == false)
            {
                particlesEffect[randomUI].gameObject.SetActive(true);
            }
            else
            {
                particlesEffect[randomUI].Play();
            }

        }

    }
}
