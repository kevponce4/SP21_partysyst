using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    // The horizontal distance away from the starting location that the enemy will patrol
    [SerializeField]
    private float patrol_distance;
    [SerializeField]
    private float patrol_speed;
    private bool patrol_left;

    // Update is called once per frame
    private void Update()
    {
        Move();
        update_attack_timer();

        // Set the enemy's direction to face the direction they are moving
        if (enemyRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (enemyRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    // Override Move function
    private void Move()
    {
        // Commonly used positions for later use
        float enemy_x = transform.position.x;
        float enemy_y = transform.position.y;

        if (play_ref != null)
        {
            // move towards player
            float player_x = play_ref.transform.position.x;
            float player_y = play_ref.transform.position.y;

            enemyRB.velocity = new Vector2(player_x - enemy_x, player_y - enemy_y).normalized * movespeed;
        } 
        // .25 margins are arbitrary and prevent flickering
        else if (transform.position.y > startingpos.y + .25 || transform.position.y < startingpos.y - .25)
        {
            // move towards initial position
            float initial_x = startingpos.x;
            float initial_y = startingpos.y;

            enemyRB.velocity = new Vector2(initial_x - enemy_x, initial_y - enemy_y).normalized * movespeed;
        }
        else
        {
            // Patrol

            // Change direction if past boundaries
            if (transform.position.x > startingpos.x)
            {
                patrol_left = true;
            }
            else if (transform.position.x < startingpos.x - patrol_distance)
            {
                patrol_left = false;
            }
    
            // Move along patrol
            if (patrol_left)
            {
                enemyRB.velocity = Vector2.left * patrol_speed;
            } 
            else
            {
                enemyRB.velocity = Vector2.right * patrol_speed;
            }
        }
    }
}
