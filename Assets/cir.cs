
using System;
using RicePaste.Scripts.Manager;
using UnityEngine;

public class cir : MonoBehaviour
{
    private Collider2D _circleCollider; // 검사할 Collider2D

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (_circleCollider.bounds.Contains(GameManager.Instance.player.CameraMouse))
        {
            RaycastHit2D hit = Physics2D.Raycast(GameManager.Instance.player.CameraMouse, Vector2.zero);

            if (hit.collider != null)
                Debug.Log("Raycast가 " + hit.collider.gameObject.name + "에 반응했습니다!");
        }
    }
}
