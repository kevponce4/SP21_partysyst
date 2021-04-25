using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjust : MonoBehaviour
{
    protected Henry_CameraScript2 cam;
    
    // Set this variable to true if your part of the map involves ascending/going up.
    // Set this variable to false if your character is on your map's ground level.
    public bool adjustTop;


    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Henry_CameraScript2>();
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.gameObject.CompareTag("Player")) {
            Debug.Log("Triggered");
            if (adjustTop) {
                cam.topThreshold = 0;
                Debug.Log("Camera Adjusted: Going up.");
            } else {
                cam.topThreshold = 1;
                Debug.Log("Camera Adjusted: On ground. ");
            }
        }
    }
}
