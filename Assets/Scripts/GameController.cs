using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;


public delegate void OnSceneLoadCallback();

public class GameController : MonoBehaviour
{
    //单例
    private static GameController instance;


    [Header("prefabs")]
    public GameObject playerPrefab;

    //游戏初始化
    public static bool isGameInitialized = false;

    //游戏数据
    public float gameTime;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (!isGameInitialized)
        {
            isGameInitialized = true;
            if (GameObject.Find("BirthPlace") != null)
            {
                GameObject birthPlace = GameObject.Find("BirthPlace");
                GameObject player = CreatePlayer(birthPlace.transform.position);
                player.transform.position = birthPlace.transform.position;

                Destroy(gameObject);
            }
            gameTime += Time.deltaTime;
        }
    }

    public GameObject CreatePlayer(Vector3 position)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log($"Create new player at {position}");
            return Instantiate(playerPrefab, position, Quaternion.identity);
        }
        else
        {
            return player;
        }
    }

    public void LoadScene(string sceneName, OnSceneLoadCallback callback = null)
    {
        SceneManager.LoadSceneAsync(sceneName).completed += (AsyncOperation obj) =>
        {
            if (callback != null)
                callback();
        };
    }

    public static GameController GetInstance()
    {
        return instance;
    }

}
