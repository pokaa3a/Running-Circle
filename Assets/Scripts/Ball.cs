using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public class Config
    {
        public const float angularSpeed = 1f;
    }

    bool clockwise = true;

    void Start()
    {
        // Initial position is at 12am position of the circle
        gameObject.transform.position = new Vector2(
            Circle.Config.cx,
            Circle.Config.cy + Circle.Config.radius
        );
    }

    void FixedUpdate()
    {
        Vector2 vec = gameObject.transform.position -
            new Vector3(Circle.Config.cx, Circle.Config.cy);

        float radian = Vector2.Angle(Vector2.up, vec) * Mathf.Deg2Rad;
        if (gameObject.transform.position.x < Circle.Config.cx) radian = 2f * Mathf.PI - radian;

        if (clockwise)
            radian += Config.angularSpeed * Time.deltaTime;
        else
            radian -= Config.angularSpeed * Time.deltaTime;

        gameObject.transform.position = new Vector2(
            Circle.Config.cx + Mathf.Sin(radian) * Circle.Config.radius,
            Circle.Config.cy + Mathf.Cos(radian) * Circle.Config.radius
        );
    }
}
