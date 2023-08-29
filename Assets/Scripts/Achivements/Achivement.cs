using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Achivement : MonoBehaviour
{
    
    public Image heartIcon;
    public Image gamePadIcon;
    public Image rocketIcon;
    public Image wCIcon;
    public Image moneyIcon;
    public Image timeIcon;

    private const string AchievementKey1 = "AchievementUnlocked";
    private const string AchievementKey2 = "AchievementUnlocked2";
    private const string AchievementKey3 = "AchievementUnlocked3";
    private const string AchievementKey4 = "AchievementUnlocked4";
    private const string AchievementKey5 = "AchievementUnlocked5";
    private const string AchievementKey6 = "AchievementUnlocked6";
    void Start()
    {
        Debug.Log("start");
        int achievementStatus1 = PlayerPrefs.GetInt(AchievementKey1, 0);
        Debug.Log(achievementStatus1);
        if (achievementStatus1 == 1)
        {
            Debug.Log("icon true");
            heartIcon.gameObject.SetActive(true);
        }
        int achievementStatus2 = PlayerPrefs.GetInt(AchievementKey2, 0);
        Debug.Log(achievementStatus2);
        if (achievementStatus2 == 1)
        {
            Debug.Log("icon true");
            gamePadIcon.gameObject.SetActive(true);
        }
        int achievementStatus3 = PlayerPrefs.GetInt(AchievementKey3, 0);
        Debug.Log(achievementStatus3);
        if (achievementStatus3 == 1)
        {
            Debug.Log("icon true");
            rocketIcon.gameObject.SetActive(true);
        }
        int achievementStatus4 = PlayerPrefs.GetInt(AchievementKey4, 0);
        Debug.Log(achievementStatus4);
        if (achievementStatus4 == 1)
        {
            Debug.Log("icon true");
            wCIcon.gameObject.SetActive(true);
        }
        int achievementStatus5 = PlayerPrefs.GetInt(AchievementKey5, 0);
        Debug.Log(achievementStatus5);
        if (achievementStatus5 == 1)
        {
            Debug.Log("icon true");
            moneyIcon.gameObject.SetActive(true);
        }
        int achievementStatus6 = PlayerPrefs.GetInt(AchievementKey6, 0);
        Debug.Log(achievementStatus6);
        if (achievementStatus6 == 1)
        {
            Debug.Log("icon true");
            timeIcon.gameObject.SetActive(true);
        }
        


    }

    // public void pressSpace()
    // {
    //     PlayerPrefs.SetInt(AchievementKey1, 1);
    //     PlayerPrefs.Save();
    //     heartIcon.gameObject.SetActive(true);
    // }
}
