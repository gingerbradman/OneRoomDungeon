using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_script : MonoBehaviour
{
    float moveSpeed = 7;
    Rigidbody2D rigidbody2D;

    GameObject target;
    Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").gameObject;

        //Find out how to rotate arrows

        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rigidbody2D.velocity = new Vector2 (moveDirection.x, moveDirection.y);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            this.gameObject.SetActive(false);
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
