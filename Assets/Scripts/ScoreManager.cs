using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int MiniGameScore = 0;
    public Text scoreText; // 점수를 표시할 UI 텍스트 컴포넌트

    void Awake()
    {
        // ScoreManager의 인스턴스가 하나만 존재하도록 설정
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 전환되어도 이 오브젝트가 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        MiniGameScore += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            string score = MiniGameScore.ToString();
            scoreText.text = score;
        }
    }

    // 점수를 PlayerPrefs에 저장하는 메서드 추가
    public void SaveScore()
    {
        PlayerPrefs.SetInt("MiniGameScore", MiniGameScore);
        PlayerPrefs.Save();
    }
}