
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private AudioSource audio;

    [SerializeField] private LayerMask JumpableGround;
    [SerializeField] private Transform startAttack;
    [SerializeField] private List<GameObject> damageZones;
    [SerializeField] private List<AudioClip> stepSounds;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip landSound;
    [SerializeField] private AudioClip swingAttackSound;
    [SerializeField] private AudioClip selfHurt;

    public int jumpHeight = 15;
    public int moveSpeed = 7;
    private bool doubleJump = false;
    private bool wasInAir = false;
    private bool hasHead = true;
    private int StepCounter = 0;
    public int invinciblility = 0;
    private bool dead;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        GetComponent<Health>().onDeath += OnDeath;
        GetComponent<Health>().onDamage += OnDamage;
    }

    private void Update()
    {
        // i know that this is using the input manager not system but idc
        if (!dead)
        {
            float dirX = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                doubleJump = true;
                rb.velocity = Vector2.up * jumpHeight;
                audio.PlayOneShot(jumpSound, 0.4f);
                anim.SetTrigger("Jump");
            }
            else if (Input.GetButtonDown("Jump") && doubleJump)
            {
                doubleJump = false;
                rb.velocity = Vector2.up * (jumpHeight / 1.5f);
                audio.PlayOneShot(jumpSound, 0.4f);
            }
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(damageZones[0], startAttack.position, Quaternion.identity);
                audio.PlayOneShot(swingAttackSound, 0.6f);
                anim.SetTrigger("Attack");
            }
            if (Input.GetButtonDown("Fire2") && hasHead)
            {
                Instantiate(damageZones[1], startAttack.position, Quaternion.identity);
                FindObjectOfType<GameManager>().AddScore(0.01f);
                hasHead = false;
            }
            if (wasInAir && IsGrounded())
            {
                anim.SetTrigger("Landed");
                anim.SetBool("Fall", false);
                audio.PlayOneShot(landSound, 0.6f);
            }
            if (!IsGrounded())
            {
                //anim.SetBool("Fall", true);
            }
            if (IsGrounded())
            {
                anim.SetBool("Fall", false);
            }
            if (dirX < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                startAttack.transform.localPosition = Vector2.right * -0.655f;
                if (StepCounter > 120)
                {
                    audio.PlayOneShot(stepSounds[(int)Random.Range(0, stepSounds.Count)], 0.7f);
                    StepCounter = 0;
                }
            }
            if (dirX > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                startAttack.transform.localPosition = Vector2.right * 0.655f;
                if (StepCounter > 120)
                {
                    audio.PlayOneShot(stepSounds[(int)Random.Range(0, stepSounds.Count)], 0.7f);
                    StepCounter = 0;
                }
            }
            if (dirX > 0.2 || dirX < -0.2)
            {
                anim.SetBool("Walking", true);
            }
            else
            {
                anim.SetBool("Walking", false);
            }
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
            wasInAir = !IsGrounded();
            StepCounter++;
            invinciblility--;
            if (invinciblility > 0 && invinciblility % 3 == 0)
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
	}

    private bool IsGrounded()
    {
        //Debug.DrawRay(coll.bounds.center, Vector2.down, Color.red);
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, JumpableGround);
    }

    private void OnDeath()
    {
        anim.SetTrigger("Dead");
        dead = true;
        FindObjectOfType<GameManager>().SetGameOver();
    }

    private void OnDamage()
    {
        audio.PlayOneShot(selfHurt, 0.5f);
        invinciblility = 300;
    }

    public void HasHead()
    {
		hasHead = true;
	}

    public bool LookingRight()
    {
        return GetComponent<SpriteRenderer>().flipX == false;
    }
}
