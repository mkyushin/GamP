using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHitbox : MonoBehaviour
{
    [SerializeField] private Monster monster;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Bullet bullet))
        {
            Debug.Log("Monster Hit");
            monster.GetDamaged(bullet.damage);
        }
    }
}
