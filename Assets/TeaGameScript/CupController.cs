using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEngine;


public class CupController : MonoBehaviour
{
    [Header("Collider")]
    public Collider2D cup;
    public Collider2D screenBorder;

    [Header("Status")]
    public bool hasWather;
    public bool hasTea;

    [Header("Action")]
    public bool startAddingWather;
    public bool startAddingTea;

    public ProgressBarController spellProgressBar;
    public ProgressBarController confidenceBar;

    private void Start()
    {
        confidenceBar.InitByCount(6);
    }

    public void Mistake(string message)
    {
        Debug.Log(message);
        if(confidenceBar.rate == 0)
        {
            GameOver();
        }
        else
        {
            confidenceBar.StepBack();
        }
    }

    public void GameOver()
    {
        Debug.Log("游戏结束");
    }

    public void GameSuccess()
    {
        Debug.Log("游戏成功!");
        confidenceBar.StepForward();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "Kettle")
        {
            if (!hasWather)
            {
                startAddingWather = true;
                spellProgressBar.InitByTime(4f);
            }
            else
            {
                Mistake("已经有水了");
            }
        }

        if (collision.gameObject.name == "Tea")
        {
            if (!hasTea && hasWather)
            {
                startAddingTea = true;
                spellProgressBar.InitByTime(4f);
            }
            else if (hasTea)
            {
                Mistake("已经有茶叶了");
            }
            else
            {
                Mistake("没有水");
            }
        }

        if (cup.IsTouching(screenBorder))
        {
            if (hasWather && hasTea)
            {
                GameSuccess();
            }
            hasWather = false;
            hasTea = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + " exited");

        if (collision.gameObject.name == "Kettle" && startAddingWather)
        {
            startAddingWather = false;
            // 检查进度条 判断成功与否
            if (spellProgressBar.CheckAndReset())
            {
                hasWather = true;
                Debug.Log("加水成功");
            }
            else
            {
                Mistake("失败");
            }

            if (collision.gameObject.name == "Tea")
            {
                startAddingTea = false;
                // 检查进度条 判断成功与否
            }
        }

        if (collision.gameObject.name == "Tea" && startAddingTea)
        {
            startAddingTea = false;
            // 检查进度条 判断成功与否
            if (spellProgressBar.CheckAndReset())
            {
                hasTea = true;
                Debug.Log("加茶叶成功");
            }
            else
            {
                Mistake("失败");
            }
        }
    }

    private void Update()
    {
        //更新进度条
        if (startAddingWather)
        {
            Debug.Log("Adding wather");
            spellProgressBar.StepForward();
            if (spellProgressBar.OutOfLimit())
            {
                Mistake("失败");
                startAddingWather = false;
                spellProgressBar.ResetProgress();
            }

        }

        if (startAddingTea)
        {
            Debug.Log("Adding tea");
            spellProgressBar.StepForward();
            if (spellProgressBar.OutOfLimit())
            {
                Mistake("失败");
                startAddingTea = false;
                spellProgressBar.ResetProgress();
            }
        }
    }


}
