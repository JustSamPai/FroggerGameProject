using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    int numberOfSlowDown = 3;

    [SerializeField] TextMeshProUGUI slowDownText;
    public Frogger frogger;
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;

    void Update(){
        if (!PauseMenu.isPaused){
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
    }

    public void BulletTime(){
        if (numberOfSlowDown > 0){
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        numberOfSlowDown -= 1;
        slowDownText.text = $"Slow: " + numberOfSlowDown;

        }
        
    }
}
