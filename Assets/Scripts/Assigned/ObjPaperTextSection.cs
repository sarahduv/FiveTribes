using FiveTribes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjPaperTextSection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hide()
    {
        foreach (var text in gameObject.GetComponentsInChildren<ObjText>())
        {
            text.Hide();
        }

        transform.Find("ElderLine").HideChildren();
        transform.Find("VizierLine").HideChildren();
        transform.Find("CoinsStack").HideChildren();
        transform.Find("FakirLine").HideChildren();
        transform.Find("CamelLine").HideChildren();
        transform.Find("DjinnLine").HideChildren();
        transform.Find("MerchandiseLine").HideChildren();
    }

    public void Show(Player player)
    {
        foreach (var text in gameObject.GetComponentsInChildren<ObjText>())
        {
            var newtext = text.GetTemplate();
            if (player != null) {
                newtext = newtext.Replace("$pname", player.Name);
                newtext = newtext.Replace("$camelsLeft", player.CamelsLeft.ToString());
            }
            text.UpdateText(newtext);
            text.Show();
        }

        if (player != null)
        {
            UpdateLine(transform.Find("VizierLine"), player.VizierCount, -1);
            UpdateLine(transform.Find("ElderLine"), player.ElderCount, -1);
            UpdateLine(transform.Find("FakirLine"), player.FakirCount, -1);
            UpdateLine(transform.Find("CamelLine"), player.CamelsLeft, player.Index);
            UpdateCoinStack(transform.Find("CoinsStack"), player.Coins, transform.Find("CoinCount").GetComponent<ObjText>());
            UpdateDjinns(transform.Find("DjinnLine"), player.Djinns);
            UpdateMerchendise(transform.Find("MerchandiseLine"), player.Merchendise);
        }
    }

    private void UpdateMerchendise(Transform transform, List<Merchandise> merchendise)
    {
    }

    private void UpdateDjinns(Transform transform, List<Djinn> djinns)
    {
    }

    private void UpdateCoinStack(Transform stack, int coins, ObjText target)
    {
        if (stack == null)
        {
            return;
        }

        for (int i = 0; i < stack.childCount; ++i)
        {
            stack.GetChild(i).GetComponent<ObjCoinBack>().UpdateCoins(
                coins,
                target
            );
            stack.GetChild(i).GetComponent<MeshRenderer>().enabled = true;

        }
    }

    private void UpdateLine(Transform line, int count, int playerIndex)
    {
        if (line == null)
        {
            return;
        }
        for (int i = 0; i < line.childCount; ++i)
        {
            var child = line.GetChild(i);
            if (playerIndex >= 0)
            {
                ObjCamel camel;
                if (child.TryGetComponent<ObjCamel>(out camel))
                {
                    camel.Player = playerIndex;
                }
            }
            child.GetComponent<MeshRenderer>().enabled = i < count;
        }
    }
}
