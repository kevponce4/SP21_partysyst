using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("wether this is the left or right indicator")]
    private bool is_left_indic;
    [SerializeField]
    [Tooltip("holds refrence to parent")]
    private Enemy parentEn;


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("floor"))
        {
            if (is_left_indic)
            {
                parentEn.setLeftInd(false);
            }
            else
            {
                parentEn.setRightInd(false);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entered");
        if (collision.CompareTag("floor"))
        {
            if (is_left_indic)
            {
                parentEn.setLeftInd(true);
            }
            else
            {
                parentEn.setRightInd(true);
            }

        }
    }

}
