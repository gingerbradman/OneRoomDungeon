using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary_script : MonoBehaviour
{
    public Vector3 resetPosition;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 9)
        {
            other.gameObject.transform.position = resetPosition;
        }
    }
}
