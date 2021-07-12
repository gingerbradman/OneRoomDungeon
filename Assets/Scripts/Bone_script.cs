using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone_script : MonoBehaviour, IPooledObject
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
            other.gameObject.GetComponent<PlayerController_script>().Die();
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
        transform.Rotate(0,0,1);
    }
}
