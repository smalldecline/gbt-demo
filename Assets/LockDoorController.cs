using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoorController : InteraciveController
{
    
    public GameObject colliderObj;

    private void Update()
    {
        //第一次来时是锁上的，门外的所有东西都涂黑 
        //第二次来锁自动打开，主角头上冒感叹号。 

        // 这里要加光效控制
    }
}
