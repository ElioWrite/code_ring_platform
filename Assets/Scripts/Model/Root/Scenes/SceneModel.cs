using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneModel : Model
{
    [SerializeField]
    private SceneCode _code;
    public SceneCode Code => _code;

    [SerializeField]
    [Scene]
    private string _sceneAsset;
    public string Name => _sceneAsset;
}
