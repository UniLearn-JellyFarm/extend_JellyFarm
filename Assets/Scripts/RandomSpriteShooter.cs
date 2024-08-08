using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위해 추가
using UnityEngine.UI; // UI 요소를 위해 추가


public class RandomSpriteShooter : MonoBehaviour
{
    public GameObject spritePrefab; // 생성할 스프라이트 프리팹
    public Vector2 spawnPosition; // 스프라이트가 생성될 위치
    public float minSpawnTime = 1f; // 최소 생성 시간
    public float maxSpawnTime = 5f; // 최대 생성 시간
    public float spriteSpeed = 5f; // 스프라이트가 이동할 속도
    public int maxSprites = 100; // 최대 생성할 스프라이트 수

    private float spawnTimer; // 다음 생성까지의 시간
    private int spriteCount = 0; // 생성된 스프라이트 수
    public GameObject gameOverUI; // 게임 오버 UI
    public PlayerController playerController; // 플레이어 컨트롤러 참조 추가


    void Start()
    {
        // 첫 스폰 타임 설정
        SetRandomSpawnTime();
    }

    void Update()
    {
        // 타이머 업데이트
        spawnTimer -= Time.deltaTime;

        // 타이머가 0 이하가 되면 스프라이트 생성
        if (spawnTimer <= 0f && spriteCount < maxSprites)
        {
            SpawnSprite();
            SetRandomSpawnTime();
        }
    }

    // 랜덤한 시간 설정
    void SetRandomSpawnTime()
    {
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // 스프라이트 생성
    void SpawnSprite()
    {
        GameObject newSprite = Instantiate(spritePrefab, spawnPosition, Quaternion.identity);
        newSprite.GetComponent<Rigidbody2D>().velocity = new Vector2(-spriteSpeed, 0);
        spriteCount++;
    }

    // 게임 오버 처리
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        playerController.SetDieState(); // 플레이어 Die 애니메이션 설정
        Time.timeScale = 0f; // 게임 일시 정지
    }

    // 게임 재시작
    public void RestartGame()
    {
        Time.timeScale = 1f; // 게임 속도 복구
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // 현재 씬 재시작
    }
}
