using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]

    [SerializeField] float health = 100;
    [SerializeField] AudioClip deathClip;
    [SerializeField] [Range(0, 1)] float deathClipVolume = 0.75f;
    SceneManager sceneManager;

    [Header("EnemyShooting")]


    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.5f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject enemyLaser_1;
    [SerializeField] GameObject deathVFX;
   

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = FindObjectOfType<SceneManager>();
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;

        if(shotCounter <= 0 && sceneManager.gameStarted == true)
        {
            if(sceneManager.playerDied == false)
            {
                Fire();
            }
           
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
                      
        }
    }

    private void Fire()
    {        
        Instantiate(enemyLaser_1, transform.position, Quaternion.identity);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health -= collision.GetComponent<DamageDealer>().GetDamage();

        if(health <= 0)
        {
            InitiateEnemyDeath();
        }
    }

    private void InitiateEnemyDeath()
    {
        PlaydeathSound();
        Destroy(gameObject);
        CreatedeathVFX();
    }

    private void PlaydeathSound()
    {
        AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position, deathClipVolume);
    }

    private void CreatedeathVFX()
    {
        GameObject FX = Instantiate(deathVFX, transform.position, deathVFX.transform.rotation) as GameObject;
        Destroy(FX, 1f);
    }
}
