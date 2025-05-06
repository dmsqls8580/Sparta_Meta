using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ������ ��� (�÷��̾�)
    public float smoothSpeed = 0.125f; // �ε巴�� �̵��� �ӵ�
    public Vector2 minBounds; // ī�޶� �ּ� ���
    public Vector2 maxBounds; // ī�޶� �ִ� ���

    private void LateUpdate()
    {
        minBounds = new Vector2(-1, -3);
        maxBounds = new Vector2(9, 5);

        if (target == null) return;

        // �÷��̾��� ��ġ�� ���󰡵�, ī�޶� ��踦 ���� �ʵ��� ����
        Vector3 desiredPosition = new Vector3(
            Mathf.Clamp(target.position.x, minBounds.x, maxBounds.x),
            Mathf.Clamp(target.position.y, minBounds.y, maxBounds.y),
            transform.position.z // ī�޶�� Z�� ����
        );

        // ���� ��ġ���� ��ǥ ��ġ�� �ε巴�� �̵�
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
