using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverPage : MonoBehaviour, IPointerDownHandler
{
    void Awake()
    {
        GameAdmin.Instance.gameOverPage = this;
    }

    public void OnPointerDown(PointerEventData data)
    {
        GameAdmin.Instance.InitializeGame();
    }
}
