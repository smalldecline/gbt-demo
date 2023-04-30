using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ProgressBarController : MonoBehaviour
{
    public GameObject strip;
    public GameObject mask;
    public float length;
    [Range(0f, 1f)]
    public float rate;

    [Header("Settings")]
    public bool progressByTime = true;
    public float totalTime;
    public float a = 0.7f;
    public float b = 0.9f;

    public bool progressByCount = false;
    public int totalCount;

    private void Start()
    {
        length = strip.transform.localScale.y;
        strip.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    private void Update()
    {
        float deltaLength = rate * length;
        mask.transform.position = new Vector3(mask.transform.position.x, -length / 2 + deltaLength / 2, 0);
        mask.transform.localScale = new Vector3(mask.transform.localScale.x, deltaLength, 1);
    }

    public void InitByTime(float totalTime)
    {
        progressByCount = false;
        progressByTime = true;
        this.totalTime = totalTime;
    }

    public void InitByCount(int totalCount)
    {
        progressByCount = true;
        progressByTime = false;
        this.totalCount = totalCount;
    }

    public void StepForward()
    {
        if (progressByTime)
        {
            rate += Time.deltaTime / totalTime;
        }
        if (progressByCount)
        {
            rate += 1f / totalCount;
        }
    }

    public void StepBack()
    {
        if (progressByTime)
        {
            rate -= Time.deltaTime / totalTime;
        }
        if (progressByCount)
        {
            rate -= 1f / totalCount;
        }
    }


    public bool Check()
    {
        return rate >= a && rate <= b;
    }

    public void ResetProgress()
    {
        rate = 0f;
    }

    public bool CheckAndReset()
    {
        bool result = rate >= a && rate <= b;
        ResetProgress();
        return result;
    }

    public bool OutOfLimit()
    {
        bool result = rate > b;
        return result;
    }
}
