using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.5f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject enemyLaser_1;
    [SerializeField] GameObject deathVFX;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;

        if(shotCounter <= 0)
        {
            Fire();
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
        Destroy(gameObject);
        CreatedeathVFX();
    }

    private void CreatedeathVFX()
    {
        GameObject FX = Instantiate(deathVFX, transform.position, deathVFX.transform.rotation) as GameObject;

        Destroy(FX, 1f);
    }
}
