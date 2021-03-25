using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable : MonoBehaviour
{
     #region Health_vars
    [SerializeField]
    [Tooltip("how many burn ticks flammable lasts")]
    private int max_health;
    private int curr_health;
    public bool onFire;
    [SerializeField]
    [Tooltip("how long it takes for each tick of damage")]
    private float burnCD;
    private float burnTimer;
    #endregion
    
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite burnSprite;
    private bool spChanged;

    #region Movement_vars
    private Rigidbody2D flammableRB;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        curr_health = max_health;
        onFire = false;
        burnTimer = 0;
        spChanged = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onFire) {
            if (!spChanged) {
                spriteRenderer.sprite = burnSprite;
            }
            if (burnTimer > 0) {
                burnTimer -= Time.deltaTime;
            }
            else {
                burn();
            }
        }
    }

    void burn()
    {
        burnTimer = burnCD;
        curr_health -= 1;
        if (curr_health <= 0) {
            Destroy(this.gameObject);
        }
    }
}
