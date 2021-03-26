using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable_Floor : MonoBehaviour
{
    #region Health_vars
    [SerializeField]
    [Tooltip("proportional to # ticks before collapsing")]
    private int max_strength;
    private int curr_strength;

    [SerializeField]
    [Tooltip("how long it takes for each tick of damage")]
    private float weightCD;
    private float weightTimer;

    private Player player;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        curr_strength = max_strength;
        weightTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (weightTimer > 0) {
                weightTimer -= Time.deltaTime;
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        if (col.transform.CompareTag("feet") && weightTimer <= 0) {
            takeDMG(player.curr_size);
        }
    }

    void takeDMG(int size) {
        weightTimer = weightCD;
        curr_strength -= size;
        if (curr_strength <= 0) {
            Destroy(this.gameObject);
        }
    }
}
