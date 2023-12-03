using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackPart : MonoBehaviour
{
    private Monster _monster;
    
    public void SetMonster(Monster monster)
    {
        _monster = monster;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            Debug.Log("player Hit");
            _monster.ApplyAttack(player);
        }
    }
}
