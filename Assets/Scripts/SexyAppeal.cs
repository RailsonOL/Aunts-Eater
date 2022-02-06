using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SexyAppeal : MonoBehaviour
{
    public int pointsValue = 1;
    Animator anim;
    Transform Player;
    bool collected = false;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (gameObject.CompareTag("PrefabsContainer"))
        {
            transform.position += GameController.instance.SpawnVelocity * Time.deltaTime * Vector3.right;
        }
        else if (collected) // item follow player
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, 5f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && gameObject.CompareTag("SexyAppeal"))
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<AudioSource>().enabled = true;

            GameController.instance.AddPoints(pointsValue);
            
            anim.SetBool("collected", true);
            collected = true;
            
            Destroy(gameObject, 0.8f);
        }
    }
}
