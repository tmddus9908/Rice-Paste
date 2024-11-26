using System;
using RicePaste.Scripts.Manager;
using UnityEngine;

public class cir : MonoBehaviour
{
    public Vector2 center; // 원의 중심 (Screen Space 좌표)
    public float radius; // 원의 반지름

    void Update()
    {
        center = GameManager.Instance.player.transform.position;

        float distance = Vector2.Distance(center, GameManager.Instance.player.CameraMouse);
        
        if (distance > radius)
        {
            Debug.Log("나갔다");
            GameManager.Instance.player.equippedWeapon.gameObject.SetActive(false);
        }
        else if (distance <= radius)
        {            
            Debug.Log("들어옴");
            GameManager.Instance.player.equippedWeapon.gameObject.SetActive(true);
        }
    }
}