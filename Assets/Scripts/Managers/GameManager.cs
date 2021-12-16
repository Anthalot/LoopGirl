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
    public Slider gameVolume;
    public bool canEnd;

    public bool isCanEnd()
    {
        return this.canEnd;
    }

    public void setCanEnd(bool canEnd)
    {
        this.canEnd = canEnd;
    }

    int enemies;
    void Start()
    {
        currentTime = startTime;
    
        canEnd = false;
        enemies = FindObjectsOfType<EnemyAI>().Length;
        if(enemies == 0) SetGoal();
        if(PlayerPrefs.HasKey("Volume")) AudioListener.volume = PlayerPrefs.GetFloat("Volume");
    }

    void FixedUpdate()
    {
        if(gameVolume != null) AudioListener.volume = gameVolume.value;

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
        PlayerPrefs.SetFloat("Volume", AudioListener.volume);
        PlayerPrefs.Save();
        if(canEnd) endFade.SetActive(true);
    }
}
