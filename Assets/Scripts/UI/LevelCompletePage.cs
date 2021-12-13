using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelCompletePage : MonoBehaviour, IPointerDownHandler
{
    void Awake()
    {
        GameAdmin.Instance.levelCompletePage = this;
    }

    public void OnPointerDown(PointerEventData data)
    {
        GameAdmin.Instance.InitializeGame();
    }
}
