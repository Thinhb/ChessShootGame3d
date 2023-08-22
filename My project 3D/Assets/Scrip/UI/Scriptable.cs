using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListPlayer", menuName = "Player/ListPlayer")]
public class Scriptable : ScriptableObject
{
    public List<player> players = new List<player>();
}


[System.Serializable]
public class player
{
    public int ID;
    public string Name;
}
