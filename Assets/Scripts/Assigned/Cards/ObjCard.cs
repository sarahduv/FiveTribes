using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCard : MonoBehaviour
{
    public bool draggable = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hide()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
    }

    public void Show()
    {
        this.GetComponent<MeshRenderer>().enabled = true;
    }
}
