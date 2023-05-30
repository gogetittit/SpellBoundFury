using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    Transform player;
    ParticleSystem  movementDust;
    // Start is called before the first frame update


    private void Awake()
    {
        movementDust = enemyData.particledustPrefab;
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    public void EnemyMove()
    {
        // Move the enemy towards the player
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.MoveSpeed * Time.deltaTime);

        // Check if the enemy is moving
        if (transform.position != player.transform.position)
        {
            if (!movementDust.isPlaying)
            {
                movementDust.Play(); // Start playing the particle system if it's not already playing
            }
        }
        else
        {
            movementDust.Stop(); // Stop the particle system if the enemy is not moving
        }
    }
}


