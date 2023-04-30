using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float damage = 10f;
    public float speed = 10f;
    public Vector3 targetPos;

    private Vector3 toward;

    Collider2D border;

    private void Start()
    {
        border = GameObject.Find("Border").GetComponent<Collider2D>();
        toward = (targetPos - transform.position).normalized;

        Debug.Log(targetPos);
        Debug.Log(transform.position);
        Debug.Log(toward);
    }

    private void Update()
    {
        transform.position += toward * speed * Time.deltaTime;

        // border check
        if(border != null )
        {
            if (transform.position.x < border.bounds.min.x || transform.position.x > border.bounds.max.x ||
                               transform.position.y < border.bounds.min.y || transform.position.y > border.bounds.max.y)
            {
                Destroy(gameObject);
            }
        }

    }


}
