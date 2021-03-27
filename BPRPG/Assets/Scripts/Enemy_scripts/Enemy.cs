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
    [SerializeField]
    protected bool left_ind;
    [SerializeField]
    protected bool right_ind;
    protected Vector2 startingpos;

    [SerializeField]
    protected float movespeed;



    #endregion

    #region Unity_Funcs
    
    void Start()
    {
        curr_health = max_health;
        enemyRB = GetComponent<Rigidbody2D>();
        startingpos = new Vector2(enemyRB.position.x, enemyRB.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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

    private Player player_script;

    public void OnDeath()
    {
        player_script = play_ref;
        player_script.size_up();
    }

    #endregion
}
