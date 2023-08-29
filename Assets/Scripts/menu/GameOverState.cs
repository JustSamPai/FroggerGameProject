using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverState : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI currentScoreText;
    int score = 0;

    void Start(){
    
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore"), 0}";
        currentScoreText.text = $"CurrentScore: {PlayerPrefs.GetInt("CurrentScore"), 0}";
    }
}
