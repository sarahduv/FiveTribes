using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjText : MonoBehaviour
{
    private TextMesh mMesh;
    private MeshRenderer mRenderer;
    private string mTemplate;

    // Start is called before the first frame update
    void Start()
    {
        mMesh = gameObject.GetComponent<TextMesh>();
        mRenderer = gameObject.GetComponent<MeshRenderer>();
        mTemplate = mMesh.text;
    }

    public void UpdateText(string newText)
    {
        mMesh.text = newText;
    }

    public string GetTemplate()
    {
        return mTemplate;
    }

    public void Show()
    {
        mRenderer.enabled = true;
    }

    public void Hide()
    {
        mRenderer.enabled = false;
    }

    public void ShowUntilMouseup(string textUntilMouseup)
    {
        var textAfterMouseUp = mMesh.text;
        mMesh.text = textUntilMouseup;
        ClickManager.addMouseUpEvent(() => { mMesh.text = textAfterMouseUp; });
    }
}
