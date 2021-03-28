using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    #region Health_vars
    [SerializeField]
    [Tooltip("maximum health player can have")]
    protected int max_health;
    protected int curr_health;
    #endregion

    #region Movement_vars
    protected Rigidbody2D enemyRB;
    protected Player play_ref;
    protected Player size_ref;
    [SerializeField]
    protected bool left_ind;
    [SerializeField]
    protected bool right_ind;
    protected Vector2 startingpos;

    [SerializeField]
    protected float movespeed;
    #endregion

    #region Attack_vars
    [SerializeField]
    [Tooltip("number of frames between attacks")]
    protected int attack_delay;
    protected int attack_timer;
    [SerializeField]
    protected int attack_damage;
    
    #endregion

    #region Unity_Funcs
    
    void Start()
    {
        curr_health = max_health;
        enemyRB = GetComponent<Rigidbody2D>();
        startingpos = new Vector2(enemyRB.position.x, enemyRB.position.y);
        size_ref = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (attack_timer > 0)
        {
            attack_timer--;
        }
    }
    #endregion

    #region Move_Funcs
    private void Move()
    {
        if(play_ref != null)
        {
            enemyRB.velocity = new Vector2(play_ref.transform.position.x - transform.position.x, 0).normalized * movespeed;
        }
        else
        {
            enemyRB.velocity = Vector2.zero;
        }

        if (enemyRB.velocity.x< 0 && !left_ind)
        {
            enemyRB.velocity = new Vector2(startingpos.x - transform.position.x, 0).normalized * movespeed;
        }
        else if (enemyRB.velocity.x > 0 && !right_ind)
        {
            enemyRB.velocity = new Vector2(startingpos.x - transform.position.x, 0).normalized * movespeed;
        }

    }

    public void setLeftInd(bool left)
    {
        left_ind = left;
    }
    public void setRightInd(bool right)
    {
        right_ind = right;
    }
    #endregion

    #region Search_Funcs
    public void setplayer(Player pl)
    {
        play_ref = pl;
    }
    #endregion

    #region Health_funcs
    public void TakeDamage(int dmg)
    {
        curr_health -= dmg;
        if (curr_health <= 0)
        {
            OnDeath();
            Destroy(this.gameObject);
        }
    }

    public void OnDeath()
    {
        size_ref.size_up();
    }

    #endregion

    #region Attack_funcs
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.gameObject.CompareTag("Player") && attack_timer <= 0)
        {
            Debug.Log("I'm colliding with a player");
            collision.transform.GetComponent<Player>().TakeDamage(attack_damage);
            attack_timer = attack_delay;
        }
    }

    protected void update_attack_timer()
    {
        if (attack_timer > 0)
        {
            attack_timer--;
        }
    }

    #endregion
}
