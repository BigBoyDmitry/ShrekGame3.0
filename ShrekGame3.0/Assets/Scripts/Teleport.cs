using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Sound
{
    public GameObject spawnPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = spawnPoint.gameObject .transform.position;
            PlaySound(sounds[0]);
        }
    }

}