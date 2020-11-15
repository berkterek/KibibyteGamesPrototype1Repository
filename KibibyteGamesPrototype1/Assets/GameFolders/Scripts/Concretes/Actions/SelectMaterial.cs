using KibibyteGamesPrototype1.Controllers;
using KibibyteGamesPrototype1.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KibibyteGamesPrototype1.Actions
{
    public class SelectMaterial : MonoBehaviour
    {
        [SerializeField] MeshRenderer topMeshRenderer;
        [SerializeField] MeshRenderer bottomMeshRenderer;
        [SerializeField] bool isTakeMaterial = false;

        public bool IsTakeMaterial => isTakeMaterial;

        public event System.Action OnMaterialChanged;

        public void ChangeBottomMaterial(MyColorEnum myColor, ColorSelectionController colorSelection)
        {
            if (myColor == colorSelection.Color)
            {
                bottomMeshRenderer.material = colorSelection.ColorSelectionMaterial;
                isTakeMaterial = true;
                OnMaterialChanged?.Invoke();
                GameManager.Instance.IncreaseScore();
                colorSelection.IsSetMaterial();
            }
        }
    }
}
