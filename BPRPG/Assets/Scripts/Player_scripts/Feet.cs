using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Holds a player refernce")]
    private Player Pl;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("floor"))
        {
            Pl.can_jump = true;
        }
    }
}
