using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBase : MonoBehaviour
{
    public class Config
    {
        public const float raisingSpeed = 1.5f;
    }

    void Awake()
    {
        GameAdmin.Instance.movingBase = this;
    }

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        gameObject.transform.localPosition = Vector2.zero;
    }

    void FixedUpdate()
    {
        if (!GameAdmin.Instance.status.baseCanMove) return;

        gameObject.transform.position += Vector3.up * Config.raisingSpeed * Time.deltaTime;
    }
}
