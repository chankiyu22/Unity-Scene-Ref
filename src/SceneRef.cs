using System;
using UnityEngine;

namespace Chankiyu22.UnitySceneRef
{

[Serializable]
public partial class SceneRef
{
    [SerializeField]
    string sceneGUID;

    public string GUID
    {
       get { return this.sceneGUID; }
       set { this.sceneGUID = value; }
    }

    public string SceneName
    {
        get
        {
            var s = this.Scene;
            return s == null ? string.Empty : s.SceneName;
        }
    }
    public int BuildIndex
    {
        get
        {
            var s = this.Scene;
            return s == null ? -2 : s.BuildIndex;
        }
    }

    public bool IsValid
    {
        get
        {
            return this.Scene != null;
        }
    }
    SceneRefSettings.Scene Scene
    {
        get
        {
            return SceneRefSettings.GetScene(this.sceneGUID);
        }
    }
}

}