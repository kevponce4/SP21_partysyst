using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Longest length of time icicle can exist")]
    private float exist;
    private Player player;
    [SerializeField]
    [Tooltip("how much dmg on hit")]
    private int iceDMG;
    [SerializeField]
    [Tooltip("Speed of icicle")]
    private float speed;
    private Rigidbody2D iceRB;
    private Vector3 dir;
    private float mult;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        iceRB = GetComponent<Rigidbody2D>();
        if (player.lastdir) {
            mult = 1;
        } else {
            mult = -1;
        }
        if (this.transform.rotation.eulerAngles.z == 330) {
            dir = new Vector3(mult*1,mult*-1,0).normalized;
        } else if (this.transform.rotation.eulerAngles.z == 0) {
            dir = new Vector3(mult*1,0,0).normalized;
        } else {
            dir = new Vector3(mult*1,mult*1,0).normalized;
        }
        iceRB.velocity = dir * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        if (exist < 0) {
            Destroy(this.gameObject);
        }
        exist -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col)
    { // if what we collided with is the enemy
        if (col.transform.CompareTag("Enemy"))
        {
            col.transform.GetComponent<Enemy>().TakeDamage(iceDMG);
            Destroy(this.gameObject);
        } else if (!col.transform.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

}
