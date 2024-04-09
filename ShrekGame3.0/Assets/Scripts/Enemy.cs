using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public GameObject deathEffect;

    private void Update()
    {
        if (health < 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed *Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
