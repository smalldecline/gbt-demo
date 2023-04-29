using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraciveController : MonoBehaviour
{
    protected bool playerStaying = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player entered trigger");
            playerStaying = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player left trigger");
            playerStaying = false;
        }
    }

}
