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
        anim = GetComponent<Animator>();  // Получаем компонент аниматора объекта
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            AttackDamage(mousePos);
            // Запускаем анимацию удара
            anim.SetTrigger("attack");  // Предположим, что в аниматоре есть параметр с именем "Attack" для запуска анимации
        }
    }
    
    public void OnAttack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy); // Обнаружение объектов в радиусе атаки
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
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy); // Обнаружение объектов в радиусе атаки
        foreach (Collider2D hitCollider in hitColliders)
        {
            // Применение урона к объекту, если он имеет компонент здоровья
            Enemy health = hitCollider.GetComponent<Enemy>();
            if (health != null)
            {
                health.TakeDamage(damage); // Нанесение урона объекту
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}

