using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // �� ������ ���� �߰�
using UnityEngine.UI; // UI ��Ҹ� ���� �߰�


public class SpriteManager : MonoBehaviour
{
    public static SpriteManager instance;

    public int maxSprites = 100; // �ִ� ��������Ʈ ��
    private int destroyedSprites = 0; // �ı��� ��������Ʈ ��
    public GameObject gameOverUI; // ���� ���� UI
    public Button restartButton; // ����� ��ư
    public PlayerController playerController; // �÷��̾� ��Ʈ�ѷ� ���� �߰�



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
        playerController.SetDieState(); // �÷��̾� Die �ִϸ��̼� ����
        Time.timeScale = 0f; // ���� �Ͻ� ����
    }
}
