using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTrap : MonoBehaviour
{
    Animator anim;
    public int DamageValue = 1;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position += GameController.instance.SpawnVelocity * Time.deltaTime * Vector3.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("activated");
            Player.instance.Damage(DamageValue);
        }
    }
}
