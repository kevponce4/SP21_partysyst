using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Button : MonoBehaviour
{
    private bool isOn;
    [SerializeField]
    private float timer;
    private float currTime;
    [SerializeField]
    private GameObject spawn;
    private Player pl;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        currTime = 0;
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currTime <= 0 && isOn == true) {
            isOn = false;
            this.transform.localScale = new Vector3(1,0.5f,1);
        }
        if (currTime > 0) {
            currTime -= Time.deltaTime;
        }
    }

    public void switchh() {
        if (currTime <= 0) {
            pl.can_jump = true;
            isOn = true;
            currTime = timer;
            this.transform.localScale = new Vector3(1,0.2f,1);
            Instantiate(spawn, this.transform.position + new Vector3(2, 2, 0), this.transform.rotation);
        }
    }


}
