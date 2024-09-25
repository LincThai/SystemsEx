using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameController))]
public class GameControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameController controller = (GameController)target;

        if (GUILayout.Button("Raycast"))
        {
            controller.Raycast();
        }

        base.OnInspectorGUI();
    }
}
