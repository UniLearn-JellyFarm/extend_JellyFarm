using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    private void Update()
    {
        // x ��ǥ�� -12���� �۾����� ������Ʈ ��Ȱ��ȭ
        if (transform.position.x < -12f)
        {
            gameObject.SetActive(false);
            SpriteManager.instance.AddDestroyedSprite(); // �ı��� ��������Ʈ �� ������Ʈ
        }
    }
}
