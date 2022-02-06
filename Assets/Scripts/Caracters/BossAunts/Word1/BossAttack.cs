using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform BossProjectile;
    public Transform FirePoint;
    Vector3 PlayerPos;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating(nameof(AttackShoot), 0, 0.8f);
    }

    public void AttackShoot()
    {
        int rng = Random.Range(0,10);

        if (rng == 1 || rng == 2 || rng == 3)
        {
            anim.SetTrigger("attack");
        }
    }

    public void CallProjectile()
    {
        Instantiate(BossProjectile, FirePoint.position, Quaternion.identity);
    }
}
