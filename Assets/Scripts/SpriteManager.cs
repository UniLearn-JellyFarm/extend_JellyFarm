using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // 씬 관리를 위해 추가
using UnityEngine.UI; // UI 요소를 위해 추가


public class SpriteManager : MonoBehaviour
{
    public static SpriteManager instance;

    public int maxSprites = 100; // 최대 스프라이트 수
    private int destroyedSprites = 0; // 파괴된 스프라이트 수
    public GameObject gameOverUI; // 게임 오버 UI
    public Button restartButton; // 재시작 버튼
    public PlayerController playerController; // 플레이어 컨트롤러 참조 추가



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddDestroyedSprite()
    {
        destroyedSprites++;
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (destroyedSprites >= maxSprites)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverUI.SetActive(true);
        playerController.SetDieState(); // 플레이어 Die 애니메이션 설정
        Time.timeScale = 0f; // 게임 일시 정지
    }
}
