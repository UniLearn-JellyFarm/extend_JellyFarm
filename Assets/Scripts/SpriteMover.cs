using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    private void Update()
    {
        // x 좌표가 -12보다 작아지면 오브젝트 비활성화
        if (transform.position.x < -12f)
        {
            gameObject.SetActive(false);
            SpriteManager.instance.AddDestroyedSprite(); // 파괴된 스프라이트 수 업데이트
        }
    }
}
