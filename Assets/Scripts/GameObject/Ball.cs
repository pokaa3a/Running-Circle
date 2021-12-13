using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public class Config
    {
        public const float angularSpeed = 1.5f;
    }

    bool clockwise = true;

    void Awake()
    {
        GameAdmin.Instance.ball = this;
    }

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        // Initial position is at 12am position of the circle
        gameObject.transform.localPosition = new Vector2(
            Circle.Config.cx,
            Circle.Config.cy + Circle.Config.radius
        );
    }

    void FixedUpdate()
    {
        if (!GameAdmin.Instance.status.ballCanMove) return;

        // Circular moving
        Vector2 vec = gameObject.transform.localPosition -
            new Vector3(Circle.Config.cx, Circle.Config.cy);

        float radian = Vector2.Angle(Vector2.up, vec) * Mathf.Deg2Rad;
        if (gameObject.transform.localPosition.x < Circle.Config.cx)
            radian = 2f * Mathf.PI - radian;

        if (clockwise)
            radian += Config.angularSpeed * Time.deltaTime;
        else
            radian -= Config.angularSpeed * Time.deltaTime;

        gameObject.transform.localPosition = new Vector2(
            Circle.Config.cx + Mathf.Sin(radian) * Circle.Config.radius,
            Circle.Config.cy + Mathf.Cos(radian) * Circle.Config.radius
        );
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clockwise ^= true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            GameAdmin.Instance.GameOver();
        }
        else if (collision.gameObject.tag == "Goal")
        {
            GameAdmin.Instance.LevelComplete();
        }
    }
}
