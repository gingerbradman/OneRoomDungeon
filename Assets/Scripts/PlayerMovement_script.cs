using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_script : MonoBehaviour
{

    public float speed = 100;
    public Transform obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frameaw
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        Vector3 tempVect = new Vector3(h, 0, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;

        obj.transform.position += tempVect;
    }
}
