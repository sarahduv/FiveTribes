using FiveTribes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEditor;

public class ObjTable : MonoBehaviour
{
    public Table mTable;

    // Start is called before the first frame update
    void Start()
    {
        mTable = new Table();
        mTable.Players = new List<Player>();
        var p1 = new Player();
        p1.Name = "Shai";
        var p2 = new Player();
        p2.Name = "Sarah";
        mTable.Players.Add(p1);
        mTable.Players.Add(p2);

        mTable.Setup();
        UpdateTiles();
        UpdateMarket();
        UpdateDjinns();
        UpdatePhase();
        UpdateBidding();
    }

    public void UpdatePhase()
    {
        foreach (var bidArrow in FindObjectsOfType<ObjBidArrow>())
        {
            if (mTable.Phase == GamePhase.Bidding)
            {
                bidArrow.Show();
            }
            else
            {
                bidArrow.Hide();
            }
        }

        foreach (var textSection in FindObjectsOfType<ObjPaperTextSection>())
        {
            if (mTable.Phase == GamePhase.Bidding && textSection.gameObject.name == "BiddingHelp")
            {
                textSection.Show(null);
            }
            else if (mTable.Phase == GamePhase.Playing && textSection.gameObject.name == "PlayerTab")
            {
                textSection.Show(mTable.GetCurrentPlayer());
            }
            else
            {
                textSection.Hide();
            }
        }

    }

    public void UpdateBidding()
    {
        var markers = FindObjectsOfType<ObjMarker>();

        // Hide all markers
        foreach (var marker in markers)
        {
            marker.Hide();
        }
        var markerByName = markers.GroupBy(x => x.name).ToDictionary(x => x.Key, x => x.First());

        bool isBiddingDone = true;
        for (var slot = 0; slot < mTable.Bidding.TurnSlots.Count; ++slot)
        {
            var playerIndex = mTable.Bidding.TurnSlots[slot];
            var marker = markerByName["TurnSlot" + slot];
            if (playerIndex == TurnBidding.NONE)
            {
                marker.Hide();
            } 
            else
            {
                marker.Player = playerIndex;
                marker.Show();
                isBiddingDone = false;
            }
        }

        foreach (var bid in mTable.Bidding.Bids)
        {
            if (bid.Value == TurnBidding.NONE)
            {
                continue;
            }
            var marker = markerByName["Bid" + bid.Key];
            marker.Player = bid.Value;
            marker.Show();
        }

        if (isBiddingDone)
        {
            mTable.Phase = GamePhase.Playing;
        }
    }

    public void UpdateTiles()
    {
        var objTiles = GameObject.Find("Tiles");
        for (int row = 0; row < Table.BoardRows; ++row)
        {
            for (int col = 0; col < Table.BoardCols; ++col)
            {
                var gmoTile = objTiles.transform.Find("Tile_" + row + "_" + col);
                var objTile = gmoTile.GetComponent<ObjTile>();
                objTile.Tile = mTable.Tiles[row, col];
            }
        }
    }

    public void UpdateCoins()
    {
    }

    public void UpdateMarket()
    {
        var objMerchandise = GameObject.Find("Merchandise");
        for (var i = 0; i < Table.MerchendiseShowingLimit; ++i)
        {
            var gmoMerchCard = objMerchandise.transform.Find("MerchCard" + i);
            if (i >= mTable.MerchendisesShowing.Count)
            {
                // Hide that card
                gmoMerchCard.GetComponent<ObjCard>().Hide();
            } else {
                gmoMerchCard.GetComponent<ObjCard>().Show();
                gmoMerchCard.GetComponent<ObjMerchCard>().MerchCard = mTable.MerchendisesShowing[i];
            }

        }
    }

    public void UpdateDjinns()
    {
        var objDjinns= GameObject.Find("Djinns");
        for (var i = 0; i < Table.DjinnShowingLimit; ++i)
        {
            var gmoDjinnCard = objDjinns.transform.Find("DjinnCard" + i);
            if (i >= mTable.DjinnsShowing.Count)
            {
                // Hide that card
                gmoDjinnCard.GetComponent<ObjCard>().Hide();
            }
            else
            {
                gmoDjinnCard.GetComponent<ObjCard>().Show();
                gmoDjinnCard.GetComponent<ObjDjinnCard>().Djinn = mTable.DjinnsShowing[i];
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
