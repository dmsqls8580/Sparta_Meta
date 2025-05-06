using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    // Animator �Ķ���� �̸��� �̸� �ؽ÷� ��ȯ�� ĳ�� (���� ����ȭ)
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");

    protected Animator animator;

    protected virtual void Awake()
    {
        // �ִϸ����� ������Ʈ�� �ڽĿ��� ������
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        // �̵� ���� ������ ũ�⸦ �̿��� �����̴� ������ �Ǵ�
        animator.SetBool(IsMoving, obj.magnitude > .5f);
    }

    public void Damage()
    {
        // �ǰ� �ִϸ��̼� ���� ����
        animator.SetBool(IsDamage, true);
    }

    public void InvincibilityEnd()
    {
        // ���� �ð� ���� �� ȣ��
        animator.SetBool(IsDamage, false);
    }
}
