using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_script : MonoBehaviour, IPooledObject
{
    float moveSpeed = 7;
    public Rigidbody2D rigidbody2D;

    GameObject target;
    Vector2 moveDirection;

    public void OnObjectSpawn()
    {
        rigidbody2D.velocity = transform.right * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == 9)
        {
            PlayerController_script temp = other.gameObject.GetComponent<PlayerController_script>();
            if(temp != null){
                temp.Die();
                this.gameObject.SetActive(false);
            }

        }

        if(other.gameObject.layer == 8)
        {
            this.gameObject.SetActive(false);
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
