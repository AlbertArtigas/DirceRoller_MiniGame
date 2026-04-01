using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public List<Mission> Missions = new List<Mission>();
    public Transform missionsPanel;
    public GameObject missionPanelObj;

    void Start()
    {
        StartGame();
    }
    public void resetGame()
    {
        for(int i = 0; i < missionsPanel.childCount; i++)
        {
            Destroy(missionsPanel.GetChild(i).gameObject);
        }
        StartGame();
    }

    void StartGame()
    {
        GameObject mission = Instantiate(missionPanelObj, missionsPanel);
        mission.GetComponent<MissionDropPanel>().mission = Missions[Random.Range(0, Missions.Count)];
    }

    public void NextMission()
    {
        //TODO: Make a mission progession
        //Reset game only to have a mission to play meanwhile its not implemented
        resetGame();
    }

}
