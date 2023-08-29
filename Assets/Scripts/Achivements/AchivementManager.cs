using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchivementManager : MonoBehaviour
{

    private const string AchievementKey1 = "AchievementUnlocked1";
    private const string AchievementKey2 = "AchievementUnlocked2";
    private const string AchievementKey3 = "AchievementUnlocked3";
    private const string AchievementKey4 = "AchievementUnlocked4";
    private const string AchievementKey5 = "AchievementUnlocked5";
    private const string AchievementKey6 = "AchievementUnlocked6";

    public static void UnlockAchievement1()
    {
         // achievementUnlocked = PlayerPrefs.GetInt(AchievementKey, 0) == 1;
        PlayerPrefs.SetInt(AchievementKey1, 1);
        PlayerPrefs.Save();
    }
    public static void UnlockAchievement2()
    {
         // achievementUnlocked = PlayerPrefs.GetInt(AchievementKey, 0) == 1;
        PlayerPrefs.SetInt(AchievementKey2, 1);
        PlayerPrefs.Save();
    }
    public static void UnlockAchievement3()
    {
         // achievementUnlocked = PlayerPrefs.GetInt(AchievementKey, 0) == 1;
        PlayerPrefs.SetInt(AchievementKey3, 1);
        PlayerPrefs.Save();
    }
    public static void UnlockAchievement4()
    {
         // achievementUnlocked = PlayerPrefs.GetInt(AchievementKey, 0) == 1;
        PlayerPrefs.SetInt(AchievementKey4, 1);
        PlayerPrefs.Save();
    }
    public static void UnlockAchievement5()
    {
         // achievementUnlocked = PlayerPrefs.GetInt(AchievementKey, 0) == 1;
        PlayerPrefs.SetInt(AchievementKey5, 1);
        PlayerPrefs.Save();
    }
    public static void UnlockAchievement6()
    {
         // achievementUnlocked = PlayerPrefs.GetInt(AchievementKey, 0) == 1;
        PlayerPrefs.SetInt(AchievementKey6, 1);
        PlayerPrefs.Save();
    }
    void Update(){
         if(Input.GetKeyDown(KeyCode.L)){
            resetUnlocks();
         }
    }   

    public void resetUnlocks(){
        PlayerPrefs.SetInt(AchievementKey2, 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt(AchievementKey3, 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt(AchievementKey4, 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt(AchievementKey5, 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt(AchievementKey6, 0);
        PlayerPrefs.Save();

    }
       
}
