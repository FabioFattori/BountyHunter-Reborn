using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class DaggerAttackArea : AttackArea
{
    // Start is called before the first frame update
    void Start()
    {
        this.damage = 10;
        this.timeToAttack = 0.5f;
    }

    
}
