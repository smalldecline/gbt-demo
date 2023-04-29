using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health;
    public GameObject ragdoll;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果子弹进来了就受伤
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("中弹");
            health -= 1;
            if (health <= 0)
            {
                Dead();
            }
            Destroy(collision.gameObject);
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
        // 生成尸体
        GameObject ragdollObj = Instantiate(ragdoll, transform.position, Quaternion.identity);
    }


}
