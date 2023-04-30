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

                GameController gameController = GameController.GetInstance();

                gameController.LoadScene("TeaGame", () =>
                {
                    Debug.Log("开始泡茶游戏");
                });
            }
        }
    }
}
