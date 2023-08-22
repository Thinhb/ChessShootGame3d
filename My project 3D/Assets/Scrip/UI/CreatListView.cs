using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatListView : MonoBehaviour
{
    // Start is called before the first frame update
    public Scriptable scriptable;
    public GameObject player;
    void Start()
    {
        //GameObject player = transform .GetChild(0).gameObject;
        GameObject p;
        for(int i = 0; i < scriptable.players.Count; i++)
        {
            p= Instantiate(player,transform);
            p.transform.GetChild(2).GetComponent<Text>().text = scriptable.players[i].ID.ToString();
            p.transform.GetChild(3).GetComponent<Text>().text = scriptable.players[i].Name.ToString();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
