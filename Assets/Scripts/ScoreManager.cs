using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int MiniGameScore = 0;
    public Text scoreText; // ������ ǥ���� UI �ؽ�Ʈ ������Ʈ

    void Awake()
    {
        // ScoreManager�� �ν��Ͻ��� �ϳ��� �����ϵ��� ����
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ���� ��ȯ�Ǿ �� ������Ʈ�� �ı����� �ʵ��� ����
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

    // ������ PlayerPrefs�� �����ϴ� �޼��� �߰�
    public void SaveScore()
    {
        PlayerPrefs.SetInt("MiniGameScore", MiniGameScore);
        PlayerPrefs.Save();
    }
}