using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_script : MonoBehaviour, IPooledObject
{
    public float speed;
    public Rigidbody2D rigidbody2D;
    public int damage;
    // Start is called before the first frame update
    public void OnObjectSpawn()
    {
        rigidbody2D.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 8) //Wall collision
        {
            this.gameObject.SetActive(false);
        }

        if(other.gameObject.layer == 11) //Enemy Collision
        {
            Enemy_script e = other.gameObject.GetComponent<Enemy_script>();
            e.TakeDamage(damage);
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
