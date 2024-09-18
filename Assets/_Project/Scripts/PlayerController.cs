using CreativeCoding.InventorySystem;
using GluonGui.WorkspaceWindow.Views.WorkspaceExplorer.Configuration;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace CreativeCoding.PlayerSystem
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController instance {  get; private set; }

        [SerializeField] private Transform container;
        public Transform Container => container;

        [SerializeField] private Transform yawContainer;
        [SerializeField] private Transform pitchContainer;

        [SerializeField] private float containerRotateSpeed = 1;
        [SerializeField] private Vector2 pitchLimits = new(45, -45);

        [Header("Inventory")]
        [SerializeField] private Inventory inventory;
        public Inventory Inventory => inventory;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            InventoryUI.Instance.UpdateInventory(inventory);
        }

        public void Look(CallbackContext context)
        {
            // store delta locally to be used without needing to ReadValue methods
            Vector2 lookDelta = context.ReadValue<Vector2>();

            // Rotate on each axis based on data
            yawContainer.Rotate(Vector3.up, -lookDelta.x * containerRotateSpeed * Time.deltaTime);
            pitchContainer.Rotate(Vector3.right, lookDelta.y * containerRotateSpeed * Time.deltaTime);

            // get the current pitch rotation
            Vector3 pitchRotation = pitchContainer.localEulerAngles;
            
            //convert current X-axis to a range of -180 to 180 degrees
            pitchRotation.x = pitchRotation.x > 180 ? pitchRotation.x - 360 : pitchRotation.x;

            // clamp pitch angle
            pitchRotation.x = Mathf.Clamp(pitchRotation.x, pitchLimits.x, pitchLimits.y);

            // Force reset y and z angle of pitch container
            pitchRotation.y = 0;
            pitchRotation.z = 0;

            // Apply new euler angle to pitch container
            pitchContainer.localEulerAngles = pitchRotation;
        }
    }

    [Serializable]
    public class Inventory
    {
        public int keys;
        public int applePies;
        public int pants;
        public int swords;
        public int shields;
    }
}