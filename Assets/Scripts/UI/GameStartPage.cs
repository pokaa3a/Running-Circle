using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameStartPage : MonoBehaviour, IPointerDownHandler
{
    void Awake()
    {
        GameAdmin.Instance.gameStartPage = this;
    }

    public void OnPointerDown(PointerEventData data)
    {
        GameAdmin.Instance.StartPlaying();
    }
}
