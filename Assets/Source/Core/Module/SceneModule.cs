using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneModule : Module
{
    private string aimScene = "";

    public void ChangeScene(string sceneName)
    {
        aimScene = sceneName;
        SceneManager.LoadScene("Loading");
    }

    public void ChangeSceneAsync(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
