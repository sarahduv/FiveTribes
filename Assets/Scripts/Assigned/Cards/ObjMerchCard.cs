using System.Collections;
using System.Collections.Generic;
using FiveTribes;
using UnityEngine;

public class ObjMerchCard : MonoBehaviour
{
    private Merchandise mMerchCard;

    public Merchandise MerchCard {
        get
        {
            return mMerchCard;
        }
        set
        {
            mMerchCard = value;
            this.GetComponent<MeshRenderer>().material.mainTexture =
                Resources.Load<Texture2D>(mMerchCard.GetImage());
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
