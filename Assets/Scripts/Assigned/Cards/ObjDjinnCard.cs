using FiveTribes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDjinnCard : MonoBehaviour
{
    private Djinn mDjinn;
    public Djinn Djinn
    {
        get
        {
            return mDjinn;
        }
        set
        {
            mDjinn = value;
            this.GetComponent<MeshRenderer>().material.mainTexture = mDjinn.GetTexture();
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
