using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject bulletPrefab;

    [Header("UI")]
    public Canvas canvas;
    public TextMeshProUGUI textBox;
    
    [Header("Physicx")]
    public Collider2D collider;
    public Rigidbody2D rb;

    //[Header("Status")]
    //public bool isOnLadder = false;

    private void Start()
    {
        // add camera to canvas
        
    }

    private void Update()
    {
        // update movement by axis
        float axis = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3 (axis * speed, 0, 0);
        
        if (axis > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            //canvas.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (axis < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            //canvas.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        // shoot
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0;

            //init bullet
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            //set bullet toward
            bullet.GetComponent<BulletController>().targetPos = worldPos;

        }
    }

    IEnumerator clearTextBox(int time)
    {
        yield return new WaitForSeconds(time);
        textBox.text = "";
    }

    public void showText(string text,int time = 1)
    {
        // 这里可以用协程优化显示
        textBox.text = text;
        StartCoroutine(clearTextBox(time));
    }

}
