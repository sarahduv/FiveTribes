using FiveTribes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMeeple : MonoBehaviour
{
    private Meeple mMeeple;

    public Meeple Meeple
    {
        get
        {
            return mMeeple;
        }
        set
        {
            mMeeple = value;
            this.GetComponent<MeshRenderer>().material.mainTexture = mMeeple.GetTexture();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
