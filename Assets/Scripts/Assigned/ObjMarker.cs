using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMarker : MonoBehaviour
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
            this.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load<Texture2D>(@"Images\Markers\Chip" + mPlayer);
        }
    }

    public void Hide()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
    }

    public void Show()
    {
        this.GetComponent<MeshRenderer>().enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
