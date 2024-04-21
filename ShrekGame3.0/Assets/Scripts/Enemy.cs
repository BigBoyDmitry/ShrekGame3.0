using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Sound
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public int health;
    public float speed;
    public GameObject deathEffect;
    public int damage;
    private float stopTime;
    public float startStopTime;
    public float normalSpeed;
    private PlayerController player;
    private Animator anim;



    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();
        normalSpeed = speed;
    }
    private void Update()
    {
        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }

        if (health < 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed *Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        timeBtwAttack = startTimeBtwAttack;
        health -= damage;
        PlaySound(sounds[0]);
    }
    
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(timeBtwAttack <= 0)
            {
                anim.SetTrigger("enemyAttack");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }
    public void OnEnemyAttack()
    {
        Instantiate(deathEffect,player.transform.position, Quaternion.identity);
        player.health -= damage;
        timeBtwAttack = startTimeBtwAttack;
    }
}
