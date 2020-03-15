using FiveTribes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjBidArea : MonoBehaviour
{
    public int Index;
    MeshRenderer mMeshRenderer;
    Color startColor;
    float startTime;
    float duration;
    bool visible = true;

    // Start is called before the first frame update
    void Start()
    {
        mMeshRenderer = GetComponent<MeshRenderer>();
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime <= duration)
        {
            var factor = (float)Helpers.EaseOut(Time.time - startTime, 0, 1, duration);
            float newA = startColor.a + factor * (0 - startColor.a);
            SetColor(new Color(startColor.r, startColor.g, startColor.b, newA));
        }
        else
        {
            Hide();
        }
    }

    public void Flash(float duration, Color fromColor)
    {
        this.startColor = fromColor;
        this.startTime = Time.time;
        this.duration = duration;
        SetColor(fromColor);
        Show();
    }

    private void SetColor(Color color)
    {
        mMeshRenderer.material.SetColor("_Color", color);
    }

    public void Hide()
    {
        if (!visible) return;
        visible = false;
        mMeshRenderer.enabled = false;
    }

    public void Show()
    {
        if (visible) return;
        visible = true;
        mMeshRenderer.enabled = true;
    }
}
