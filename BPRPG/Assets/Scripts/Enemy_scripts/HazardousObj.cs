using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardousObj : MonoBehaviour
{
    [SerializeField]
    private int dmg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.GetComponent<Player>().TakeDamage(dmg);
        }
    }
}
