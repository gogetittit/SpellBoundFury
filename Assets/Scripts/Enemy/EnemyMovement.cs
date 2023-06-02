using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    Transform player;
    


    private void Awake()
    {
       
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    
    void Update()
    {
        EnemyMove();
    }

    public void EnemyMove()
    {
        // Move the enemy towards the player
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.MoveSpeed * Time.deltaTime);

        
    }
}


