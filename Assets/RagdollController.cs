using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    void Start()
    {
        //五秒后销毁自己
        Destroy(gameObject, 5f);
    }

}
