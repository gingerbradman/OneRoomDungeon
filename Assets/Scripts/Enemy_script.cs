using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    private Color matWhite;
    private Color matDefault;
    SpriteRenderer spriteRenderer;
    Object explosionRef;

    public int startingHealth;
    int currentHealth;
    GameManager_script gameManager_Script;
    AudioSource hurtSFX;
    AudioSource explodeSFX;
    // Start is called before the first frame update
    void Start()
    {
        gameManager_Script = GameObject.Find("GameManager").GetComponent<GameManager_script>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        matWhite = new Color(255,255,255);
        matDefault = spriteRenderer.material.color;
        GameObject sfxManager = GameObject.Find("SFX Manager").gameObject;
        hurtSFX = sfxManager.transform.Find("hurtSFX").GetComponent<AudioSource>();
        explodeSFX = sfxManager.transform.Find("explodeSFX").GetComponent<AudioSource>();
        explosionRef = Resources.Load("Explosion");
        currentHealth = startingHealth;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        spriteRenderer.material.color = matWhite;
        if(currentHealth <= 0)
        {
            explodeSFX.Play();
            Die();
        }
        else
        {
            hurtSFX.Play();
            Invoke("ResetMaterial", .1f);
        }
    }

    void ResetMaterial() 
    {
        spriteRenderer.material.color = matDefault;
    }

    void Die()
    {
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x,transform.position.y, transform.position.z);
        gameManager_Script.EnemyDied();
        Destroy(this.gameObject);
    }
}
