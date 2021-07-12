using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkull_script : MonoBehaviour
{
    bool canFire = false;
    int fireRate = 1;
    SpriteRenderer renderer;
    Rigidbody2D rigidbody2D;
    int randAttack;
    GameObject target;
    private Transform aimTransform;
    Color baseColor;
    Color attackRed = new Color(255,0,0);

    private ObjectPooler_script objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler_script.Instance;
        target = GameObject.FindGameObjectWithTag("Player").gameObject;
        aimTransform = this.transform.Find("bossAim");
        renderer = this.GetComponent<SpriteRenderer>();
        baseColor = renderer.color;
        rigidbody2D = this.GetComponent<Rigidbody2D>();

        Invoke("enableFire", 3f);

        StartCoroutine(DetermineRandomAttack());

    }

    // Update is called once per frame
    void Update()
    {
    }


    void Attack()
    {
        Invoke("TurnRed", 0f);
        Invoke("ResetColor", .2f);
        Invoke("TurnRed", .4f);
        Invoke("ResetColor", .6f);
        Invoke("TurnRed", .8f);
        Invoke("ResetColor", 1f);

        Invoke("FireArrow", 1f);

        Invoke("enableFire", 1f);
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

        objectPooler.SpawnFromPool("Bone", aimTransform.position, aimTransform.rotation);
    }

    void enableFire()
    {
        canFire = true;
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
