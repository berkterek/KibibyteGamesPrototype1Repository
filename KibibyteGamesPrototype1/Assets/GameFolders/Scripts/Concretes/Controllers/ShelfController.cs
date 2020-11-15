using KibibyteGamesPrototype1.Actions;
using KibibyteGamesPrototype1.Enums;
using KibibyteGamesPrototype1.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KibibyteGamesPrototype1.Controllers
{
    public class ShelfController : MonoBehaviour
    {
        [SerializeField] MyColorEnum color;
        [SerializeField] float yPosition = 0f;

        List<float> _xPositions = new List<float>() { 0f, 0.2f, -0.2f };

        public static event System.Action OnShelfChanged;

        private void OnTriggerEnter(Collider collider)
        {
            BottleController bottleController = collider.GetComponent<BottleController>();

            if (bottleController != null  && color == bottleController.Color)
            {
                int index = Random.Range(0, _xPositions.Count);
                float xPosition = _xPositions[index];
                _xPositions.RemoveAt(index);

                bottleController.GetComponent<BottleMouseDrag>().CanMove();

                bottleController.transform.parent = this.transform;
                bottleController.transform.localPosition = new Vector3(xPosition,yPosition,0f);

                OnShelfChanged?.Invoke();

                bottleController.enabled = false;

                GameManager.Instance.IncreaseScore();
            }
        }
    }
}

