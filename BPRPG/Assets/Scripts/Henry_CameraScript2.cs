using UnityEngine;
using System.Collections;

public class Henry_CameraScript2 : MonoBehaviour {
    
    public GameObject objectToFollow;
    public float speedX = 2.0f;
    public float speedY = 1.0f;
    public float topThreshold = 1.0f;
    public float botThreshold = 0.5f;
    protected Player playerJumped;
    private Camera cam;

    void Start() {
        cam = GetComponent<Camera>();
    }

    void Update () {
        float interpolationX = speedX * Time.deltaTime;
        float interpolationY = speedY * Time.deltaTime;
        Vector3 position = this.transform.position;
        
        if (objectToFollow.transform.position.y > this.transform.position.y + cam.orthographicSize * topThreshold 
                    || objectToFollow.transform.position.y < this.transform.position.y - cam.orthographicSize * botThreshold) {
            position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolationY);
        }
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolationX);
        
        this.transform.position = position;

    }
}