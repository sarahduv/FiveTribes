using FiveTribes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ClickManager : MonoBehaviour
{
    private static List<Action> MouseUpCallbacks = new List<Action>();

    bool mouseDown = false;
    ObjCard draggedCard;
    ObjTable mObjTable;
    Vector3 dragOrigin;
    Vector3 dragOffset;

    // Start is called before the first frame update
    void Start()
    {
        mObjTable = GameObject.FindObjectOfType<ObjTable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
            var table = Table.Instance;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(mousePos, Vector3.forward, 50);
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

                    ObjCoinBack objCoinBack;
                    if (hit.collider.gameObject.TryGetComponent<ObjCoinBack>(out objCoinBack))
                    {
                        objCoinBack.Target.ShowUntilMouseup(objCoinBack.Coins + " coins");
                    }


                    ObjBidArea bidArea;
                    if (
                        table.Phase == GamePhase.Bidding && 
                        hit.collider.gameObject.TryGetComponent<ObjBidArea>(out bidArea)
                    ) {
                        if (table.TryBid(bidArea.Index))
                        {
                            bidArea.Flash(1f, new Color(0, 1, 0.13f, 0.31f));
                            mObjTable.UpdateBidding();
                            mObjTable.UpdateCoins();
                            mObjTable.UpdatePhase();
                        }
                        else
                        {
                            bidArea.Flash(1f, new Color(1, 0, 0.13f, 0.31f));
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

            while (MouseUpCallbacks.Count > 0)
            {
                MouseUpCallbacks.Pop()();
            }
        }
    }

    public static void addMouseUpEvent(Action p)
    {
        MouseUpCallbacks.Add(p);
    }
}
