using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_script : MonoBehaviour
{

    public int speed;
    SpriteRenderer renderer;
    Rigidbody2D rigidbody2D;
    int randDirection;
    Direction facingDirection;
    public enum Direction {Left , Right};

    // Start is called before the first frame update
    void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>();
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        randDirection = Random.Range(0,2);

        if(randDirection == 0)
        {
            ChangeDirection("Left");
        }        
        else if (randDirection == 1)
        {
            ChangeDirection("Right");
        }

    }

    void ChangeDirection(string direction)
    {
        if(direction == "Left")
        {
            facingDirection = Direction.Left;
            renderer.flipX = false;
        }
        else if (direction == "Right")
        {
            facingDirection = Direction.Right;
            renderer.flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(facingDirection == Direction.Left)
        {
            rigidbody2D.velocity = transform.right * -(speed);
        }
        else if(facingDirection == Direction.Right)
        {
            rigidbody2D.velocity = transform.right * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.layer == 8)
        {
            if(facingDirection == Direction.Left)
            {
                ChangeDirection("Right");
            }
            else if(facingDirection == Direction.Right)
            {
                ChangeDirection("Left");
            }
        }    
    }
}
