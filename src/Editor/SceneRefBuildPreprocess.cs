using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace Chankiyu22.UnitySceneRef
{

public class SceneRefBuildPreprocess : IPreprocessBuildWithReport
{
    public int callbackOrder
    {
        get
        {
            return 0;
        }
    }

    public void OnPreprocessBuild(BuildReport buildReport)
    {
        SceneRefSettings.Build();
    }
}

}