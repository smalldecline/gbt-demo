using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    private Collider2D border; // 用于存储边界的Collider2D组件
    private GameObject player;

    void Start()
    {
        // 获取场景中名为"Border"的游戏对象，其应该包含一个Collider2D组件
        border = GameObject.Find("Border").GetComponent<Collider2D>();

    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void LateUpdate()
    {
        if (border != null && player != null)
        {
            Vector3 playerPos = player.transform.position;
            playerPos.z = transform.position.z;
            transform.position = playerPos;

            // 获取相机的视野范围
            Camera cam = Camera.main;
            float camHeight = cam.orthographicSize;
            float camWidth = camHeight * cam.aspect;

            // 获取边界的范围
            float borderLeft = border.bounds.min.x + camWidth;
            float borderRight = border.bounds.max.x - camWidth;
            float borderBottom = border.bounds.min.y + camHeight;
            float borderTop = border.bounds.max.y - camHeight;

            // 限制相机的位置在边界范围内
            Vector3 newPos = transform.position;
            newPos.x = Mathf.Clamp(newPos.x, borderLeft, borderRight);
            newPos.y = Mathf.Clamp(newPos.y, borderBottom, borderTop);
            transform.position = newPos;
        }
    }
}