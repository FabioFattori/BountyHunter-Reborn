using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackArea : AttackArea
{
    // Start is called before the first frame update
    void Start()
    {
        this.damage = 50;
        this.attackDuration = 2.5f;
        this.timeTillNewAttack = 2f;
    }

    // Update is called once per frame
    
}
