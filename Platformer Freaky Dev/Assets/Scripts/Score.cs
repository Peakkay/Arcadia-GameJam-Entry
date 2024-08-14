using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 =  UnityEngine.Vector3;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public int score;
    public float timer = 0f;
    [SerializeField]private GameObject gameOver;
    [SerializeField]private GameObject gameStart;
    [SerializeField]private GameObject game;
    [SerializeField]private TextMeshProUGUI scoreText;
    [SerializeField]private TextMeshProUGUI highscoreText;
    [SerializeField]private TextMeshProUGUI timeText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        scoreText.text = score.ToString();
        highscoreText.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        timeText.text = "0";
    }

    void Update()
    {
        if(gameOver.activeSelf == false)
        {
            TimeUp();
        }
    }

    void TimeUp()
    {
        timer += Time.deltaTime;
        UpdateTime();        
    }

    public void Reset()
    {
        score = 0;
        timer = 0;
        PlayerMove.Instance.transform.position = Vector3.zero;
        Debug.Log("Reset");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Over()
    {
        UpdateHighScore();
        gameOver.SetActive(true);
    }

    public void UpdateHighScore()
    {
        if(score> PlayerPrefs.GetInt("HighScore"))
        {
            highscoreText.text = score.ToString();
            PlayerPrefs.SetInt("HighScore",score);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetInt("HighScore"));
        }
    }
    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void UpdateTime()
    {
        if(Math.Floor(timer)>int.Parse(timeText.text))
        {
            timeText.text = Math.Floor(timer).ToString();
        }
    }

}
