using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour
{
    bool mouseDown = false;
    ObjCard draggedCard;
    Vector3 dragOrigin;
    Vector3 dragOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(mousePos, Vector3.forward, 50);
            Debug.Log(hits.Length + " hits");
            foreach (var hit in hits)
            {
                if (hit.collider != null)
                {
                    ObjDjinnCard objDjinn;
                    if (hit.collider.gameObject.TryGetComponent<ObjDjinnCard>(out objDjinn))
                    {
                        ObjHelpWindow.Get().ShowDjinnHelp(objDjinn.Djinn);
                    }

                    ObjCard objCard;
                    if (hit.collider.gameObject.TryGetComponent<ObjCard>(out objCard))
                    {
                        if (objCard.draggable)
                        {
                            draggedCard = objCard;
                            dragOrigin = objCard.transform.position;
                            dragOffset = mousePos - dragOrigin;
                        }
                    }
                }
            }
        }

        if (mouseDown && draggedCard != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPos = new Vector3(mousePos.x - dragOffset.x, mousePos.y - dragOffset.y, -9);
            draggedCard.transform.position = newPos;
            newPos.z = dragOrigin.z;
            if ((newPos - dragOrigin).magnitude > 0.3f)
            {
                ObjHelpWindow.Get().Hide();
            }
        }

        if (mouseDown && Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            ObjHelpWindow.Get().Hide();

            if (draggedCard != null)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                draggedCard.transform.position = new Vector3(mousePos.x - dragOffset.x, mousePos.y - dragOffset.y, dragOrigin.z);
                draggedCard = null;
            }
        }
    }
}
