using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileToken : MonoBehaviour
{
    public TileTokenKind Kind;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum TileTokenKind
{
    Tree,
    Palace,
}