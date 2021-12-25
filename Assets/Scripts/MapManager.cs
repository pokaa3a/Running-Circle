using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager
{
    GameObject mapParent;

    private static MapManager _instance;
    public static MapManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MapManager();
            }
            return _instance;
        }
    }

    private MapManager()
    {

    }

    public void MakeMap()
    {
        mapParent = new GameObject("MapParent");

        // BlockPool.blocks[0].InstantiateBlock(Vector2.zero, mapParent);
    }

    public void DestroyMap()
    {

    }
}
