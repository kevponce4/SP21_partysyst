using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    Color originalColor;
    protected Player play_ref;
    // Start is called before the first frame update
    void Start()
    {
       play_ref = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       originalColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (play_ref.getPowerStatus() == Player.power.Fire & this.tag == "Fire Barrier") {
            GetComponent<BoxCollider2D>().isTrigger = true;
            GetComponent<SpriteRenderer>().color = new Color(originalColor.r, originalColor.g, originalColor.b, originalColor.a * 0.5f);
        } else if (play_ref.getPowerStatus() == Player.power.Ice & this.tag == "Ice Barrier") {
            GetComponent<BoxCollider2D>().isTrigger = true;
            GetComponent<SpriteRenderer>().color = new Color(originalColor.r, originalColor.g, originalColor.b, originalColor.a * 0.5f);
        } else {
            GetComponent<BoxCollider2D>().isTrigger = false;
            GetComponent<SpriteRenderer>().color = originalColor;
        }
    }
}
