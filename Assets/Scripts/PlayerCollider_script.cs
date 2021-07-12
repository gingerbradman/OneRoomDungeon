using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider_script : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 11)
        {
            this.gameObject.GetComponent<PlayerController_script>().Die();
        }
    }

}
