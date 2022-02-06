using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    Vector3 PlayerPos;
    Vector3 movementVector = Vector3.zero;
    public int DamageValue = 5;
    void Start()
    {
        if (PlayerPrefs.GetString("CurrentPlayer") == "P5")
        {
            DamageValue /= 2;
        }

        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        movementVector = (PlayerPos - transform.position).normalized * 20f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movementVector * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, PlayerPos, Time.deltaTime * 20f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.Damage(DamageValue);
        }
    }
}
