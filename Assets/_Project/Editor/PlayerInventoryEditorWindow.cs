using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CreativeCoding.PlayerSystem
{
    public class PlayerInventoryEditorWindow : EditorWindow
    {
        private static PlayerController playerController;

        [MenuItem("Creative Coding/Show Me A Dialog Message")]
        public static void ShowDialogWindow()
        {
            if (EditorUtility.DisplayDialog(
                "Dialog!",
                "Here is a Dialog",
                "Thanks!"))
            {
                Debug.Log("Pressed Thanks Button");

                EditorBuildSettings.scenes = new EditorBuildSettingsScene[]
                {
                    new EditorBuildSettingsScene()
                    {
                        path = "Assets/_Project/Scenes/Inventory Screen.unity",
                        enabled = false
                    }
                };
                DirectoryInfo dataPathInfo = new(Application.dataPath);

                BuildPipeline.BuildPlayer(
                    EditorBuildSettings.scenes,
                    dataPathInfo.Parent + "/Builds/TestBuild.exe",
                    BuildTarget.StandaloneOSX,
                    BuildOptions.Development | BuildOptions.AutoRunPlayer | BuildOptions.CleanBuildCache);
            }
        }

        [MenuItem("Creative Coding/Player Inventory")]
        public static void ShowWindow()
        {
            EditorWindow window = GetWindow(typeof(PlayerInventoryEditorWindow));
            window.name = "Player Inventory";
            window.titleContent = new GUIContent("Player Inventory");

            window.minSize = new Vector2(300, 200);
            window.maxSize = new Vector2(500, 500);

            playerController = FindAnyObjectByType<PlayerController>();

            if (playerController == null)
                Debug.LogError("Could not find PlayerController component in the hierarchy");
        }

        private void OnGUI()
        {
            GUILayout.Label("Current Player Inventory");

            playerController.Inventory.keys = 
                EditorGUILayout.IntField("Keys", playerController.Inventory.keys);
            playerController.Inventory.applePies = 
                EditorGUILayout.IntField("applePies", playerController.Inventory.applePies);
            playerController.Inventory.pants = 
                EditorGUILayout.IntField("Pants", playerController.Inventory.pants);
            playerController.Inventory.shields = 
                EditorGUILayout.IntField("shields", playerController.Inventory.shields);
            playerController.Inventory.swords = 
                EditorGUILayout.IntField("Swords", playerController.Inventory.swords);  
        }
    }
}