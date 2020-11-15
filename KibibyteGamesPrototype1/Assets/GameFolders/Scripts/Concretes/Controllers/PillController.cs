using KibibyteGamesPrototype1.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KibibyteGamesPrototype1.Controllers
{
    public class PillController : MonoBehaviour,IControllerAction
    {
        [SerializeField] float distance = 1f;
        [SerializeField] MyColorEnum color;

        Rigidbody _rigidbody;
        BoxCollider _boxCollider;
        Vector3 _startPosition;
        bool _isInBottle = false;

        public bool IsInBottle => _isInBottle;
        public MyColorEnum Color => color;

        public event System.Action OnPillSetted;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _boxCollider = GetComponent<BoxCollider>();
        }

        private void Start()
        {
            _startPosition = transform.position;
        }

        private void OnMouseDown()
        {
            if (_isInBottle) return;

            _rigidbody.useGravity = false;
            _boxCollider.isTrigger = true;
        }

        private void OnMouseDrag()
        {
            if (_isInBottle) return;

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = objPosition;
        }

        private void OnMouseUp()
        {
            if (_isInBottle) return;

            _rigidbody.useGravity = true;
            _boxCollider.isTrigger = false;

            transform.position = _startPosition;
        }

        public void SetPillToBottle(Transform transform)
        {
            this.transform.parent = transform;
            _isInBottle = true;
            OnPillSetted?.Invoke();
        }

        public void DoAction(BottleController bottleController)
        {
            bottleController.PillInsert.SetRightPill(this,bottleController.Color);
        }
    }
}

