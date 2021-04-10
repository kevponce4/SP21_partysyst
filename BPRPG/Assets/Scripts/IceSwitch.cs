using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSwitch : MonoBehaviour
{
    [SerializeField]
    private bool isOn;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite offSprite;
    private Sprite onSprite;
    private Switchable parent;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        onSprite = spriteRenderer.sprite;
        parent = this.transform.parent.gameObject.GetComponent<Switchable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void callSwitch() {
        isOn = !isOn;
        if (isOn) {
            spriteRenderer.sprite = onSprite;
            parent.turnOn();
        } else {
            spriteRenderer.sprite = offSprite;
            parent.turnOff();
        }
    }
}
