using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorController : InteraciveController
{
    [Header("Within scene transfer")]
    public bool inSceneTranslate;
    public Transform destinationUpstair;
    public Transform destinationDownstair;

    [System.Serializable]
    public class DestinationInfo
    {
        public string sceneName;
        public Vector3 birthPlace;
        public string ElevatorName;
    }

    [Header("Across scene transfer")]
    public bool acrossSceneTranslate;
    public bool acrossSceneTranslateByName;
    public DestinationInfo upstair;
    public DestinationInfo downstair;


    private void Update()
    {
        if (playerStaying)
        {
            Debug.Log("player staying in elevator");

            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("player pressed W");
                // move player to destination
                if (inSceneTranslate)
                {
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    player.transform.position = destinationUpstair.position;
                }
                else if (acrossSceneTranslate && upstair.sceneName != "")
                {
                    // load scene
                    SceneManager.LoadSceneAsync(upstair.sceneName).completed += (AsyncOperation obj) =>
                    {
                        // create player
                        GameController gameController = GameController.GetInstance();
                        if (acrossSceneTranslateByName)
                        {
                            // get position of elevator
                            GameObject elevator = GameObject.Find(upstair.ElevatorName);
                            upstair.birthPlace = elevator.transform.position;
                        }
                        gameController.CreatePlayer(upstair.birthPlace);
                    };
                }
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("player pressed S");
                // move player to destination
                if (inSceneTranslate)
                {
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    player.transform.position = destinationDownstair.position;
                }
                else if (acrossSceneTranslate && downstair.sceneName != "")
                {
                    // load scene
                    SceneManager.LoadSceneAsync(downstair.sceneName).completed += (AsyncOperation obj) =>
                    {
                        // create player
                        GameController gameController = GameController.GetInstance();
                        if (acrossSceneTranslateByName)
                        {
                            // get position of elevator
                            GameObject elevator = GameObject.Find(downstair.ElevatorName);
                            downstair.birthPlace = elevator.transform.position;
                        }
                        gameController.CreatePlayer(downstair.birthPlace);
                    };

                }
            }

        }
    }

}
