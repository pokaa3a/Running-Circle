using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public class Config
    {
        public const float angularSpeed = 1.5f;
    }

    public int id = 0;

    private bool _triggered = false;
    public bool triggered
    {
        get => _triggered;
        set
        {
            _triggered = value;

            SpriteRenderer sprRenderer =
                gameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            sprRenderer.enabled = _triggered;

            CircleCollider2D circleColl =
                gameObject.GetComponent<CircleCollider2D>() as CircleCollider2D;
            circleColl.enabled = _triggered;
        }
    }

    public void Initialize(int id, float degree)
    {
        gameObject.transform.localPosition = new Vector2(
            Circle.Config.cx + Mathf.Sin(degree * Mathf.Deg2Rad) * Circle.Config.radius,
            Circle.Config.cy + Mathf.Cos(degree * Mathf.Deg2Rad) * Circle.Config.radius
        );
        triggered = false;
        this.id = id;
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

        if (BallManager.Config.clockwise)
            radian += Config.angularSpeed * Time.deltaTime;
        else
            radian -= Config.angularSpeed * Time.deltaTime;

        gameObject.transform.localPosition = new Vector2(
            Circle.Config.cx + Mathf.Sin(radian) * Circle.Config.radius,
            Circle.Config.cy + Mathf.Cos(radian) * Circle.Config.radius
        );
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            // GameAdmin.Instance.GameOver();
            GameAdmin.Instance.ballManager.BallCollideObstacle(id);
        }
        else if (collision.gameObject.tag == "Food")
        {
            GameAdmin.Instance.ballManager.AddOneBall(id);
            Destroy(collision.gameObject);
        }
    }
}
