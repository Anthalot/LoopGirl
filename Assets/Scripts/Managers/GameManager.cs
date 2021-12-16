using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public int startTime;
    public Text textTimer;
    float currentTime;
    public GameObject goal;
    public GameObject endFade;
    public Color activeGoalColor;
    bool canEnd;
    int enemies;
    void Start()
    {
        currentTime = startTime;
    
        canEnd = false;
        enemies = FindObjectsOfType<EnemyAI>().Length;
        if(enemies == 0) SetGoal();
    
    }

    void FixedUpdate()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime = 0f;
            playerController.Return();
        }

        textTimer.text = "" + (int)currentTime;
    }

    public void RestartTimer()
    {
        currentTime = startTime;
    }

    public void UpdateEnemies()
    {
        enemies--;
        if(enemies == 0) SetGoal();
    }

    void SetGoal()
    {
        goal.GetComponent<SpriteRenderer>().color = activeGoalColor;
        canEnd = true;
    }

    public void NextLevel()
    {
        if(canEnd) endFade.SetActive(true);
    }
}
