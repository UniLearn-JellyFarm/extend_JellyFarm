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
        // spacebar가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckCollisionAndSetEat())
            {
                SetEatState();
            }
        }

        // spacebar에서 손을 뗐을 때
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
            if (collider.gameObject.CompareTag("Sprite")) // Sprite 태그를 가진 스프라이트와 겹쳤을 때
            {
                Destroy(collider.gameObject); // 스프라이트 파괴
                ScoreManager.instance.AddScore(1); // 점수 추가
                SpriteManager.instance.AddDestroyedSprite(); // 파괴된 스프라이트 수 업데이트
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