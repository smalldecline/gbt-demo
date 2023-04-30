using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class LadderController : MonoBehaviour
{
    [SerializeField]
    private bool isOnLadder = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isOnLadder = true;
            GameObject player = other.gameObject;
            player.transform.Find("Collider").gameObject.SetActive(false);
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isOnLadder = false;
            GameObject player = other.gameObject;
            player.transform.Find("Collider").gameObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (isOnLadder)
        {
            float verticalInput = Input.GetAxis("Vertical");
            rb.MovePosition(rb.position + new Vector2(0, verticalInput * Time.fixedDeltaTime * 3));
        }
    }
}