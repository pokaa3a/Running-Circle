using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelManager
{
    public static int currentLevel = 0;

    public static void GoToLevel(int level)
    {
        if (currentLevel != 0)
        {
            SceneHelper.UnloadScene($"Level{currentLevel}");
        }

        SceneHelper.LoadScene($"Level{level}");
        currentLevel = level;
    }
}
