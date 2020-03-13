using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCamel : MonoBehaviour
{
    private int mPlayer;
    public int Player
    {
        get
        {
            return mPlayer;
        }
        set
        {
            mPlayer = value;
            this.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load<Texture2D>(@"Images\Camels\Camel" + mPlayer);
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
