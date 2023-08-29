using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int numberOfSlowDown;
    private Home[] homes;
    [SerializeField]
    private int score;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI slowDownText;
    [SerializeField] private int lives;
    private Frogger frogger;
    [SerializeField]
    private int time;
    public bool allowInput = true;
    public bool hasDied = false; 
    public AchivementManager achivementManager;
    public SlideOutAnimation slideOutAnimation;
    bool hasWCAchivement;

    bool hasMoneyAchivement;
    bool hasTimeAchivement;

    private void Awake()
    {
        
        homes = FindObjectsOfType<Home>();
        frogger = FindObjectOfType<Frogger>();
    }

    private void Start()
    {
        slowDownText.text = "Slow : " + 3;
        NewGame();
    }

    private void NewGame()
    {
        //gameOverMenu.SetActive(false);
        SetScore(0);
        SetLives(3);
        NewLevel();
    }
    private void NewLevel()
    {
        for (int i = 0; i< homes.Length; i++)
        {
            homes[i].enabled= false;
        }

        Respawn();
    }
    private void Respawn()
    {
        frogger.Respawn();
        hasDied = false;
        StopAllCoroutines();
        StartCoroutine(Timer(30));
    }
    private IEnumerator Timer(int duration)
    {
        time = duration;

        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
        if(!hasWCAchivement){
            hasWCAchivement = true;
            slideOutAnimation.StartAnimation();
            AchivementManager.UnlockAchievement4();
        }
        frogger.Death();
    }

    public void Died()
    {
        SetLives(lives - 1);
        if (lives > 0)
        {
            hasDied = true;
            Invoke(nameof(Respawn), 1f);
        }
        else
        {
            Invoke(nameof(GameOver), 1f);
        }
    }
    private void GameOver()
    {
       
        frogger.gameObject.SetActive(false);
    
        SceneManager.LoadScene("Game_Over");
        StopAllCoroutines();
        StartCoroutine(PlayAgain());
    }
    private IEnumerator PlayAgain()
    {
        bool playAgain = false;
        while (!playAgain)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                playAgain= true;
            }
            yield return null;
        }
        NewGame();
    }

    void updateScore(){
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore"), 0}";
        currentScoreText.text = $"CurrentScore: {PlayerPrefs.GetInt("CurrentScore"), 0}";
    }

    public void AdvancedRow()
    {
        SetScore(score + 10);
        
    }
    public void HomeOccupied()
    {
        
        frogger.gameObject.SetActive(false);

        int bonusPoints = time * 20;

        SetScore(score + bonusPoints + 50);
        if (Cleared())
        {
            if (time > 15 && !hasTimeAchivement){
                slideOutAnimation.StartAnimation();
            AchivementManager.UnlockAchievement6();
            }
            SetScore(score + 1000);
            updateScore();
            SetLives(lives + 1);
            Invoke(nameof(NewLevel), 1f);
        }
        else
        {
            Invoke(nameof(Respawn), 1f);
        }
    }
    private bool Cleared()
    {
        for(int i =0; i<homes.Length; i++)
        {
            if (!homes[i].enabled)
            {
                return false;
            }
        }
        if(lives > 3){
            slideOutAnimation.StartAnimation();
            AchivementManager.UnlockAchievement1();
            
        }
        return true;
    }
    private void SetScore(int score)
    {

        PlayerPrefs.SetInt("CurrentScore", score);
        updateScore();
        if(score > PlayerPrefs.GetInt("HighScore", 0)){
        PlayerPrefs.SetInt("HighScore", score);
        updateScore();
        }
        if (score > 5000 && !hasMoneyAchivement){
            slideOutAnimation.StartAnimation();
            AchivementManager.UnlockAchievement5();
            hasMoneyAchivement = true;
        }
        this.score = score;
        //... UI
    }
    public int GetScore(int score){
        
        return (this.score = score);

    }
    private void SetLives(int lives)
    {
        livesText.text = $"Lives: {lives}";
        this.lives = lives;
        //... UI
    }


   


}
