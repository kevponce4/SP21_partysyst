using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] [Tooltip("set this to scene number you want (0 - tutorial, 1 - jane, 2 - abby")]
    private int sceneNum;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (sceneNum == 0) {
                GameManager.Instance.TutorialLevel();
            }
            if (sceneNum == 1) {
                GameManager.Instance.JaneLevel();
            }
            if (sceneNum == 2) {
                GameManager.Instance.AbbyLevel();
            }
        }
    }
}
