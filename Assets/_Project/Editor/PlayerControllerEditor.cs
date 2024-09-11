using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CreativeCoding.PlayerSystem
{
    [CustomEditor(typeof(PlayerController))]
    public class PlayerControllerEditor : Editor
    {
        private PlayerController playerController;

        private void OnEnable()
        {
            playerController = (PlayerController)target;
        }

        public override void OnInspectorGUI()
        {
            GUILayout.BeginHorizontal();

            Color originalColor = GUI.color;

            GUI.color = Color.green;

            if (GUILayout.Button("Add Key", GUILayout.Height(100)))
            {
                playerController.Inventory.keys++;
                Debug.Log("Add Key", playerController);
            }

            GUI.color = Color.red;

            if (GUILayout.Button("Remove Key", GUILayout.Width(70), GUILayout.Height(100)))
            {
                if(playerController.Inventory.keys > 0)
                {
                    playerController.Inventory.keys--;
                    Debug.Log("Remove Key", playerController);
                }
            }

            GUILayout.EndHorizontal();

            GUI.color = originalColor;

            DrawDefaultInspector();
        }
    }
}