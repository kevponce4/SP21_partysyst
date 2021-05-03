using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardousObj : MonoBehaviour
{
    [SerializeField]
    private int spikeDmg;

    [SerializeField]
    private int bombDmg;
    private CircleCollider2D myCollider;
    public Transform m_particles;
    private float time = 3;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = transform.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag == "bomb") {
            StartCoroutine(PlaceBomb());
        }
    }

    IEnumerator PlaceBomb() {
        yield return new WaitForSeconds(time); // Delay execution for time seconds
    
        if (myCollider.radius < 0.02f)
        {
    
            Instantiate(m_particles, transform.position, transform.rotation);
            myCollider.radius += 0.005f;
    
        }
        /*else
        {
            myCollider.enabled = false;
            //Destroy(gameObject);
        }*/
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.GetComponent<Player>().TakeDamage(spikeDmg);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.GetComponent<Player>().TakeDamage(bombDmg);
        }
    }
}
