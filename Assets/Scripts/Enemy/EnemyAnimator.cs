using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    Animator am;
    EnemyMovement em;
    SpriteRenderer sr;
    PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        em = GetComponent<EnemyMovement>();
        sr = GetComponent<SpriteRenderer>();
        pm = FindObjectOfType<PlayerMovement>();
    }


    // Update is called once per frame
    void Update()
    {

        SpriteDirectionChecker();
    }



    void SpriteDirectionChecker()
    {
        if (em.transform.position.x < pm.transform.position.x)
        {
            sr.flipX = false; // Face right if the player is to the right of the enemy
        }
        else
        {
            sr.flipX = true; // Face left if the player is to the left of the enemy
        }
    }


}
