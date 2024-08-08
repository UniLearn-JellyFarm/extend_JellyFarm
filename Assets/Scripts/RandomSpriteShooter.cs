using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �� ������ ���� �߰�
using UnityEngine.UI; // UI ��Ҹ� ���� �߰�


public class RandomSpriteShooter : MonoBehaviour
{
    public GameObject spritePrefab; // ������ ��������Ʈ ������
    public Vector2 spawnPosition; // ��������Ʈ�� ������ ��ġ
    public float minSpawnTime = 1f; // �ּ� ���� �ð�
    public float maxSpawnTime = 5f; // �ִ� ���� �ð�
    public float spriteSpeed = 5f; // ��������Ʈ�� �̵��� �ӵ�
    public int maxSprites = 100; // �ִ� ������ ��������Ʈ ��

    private float spawnTimer; // ���� ���������� �ð�
    private int spriteCount = 0; // ������ ��������Ʈ ��
    public GameObject gameOverUI; // ���� ���� UI
    public PlayerController playerController; // �÷��̾� ��Ʈ�ѷ� ���� �߰�


    void Start()
    {
        // ù ���� Ÿ�� ����
        SetRandomSpawnTime();
    }

    void Update()
    {
        // Ÿ�̸� ������Ʈ
        spawnTimer -= Time.deltaTime;

        // Ÿ�̸Ӱ� 0 ���ϰ� �Ǹ� ��������Ʈ ����
        if (spawnTimer <= 0f && spriteCount < maxSprites)
        {
            SpawnSprite();
            SetRandomSpawnTime();
        }
    }

    // ������ �ð� ����
    void SetRandomSpawnTime()
    {
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // ��������Ʈ ����
    void SpawnSprite()
    {
        GameObject newSprite = Instantiate(spritePrefab, spawnPosition, Quaternion.identity);
        newSprite.GetComponent<Rigidbody2D>().velocity = new Vector2(-spriteSpeed, 0);
        spriteCount++;
    }

    // ���� ���� ó��
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        playerController.SetDieState(); // �÷��̾� Die �ִϸ��̼� ����
        Time.timeScale = 0f; // ���� �Ͻ� ����
    }

    // ���� �����
    public void RestartGame()
    {
        Time.timeScale = 1f; // ���� �ӵ� ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // ���� �� �����
    }
}
