using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private DamageZone dz;
    [SerializeField] private string Hits;
    [SerializeField] private bool UsesHead;
    private bool direction;
    private float timer;

    public void Start()
    {
        timer = dz.destroyTimer;
        direction = FindObjectOfType<PlayerMovement>().LookingRight();
	}

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (UsesHead)
            {
                FindObjectOfType<PlayerMovement>().HasHead();
            }
            Destroy(gameObject);
        }

        if (dz.moving)
        {
            if (direction)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.right * dz.movingSpeed);
            }
            else 
            {
				gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.left * dz.movingSpeed);
			}
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Hits))
        {
            other.GetComponent<Health>().OnApplyDamage(dz.amountOfDamage);
            timer = 0;
        }
        if (other.CompareTag("Jumpable"))
        {
            timer = 0;
        }
    }
}
