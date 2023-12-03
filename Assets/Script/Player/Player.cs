using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;

    public void GetDamaged(float damage)
    {
        health -= damage;
        Debug.Log("[Player] GetDamaged : " + damage + "/ current health : " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Die");
    }
}
