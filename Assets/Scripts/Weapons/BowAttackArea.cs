using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class BowAttackArea : AttackArea
{
    public Sprite bulletImage = default;    
    private bool bulletCreatedDuringAttack = false;

    private float bulletDistance = 3f;

    public List<GameObject> bullets = new List<GameObject>();
    public GameObject bulletPrefab = default;
    // Start is called before the first frame update
    void Start()
    {
        this.damage = 20;
        this.attackDuration = 0f;
        this.timeTillNewAttack = 0.5f;
    }

    public List<GameObject> getBullets()
    {
        return bullets;
    }

    void Update()
    {
        var playerIsAttacking = GameObject.Find("Player").GetComponent<PlayerAttack>().getIsAttacking();

        if (playerIsAttacking && !bulletCreatedDuringAttack)
        {
            var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.GetComponent<Bullet>().setBullet(bulletImage, this.getCurrentDirection(), this.damage,bulletDistance);
            bullets.Add(newBullet);
            bulletCreatedDuringAttack = true;
        }

        if (!playerIsAttacking)
        {
            bulletCreatedDuringAttack = false;
        }

        //remove bullets that are destroyed
        var toDestroy = bullets.Where(bullet => bullet.GetComponent<Bullet>().isDestroyed).ToList(); 
        bullets = bullets.Where(bullet => !bullet.GetComponent<Bullet>().isDestroyed).ToList();

        toDestroy.ForEach(b=>Destroy(b));

        foreach (var bullet in bullets)
        {
            bullet.GetComponent<Bullet>().travel();
        }
    }


}


