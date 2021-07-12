using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_script : MonoBehaviour
{

    public int speed;
    int currentSpeed;
    bool canFire = false;
    public int fireRate;
    SpriteRenderer renderer;
    Rigidbody2D rigidbody2D;
    int randAttack;
    int randDirection;
    Direction facingDirection;
    public enum Direction {Left , Right};

    GameObject target;
    private Transform aimTransform;
    Color baseColor;
    Color attackRed = new Color(255,0,0);

    private ObjectPooler_script objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler_script.Instance;
        currentSpeed = speed;
        target = GameObject.FindGameObjectWithTag("Player").gameObject;
        aimTransform = this.transform.Find("goblinAim");
        renderer = this.GetComponent<SpriteRenderer>();
        baseColor = renderer.color;
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

        Invoke("enableFire", 3f);

        StartCoroutine(DetermineRandomAttack());

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

    void Attack()
    {
        speed = 0;

        Invoke("TurnRed", 0f);
        Invoke("ResetColor", .2f);
        Invoke("TurnRed", .4f);
        Invoke("ResetColor", .6f);
        Invoke("TurnRed", .8f);
        Invoke("ResetColor", 1f);

        Invoke("FireArrow", 1f);

        Invoke("enableFire", 3f);
    }

    void ResetColor()
    {
        renderer.color = baseColor;
    }

    void TurnRed()
    {
        renderer.color = attackRed;
    }

    void FireArrow()
    {
        Vector3 vec = target.transform.position;
        vec.z = 0f;
        Vector3 targetPosition = vec;

        Vector3 aimDirection = (targetPosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg; 
        aimTransform.eulerAngles = new Vector3(0, 0, angle); 

        objectPooler.SpawnFromPool("Arrow", aimTransform.position, aimTransform.rotation);
    }

    void enableFire()
    {
        canFire = true;
        speed = currentSpeed;
    }

    IEnumerator DetermineRandomAttack()
    {
        while(true){
            while(canFire)
            {
                randAttack = Random.Range(0,2);
                if(randAttack == 0)
                {
                    canFire = false;
                    Attack();
                }
                yield return new WaitForSeconds(fireRate);
            }
            yield return null;
        }

        yield return null;
    }
}
