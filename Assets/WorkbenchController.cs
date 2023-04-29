using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorkbenchController : InteraciveController
{
    private void Update()
    {
        if (playerStaying)
        {
            Debug.Log("player staying in workbench");
            // press E to confirm
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("player pressed E");
                
            }
        }
    }
}
