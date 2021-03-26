using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drain : MonoBehaviour
{
    [SerializeField]
    [Tooltip("max curr size for slime to fall thru")]
    private int maxSize;
    private Player player;
    private GameObject dr;
    private float timer;
    private bool fin;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        dr = this.transform.parent.gameObject;
        fin = true;
        timer = 2f;
    }

    // Update is called once per frame
    void Update() 
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
        }
        if (!fin && timer > 0) {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), dr.GetComponent<Collider2D>(), true);
        } else {
            fin = true;
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), dr.GetComponent<Collider2D>(), false);
        }
    }

    private void OnTriggerStay2D(Collider2D col) 
    {
        if (fin && col.transform.CompareTag("feet") && Input.GetAxisRaw("Vertical") < 0 && player.curr_size <= maxSize) 
        {
            fin = false;
            timer = 2f;
            player.can_jump = false;
        }
    }
    void changeState(Collider2D col) {
        if (fin && col.transform.CompareTag("feet") && Input.GetAxisRaw("Vertical") < 0 && player.curr_size <= maxSize) 
        {
            Debug.Log("hi");
            fin = false;
            while (timer > 0) {
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), dr.GetComponent<Collider2D>(), true);
                timer -= Time.deltaTime;
                Debug.Log(timer);
            }
            timer = 4f;
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), dr.GetComponent<Collider2D>(), false);
            fin = true;
        }
    }

}
