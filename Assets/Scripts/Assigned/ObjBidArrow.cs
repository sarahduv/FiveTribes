using FiveTribes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjBidArrow : MonoBehaviour
{
    public float distanceY = 0.25f;
    public float duration = 0.5f;
    public bool directionUp = true;
    private float currentY = 0f;
    private float startY = 0f;
    private float endY = 0f;
    private float targetY = 0f;
    private float originY = 0f;
    private float startTime;
    

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        endY = startY + distanceY;
        UpdateOriginAndTarget();
    }

    private void UpdateOriginAndTarget()
    {
        originY = directionUp ? startY : endY;
        targetY = directionUp ? endY : startY;
        startTime = Time.time;
    }

    public void Hide()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
    }

    public void Show()
    {
        this.GetComponent<MeshRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime <= duration)
        {
            var factor = (float)Helpers.EaseInOut(Time.time - startTime, 0, 1, duration);
            float newY = originY + factor * (targetY - originY);
            transform.localPosition = new Vector3(
                transform.localPosition.x,
                newY,
                transform.localPosition.z);
        } else
        {
            directionUp = !directionUp;
            UpdateOriginAndTarget();
        }
    }
}
