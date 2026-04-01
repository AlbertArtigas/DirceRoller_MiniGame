using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewMission", menuName = "Game/Mission")]
public class Mission : ScriptableObject
{
    public string missionName;
    [TextArea] public string missionText;
    public int diceAmount;
    public List<GameObject> allowedDice;
    public float time;
    public int points;
}

