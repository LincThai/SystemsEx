using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Callbacks;

public class PostProcessBuild : IPostprocessBuildWithReport
{
    [PostProcessBuildAttribute(1)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuildProject)
    {
        Debug.Log(pathToBuildProject);
    }

    public int callbackOrder { get {  return 0; } }
    public void OnPostprocessBuild(BuildReport report)
    {
        Debug.Log("MyCustomBuildProcesso.OnPostprocessBuild for target " + report.summary.platform);

        Debug.Log(report.summary.ToString());
    }
}
