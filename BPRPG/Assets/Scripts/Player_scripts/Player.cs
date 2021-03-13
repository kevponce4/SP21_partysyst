using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region attack_vars
    [SerializeField]
    [Tooltip("the time untill the hitbox is created")]
    private float hitboxtiming;
    private float attack_timer;
    [SerializeField]
    [Tooltip("amount of damage basic attack deals to enemy")]
    private int dmg;
    #endregion

    #region UI/Health_vars
    [SerializeField]
    [Tooltip("maximum health player can have")]
    private int max_health;
    private int curr_health;
    #endregion

    #region Unity_vars
    private Rigidbody2D PlayerRB;
    #endregion

    #region Movement_vars
    [SerializeField]
    [Tooltip("Character move speed")]
    private float move_speed;
    [SerializeField]
    [Tooltip("Velocity of character jump")] //may need to add a jump duration in addition to this
    private float jump_vel;
    [Tooltip("tells the player if the can jump or not")] // may need to move some colliders/ children
    public bool can_jump; // may need to change to an int if we want double jumps
    private float x_input;
    private float y_input; // may get rid of this depending on controll scheme
    [SerializeField]
    [Tooltip("How long we want to be jumping")]
    private float jump_len;
    private float vert_vel;
    private Vector2 cur_direction;

    #endregion

    #region Unity_funcs
    // Start is called before the first frame update
    void Awake()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        vert_vel = 0;
        curr_health = max_health;
        attack_timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");
        move();
        if( attack_timer<= 0  && ( Input.GetKeyDown("i") || Input.GetKeyDown("z")))
        {
            StartCoroutine(Attack());
        } else if (attack_timer > 0)
        {
            attack_timer -= Time.deltaTime;
        }
    }
    #endregion

    #region Move_funcs
    private void move()
    {
        if(y_input > 0 && can_jump)
        {
            can_jump = false;
            StartCoroutine(jumping());
            //vert_vel = jump_vel;
        }
        if(x_input != 0)
        {
            cur_direction = new Vector2(x_input / x_input, 0);
            PlayerRB.velocity = new Vector2(x_input * move_speed, vert_vel);
        }
        else
        {
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, vert_vel);
        }
    }

    // may need to think about how to cancell this function if we want dashes
    // may need to think about slowing the jump down near the end so it isn't so abrupt
    IEnumerator jumping() 
    {
        can_jump = false;
        //float jump_timer = jump_len;
        float jump_timer = 0;
        while(jump_timer < jump_len)
        {
            vert_vel = Mathf.Lerp(jump_vel, 0, jump_timer / jump_len);
            jump_timer += Time.deltaTime;
            yield return null;
        }
        jump_timer = 0;
       // while (jump_timer < jump_len && !can_jump)
        //{
        //    vert_vel = Mathf.Lerp(0, -jump_vel, jump_timer / jump_len);
        //    jump_timer += Time.deltaTime;
        //    yield return null;
        //}
        vert_vel = 0;
    }
    #endregion

    #region Attack_funcs
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(hitboxtiming);
        RaycastHit2D[] hits = Physics2D.BoxCastAll(PlayerRB.position + cur_direction, Vector2.one, 0f, Vector2.zero);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<Enemy>().TakeDamage(dmg);
            }
        }
        yield return new WaitForSeconds(hitboxtiming);
    }

    #endregion
}
