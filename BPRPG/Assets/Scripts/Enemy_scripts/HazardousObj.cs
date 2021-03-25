using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardousObj : MonoBehaviour
{
    private int dmg;
    private Vivian_Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject item = other.gameObject;

        if(item.name == "Spikes1")
        {
            player = GetComponent<Vivian_Player>();
            player.TakeDamage(dmg);
        }
    }
}
