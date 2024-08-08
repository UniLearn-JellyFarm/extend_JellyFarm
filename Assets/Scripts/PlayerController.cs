using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private bool IsEat = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // spacebar�� ������ ��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckCollisionAndSetEat())
            {
                SetEatState();
            }
        }

        // spacebar���� ���� ���� ��
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SetRunState();
        }
    }

    protected bool CheckCollisionAndSetEat()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Sprite")) // Sprite �±׸� ���� ��������Ʈ�� ������ ��
            {
                Destroy(collider.gameObject); // ��������Ʈ �ı�
                ScoreManager.instance.AddScore(1); // ���� �߰�
                SpriteManager.instance.AddDestroyedSprite(); // �ı��� ��������Ʈ �� ������Ʈ
                return true;
            }
        }
        return false;
    }

    private void SetEatState()
    {
        IsEat = true;
        animator.SetBool("IsEat", IsEat);
    }

    private void SetRunState()
    {
        IsEat = false;
        animator.SetBool("IsEat", IsEat);
    }

    public void SetDieState()
    {
        animator.SetTrigger("doDie");
    }
}