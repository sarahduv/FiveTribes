using FiveTribes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class ObjTile : MonoBehaviour
{
    private Tile mTile;
    private UnityEngine.Object PalacePrefab;
    private UnityEngine.Object TreePrefab;
    private UnityEngine.Object MeeplePrefab;
    private UnityEngine.Object CamelPrefab;

    public Tile Tile
    {
        get
        {
            return mTile;
        }
        set
        {
            mTile = value;
            UpdateTile();
        }
    }

    private void UpdateTile()
    {
        // Update score
        gameObject.transform.Find("TileScore").GetComponent<MeshRenderer>().material.mainTexture =
            Resources.Load<Texture2D>(@"Images\TileScore\Score" + mTile.Score + (mTile.Color == TileColor.Blue ? "B" : "R"));

        // Update action
        gameObject.transform.Find("TileAction").GetComponent<MeshRenderer>().material.mainTexture =
            Resources.Load<Texture2D>(mTile.TileAction.GetImagePath());

        // Update background image
        gameObject.GetComponent<MeshRenderer>().material.mainTexture =
            Resources.Load<Texture2D>(@"Images\Tiles\Tile_" + mTile.TileIndex.ToString().PadLeft(4, '0'));

        UpdateMeeples();
        UpdateTokens(TileTokenKind.Palace, PalacePrefab, Tile.PalaceCount);
        UpdateTokens(TileTokenKind.Tree, TreePrefab, Tile.TreeCount);
        UpdateCamels();
    }

    private void UpdateCamels()
    {
        foreach (var objCamel in transform.GetComponentsInChildren<ObjCamel>())
        {
            Destroy(objCamel.gameObject);
        }

        if (Tile.Owner == null)
        {
            return;
        }

        var bounds = GetComponent<Renderer>().bounds;
        var width = bounds.size.x;
        var height = bounds.size.y;
        var right = bounds.center.x + width / 2.0f;
        var bottom = bounds.center.y - height / 2.0f;
        var marginX = bounds.size.x / 20.0f;
        var marginY = bounds.size.y / 20.0f;

        var x = right - marginX;
        var y = bottom + marginY;

        var goCamel = (GameObject)PrefabUtility.InstantiatePrefab(CamelPrefab, gameObject.transform);

        // We position using the center, so adjust by center
        var tokenBounds = goCamel.GetComponent<Renderer>().bounds;
        y += tokenBounds.size.y / 2.0f;
        x -= tokenBounds.size.x / 2.0f;

        goCamel.GetComponent<ObjCamel>().Player = Tile.Owner.Index;
        goCamel.transform.position = new Vector3(x, y, -0.25f);
    }

    private void UpdateTokens(TileTokenKind kind, UnityEngine.Object prefab, int count)
    {
        foreach (var tileToken in transform.GetComponentsInChildren<TileToken>())
        {
            if (tileToken.Kind == kind)
            {
                Destroy(tileToken.gameObject);
            }
        }

        if (count == 0)
        {
            return;
        }

        var bounds = GetComponent<Renderer>().bounds;
        var width = bounds.size.x;
        var height = bounds.size.y;
        var left = bounds.center.x - width / 2.0f;
        var top = bounds.center.y + height / 2.0f;
        var marginX = bounds.size.x / 20.0f;
        var marginY = bounds.size.y / 20.0f;
        var interval = marginX;

        for (int tokenIndex = 0; tokenIndex < count; ++tokenIndex)
        {
            var x = left + marginX + (tokenIndex * interval);
            var y = top - marginY;

            var goToken = (GameObject)PrefabUtility.InstantiatePrefab(prefab, gameObject.transform);

            // We position using the center, so adjust by center
            var tokenBounds = goToken.GetComponent<Renderer>().bounds;
            y -= tokenBounds.size.y / 2.0f;
            x += tokenBounds.size.x / 2.0f;

            goToken.transform.position = new Vector3(x, y, -0.25f);
        }
    }

    private void UpdateMeeples()
    {
        // Destroy all existing meeples
        foreach (var objMeeple in transform.GetComponentsInChildren<ObjMeeple>())
        {
            Destroy(objMeeple.gameObject);
        }

        if (Tile.Meeples.Count == 0)
        {
            return;
        }

        var bounds = GetComponent<Renderer>().bounds;
        var width = bounds.size.x;
        var left = bounds.center.x - width / 2.0f;

        // Width = 5
        // 0 0 1 0 0 // segment = 2.5
        // 0 1 0 1 0 // segment = 1.6...3.2 (5/3)
        // 1 0 1 0 1 // segment = 1.25....2.5.... (5/4)
        var segment = width / (float)(Tile.Meeples.Count + 1);

        for (int meepleIndex = 0; meepleIndex < Tile.Meeples.Count; ++meepleIndex)
        {
            var meeple = Tile.Meeples[meepleIndex];
            var x = (meepleIndex + 1) * segment;

            var goMeeple = (GameObject)PrefabUtility.InstantiatePrefab(MeeplePrefab, gameObject.transform);
            var objMeeple = goMeeple.GetComponent<ObjMeeple>();
            objMeeple.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
            objMeeple.transform.position = new Vector3(left + x, objMeeple.transform.position.y, -0.25f);
            objMeeple.Meeple = meeple;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        PalacePrefab = Resources.Load(@"Prefabs\Palace");
        TreePrefab = Resources.Load(@"Prefabs\Tree");
        MeeplePrefab = Resources.Load(@"Prefabs\Meeple");
        CamelPrefab = Resources.Load(@"Prefabs\Camel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
