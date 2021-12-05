using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public class Config
    {
        public const float raisingSpeed = 1.0f;
    }

    void FixedUpdate()
    {
        gameObject.transform.position += Vector3.up * Config.raisingSpeed * Time.deltaTime;
    }
}
