using FiveTribes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjHelpWindow : MonoBehaviour
{
    GameObject djinnHelp;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDjinnHelp(Djinn djinn)
    {
        gameObject.SetActive(true);
        GameObject.Find("DjinnDesc").GetComponent<TextMesh>().text = djinn.Desc;
        GameObject.Find("DjinnCost").GetComponent<TextMesh>().text = djinn.GetCostDesc();
        GameObject.Find("DjinnCard").GetComponent<MeshRenderer>().material.mainTexture = djinn.GetTexture();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public static ObjHelpWindow Get()
    {
        return Resources.FindObjectsOfTypeAll<ObjHelpWindow>()[0];
    }
}
