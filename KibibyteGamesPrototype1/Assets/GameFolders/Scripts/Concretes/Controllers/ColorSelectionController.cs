using KibibyteGamesPrototype1.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KibibyteGamesPrototype1.Controllers
{
    public class ColorSelectionController : MonoBehaviour,IControllerAction
    {
        [SerializeField] float distance = 1f;
        [SerializeField] Material materialTransparent;
        [SerializeField] MyColorEnum color;
        
        Vector3 _startPosition;
        bool _isSetMaterial = false;

        public Material ColorSelectionMaterial => materialTransparent;
        public MyColorEnum Color => color;

        private void OnEnable()
        {
            GameManager.Instance.OnStartAgain += HandleStartAgain;
        }

        private void Start()
        {
            _startPosition = transform.position;
        }

        private void OnMouseDrag()
        {
            if (_isSetMaterial) return;

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = objPosition;
        }

        private void OnMouseUp()
        {
            transform.position = _startPosition;
        }

        public void IsSetMaterial()
        {
            _isSetMaterial = true;
            OnMouseUp();
        }

        private void HandleStartAgain()
        {
            _isSetMaterial = false;
        }

        public void DoAction(BottleController bottleController)
        {
            bottleController.SelectMaterial.ChangeBottomMaterial(bottleController.Color, this);
        }
    }
}

