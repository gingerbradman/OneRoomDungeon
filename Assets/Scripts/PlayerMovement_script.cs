using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_script : MonoBehaviour
{
    private float speed;
    public void SetSpeed(int x) {speed = x;}
    public Transform obj;
    SpriteRenderer spriteRenderer;
    GameObject spriteObject;

    // Start is called before the first frame update
    void Start()
    {
        spriteObject = this.gameObject.transform.Find("PlayerSprite").gameObject;
        spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frameaw
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");

        if(h == 0)
        {
            spriteObject.transform.eulerAngles = new Vector3(0,0,0);
        }
        else if (h > 0)
        {
            spriteRenderer.flipX = false;
            if(Mathf.Round(spriteObject.transform.eulerAngles.z)*-1 >= -15){
                spriteObject.transform.Rotate(new Vector3(0,0,-15),Space.World);
            }
        }
        else if (h < 0)
        {
            spriteRenderer.flipX = true;
            if(Mathf.Round(spriteObject.transform.eulerAngles.z) <= 15){
                spriteObject.transform.Rotate(new Vector3(0,0,1),Space.World);
            }
        }

        Vector3 tempVect = new Vector3(h, 0, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;

        obj.transform.position += tempVect;
    }
}
