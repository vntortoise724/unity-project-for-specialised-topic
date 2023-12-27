using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemFX : MonoBehaviour
{
    public Rigidbody2D rb2D = null;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement movement = collision.gameObject.GetComponent<playerMovement>();
            if (movement != null)
            {
                movement.ApplyDamage();
            }

            Destroy(gameObject);
        }
    }
}
