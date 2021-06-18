using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]

    [SerializeField] float health = 100;
    [SerializeField] AudioClip deathClip;
    [SerializeField] [Range(0, 1)] float deathClipVolume = 0.75f;
    [SerializeField] bool canRotate = false;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject deathVFX;
    SceneManager sceneManager;
    

    [Header("EnemyShooting")]

    [SerializeField] bool canFire = true;
    [SerializeField] bool canMultiFire = false;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.5f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject enemyLaser_1;
    

    [Header("Score")]

    ScoreManager scoreManager;
    [SerializeField] int scoreValue;


    // Start is called before the first frame update
    void Start()
    {
        sceneManager = FindObjectOfType<SceneManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneManager.gameStarted == true)
        {
            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0)
            {
                if (sceneManager.playerDied == false && canFire == true)
                {
                    Fire();
                }

                if (sceneManager.playerDied == false && canMultiFire == true)
                {
                    MultiFire();
                }

                shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);

            }
        }

        if(canRotate)
        {
           transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        
    }

    private void MultiFire()
    {
        foreach(Transform child in this.transform)
        {
            if(child.gameObject.tag == "MultiGun")
            {
                Instantiate(enemyLaser_1, child.transform.position, child.transform.localRotation);           
            }
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
        scoreManager.AddToScore(scoreValue);
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
