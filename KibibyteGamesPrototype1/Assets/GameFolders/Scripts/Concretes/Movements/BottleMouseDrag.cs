using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KibibyteGamesPrototype1.Movements
{
    public class BottleMouseDrag : MonoBehaviour
    {
        [SerializeField] float distance = 1f;

        Vector3 _startPosition;
        bool _canMove = true;

        private void OnMouseDown()
        {
            if (!_canMove) return;

            _startPosition = transform.localPosition;
        }

        private void OnMouseDrag()
        {
            if (!_canMove) return;

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = objPosition;
        }

        private void OnMouseUp()
        {
            if (!_canMove) return;

            transform.localPosition = _startPosition;
        }

        public void CanMove()
        {
            _canMove = !_canMove;
        }
    }
}

