using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon_script : MonoBehaviour
{
    private Transform aimTransform;
    private Transform aimCursorTransform;

    private ObjectPooler_script objectPooler;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        aimCursorTransform = transform.Find("Aim");
        objectPooler = ObjectPooler_script.Instance;
    }

    private void Update()
    {
        HandleAiming();
        HandleShooting();
    }

    private void HandleAiming()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        Vector3 mousePosition = vec;

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg; 
        aimTransform.eulerAngles = new Vector3(0, 0, angle);  
    }

    private void HandleShooting()
    {
        if(Input.GetMouseButtonDown(0))
        {
            objectPooler.SpawnFromPool("Fireball", aimCursorTransform.position, aimCursorTransform.rotation);
        }
    }
}
