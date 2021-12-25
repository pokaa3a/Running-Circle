using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
{
    public string prefabPath;
    public float height;
    public GameObject prefabObject;

    public Block(string _prefabPath, float _height)
    {
        this.prefabPath = _prefabPath;
        this.height = _height;

        this.prefabObject = (GameObject)Resources.Load(this.prefabPath);
    }

    public GameObject InstantiateBlock(Vector2 pos, Transform parent)
    {
        return Object.Instantiate(prefabObject, pos, Quaternion.identity, parent);
    }
}
