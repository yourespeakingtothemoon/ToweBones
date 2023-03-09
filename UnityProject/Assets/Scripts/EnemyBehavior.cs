using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyBehavior : MonoBehaviour
{
	private Rigidbody2D rb;
	private SpriteRenderer sprite;
	private bool goingLeft = true;
	private AudioSource audio;
	private Animator anim;
	private float attackTimer;

	[SerializeField] private float speed;
	[SerializeField] private float raycastDistance;
	[SerializeField] private List<AudioClip> hurt;
	[SerializeField] private Transform startAttack;
	[SerializeField] private GameObject damageZones;

	public void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		audio = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();

		GetComponent<Health>().onDeath += OnDeath;
		GetComponent<Health>().onDamage += OnDamage;
	}

	private void Update()
	{
		RaycastHit2D hit;
		if (goingLeft)
		{
			rb.velocity = Vector2.left * speed;
			sprite.flipX = false;
			hit = Physics2D.Raycast(startAttack.position, Vector2.left, raycastDistance);
			//Debug.Log(hit.collider.gameObject.name);
		}
		else 
		{
			rb.velocity = Vector2.right * speed;
			sprite.flipX = true;
			hit = Physics2D.Raycast(startAttack.position, Vector2.right, raycastDistance);
		}
		if (hit.collider != null)
		{ 
			if (hit.collider.gameObject.CompareTag("Player") && attackTimer < 0)
			{
				attackTimer = 200;
				Instantiate(damageZones, startAttack.position, Quaternion.identity);
				anim.SetTrigger("Attack");
			}
		}
		attackTimer--;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Ledge"))
		{
			goingLeft = goingLeft == true ? false : true;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.otherCollider.gameObject.CompareTag("Enemy"))
		{
			goingLeft = goingLeft == true ? false : true;
		}
	}

	private void OnDeath()
	{
		FindObjectOfType<GameManager>().AddScore(Random.Range(0.5f, 1.5f));
		Destroy(gameObject);
	}

	private void OnDamage()
	{
		audio.PlayOneShot(hurt[Random.Range(0, hurt.Count)], 0.5f);
	}
}
