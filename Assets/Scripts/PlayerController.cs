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

    [Header("Collider")]
    public Collider2D collider;

    //[Header("Status")]
    //public bool isOnLadder = false;

    private void Start()
    {
        // add camera to canvas
        canvas.worldCamera = Camera.main;
    }

    private void Update()
    {
        // update movement by axis
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed * Time.deltaTime;

        // update toward
        float axis = Input.GetAxis("Horizontal");
        if (axis > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            canvas.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (axis < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            canvas.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        // shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //init bullet
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            //set bullet toward
            bullet.GetComponent<BulletController>().toward = transform.localScale.x;

        }
    }

    public void showText(string text,int time = 1)
    {
        // 这里可以用协程优化显示
        textBox.text = text;
    }

}
