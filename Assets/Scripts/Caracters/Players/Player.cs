using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float jumpForce;
    private Rigidbody2D rb;

    [Header("Sounds")]
    public AudioClip hitSound;
    AudioSource audioS;

    private Animator anim;

    [Header("Ground Pivot")]
    public Transform groundPivot;
    public float radius;
    public LayerMask layer;

    public static Player instance;
    void Start()
    {
        instance = this;
        audioS = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();
    }

    public void Jump()
    {
        bool touchingGround = Physics2D.OverlapCircle(groundPivot.position, radius, layer);
        if (Input.GetButtonDown("Jump") && !GameController.instance.isPause)
        {
            if (touchingGround)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        anim.SetBool("jump", !touchingGround);
    }

    public void Damage(int damageValue = 1)
    {
        GameController.instance.playerLife -= damageValue;
        anim.SetTrigger("takehit");

        audioS.clip = hitSound;
        audioS.Play();

        anim.enabled = true;
        GameController.instance.UpdateLifePoints();
    }

    public void Heal(int healValue = 1)
    {
        GameController.instance.playerLife += healValue;
        GameController.instance.UpdateLifePoints();
    }
}
