using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Longest length of time flame can exist")]
    private float exist;
    private Player player;
    private Vector3 pos;
    private Vector3 offset;
    [SerializeField]
    [Tooltip("how long between flame dmg instances")]
    private float dmgCD;
    private float dmgTimer;
    [SerializeField]
    [Tooltip("how much dmg each instance")]
    private int flameDMG;
    public static bool dir = false;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        dmgTimer = 0f;
        sprite = GetComponent<SpriteRenderer>();
        if (dir) {
            sprite.flipX = false;
            offset = new Vector3(2,0,0);
        } else {
            sprite.flipX = true;
            offset = new Vector3(-2,0,0);
        }
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (exist < 0 || !Input.GetKey("k")) {
            Destroy(this.gameObject);
        }
        exist -= Time.deltaTime;
        if (dmgTimer > 0) {
            dmgTimer -= Time.deltaTime;
        }
        transform.position = player.transform.position + offset;
    }

    void OnTriggerStay2D(Collider2D col)
    { // if what we collided with is the enemy
        if (col.transform.CompareTag("Enemy") && dmgTimer <= 0)
        {
            dmgTimer = dmgCD;
            col.transform.GetComponent<Enemy>().TakeDamage(flameDMG);
            
        }
        if (col.transform.CompareTag("Flammable"))
        {
            col.transform.GetComponent<Flammable>().onFire = true;
            
        }
    }

}
