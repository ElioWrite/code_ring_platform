using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesModel : Model
{
    [SerializeField]
    private List<SceneModel> _scenes;
    public List<SceneModel> Scenes => _scenes;

    public IEnumerator LoadScene(SceneCode id)
    {
        var name = Scenes.FirstOrDefault(s => s.Code == id)?.Name;

        if(name == null)
        {
            Debug.Log("Cannot found scene " + id + " in the project...");
            yield return null;
        }

        var sceneTask = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);

        while (!sceneTask.isDone)
        {
            yield return null;
        }

        Debug.Log("Scene " + id + " is loaded!");
    }

    public IEnumerator UnloadScene(SceneCode id)
    {
        var name = Scenes.FirstOrDefault(s => s.Code == id)?.Name;

        if (name == null)
        {
            Debug.Log("Cannot found scene " + id + " in the project...");
            yield return null;
        }

        var sceneTask = SceneManager.UnloadSceneAsync(name);

        while (!sceneTask.isDone)
        {
            yield return null;
        }

        Debug.Log("Scene " + id + " is unloaded!");
    }
}

public enum SceneCode
{
    None = 0,
    Root = 30,
    UI = 100
}