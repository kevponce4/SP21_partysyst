using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchable : MonoBehaviour
{
    [SerializeField]
    [Tooltip("1 = door, 2 = anything that appears (coins, platforms, etc)")]
    private int type;
    [SerializeField]
    [Tooltip("only needed for type 2")]
    private GameObject prefab;
    [SerializeField]
    [Tooltip("if true, can repeatedly turn on/off")]
    private bool multiSwitch;
    private bool switched;

    // Start is called before the first frame update
    void Start()
    {
        switched = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnOn() {
        if (type == 2 && (multiSwitch || !switched)) {
            Instantiate(prefab, this.transform.position, this.transform.rotation);
            switched = true;
        }
    }

    public void turnOff() {

    }
}
