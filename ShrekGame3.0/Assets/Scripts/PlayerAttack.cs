using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();  // �������� ��������� ��������� �������
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            AttackDamage(mousePos);
            // ��������� �������� �����
            anim.SetTrigger("attack");  // �����������, ��� � ��������� ���� �������� � ������ "Attack" ��� ������� ��������
        }
    }
    
    public void OnAttack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy); // ����������� �������� � ������� �����
        foreach (Collider2D hitCollider in hitColliders)
        {
            Enemy health = hitCollider.GetComponent<Enemy>();
            if (health != null)
            {
                health.TakeDamage(damage); 
            }
        }
    }

    void AttackDamage(Vector2 position)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy); // ����������� �������� � ������� �����
        foreach (Collider2D hitCollider in hitColliders)
        {
            // ���������� ����� � �������, ���� �� ����� ��������� ��������
            Enemy health = hitCollider.GetComponent<Enemy>();
            if (health != null)
            {
                health.TakeDamage(damage); // ��������� ����� �������
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}

