using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 추적할 대상 (플레이어)
    public float smoothSpeed = 0.125f; // 부드럽게 이동할 속도
    public Vector2 minBounds; // 카메라 최소 경계
    public Vector2 maxBounds; // 카메라 최대 경계

    private void LateUpdate()
    {
        minBounds = new Vector2(-1, -3);
        maxBounds = new Vector2(9, 5);

        if (target == null) return;

        // 플레이어의 위치를 따라가되, 카메라 경계를 넘지 않도록 제한
        Vector3 desiredPosition = new Vector3(
            Mathf.Clamp(target.position.x, minBounds.x, maxBounds.x),
            Mathf.Clamp(target.position.y, minBounds.y, maxBounds.y),
            transform.position.z // 카메라는 Z값 고정
        );

        // 현재 위치에서 목표 위치로 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
