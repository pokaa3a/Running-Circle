using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneHelper
{
    public static void LoadScene(string sceneName, bool additive = true)
    {
        SceneManager.LoadScene(
            sceneName, additive ? LoadSceneMode.Additive : 0);
    }

    public static void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
