using KibibyteGamesPrototype1.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KibibyteGamesPrototype1.Actions
{
    public class BottleCount : MonoBehaviour
    {
        BottleController[] _bottleControllers;

        public bool IsDone => _bottleControllers.Length < 1;

        private void OnEnable()
        {
            ShelfController.OnShelfChanged += GetBottleCount;
        }

        private void Start()
        {
            GetBottleCount();
        }

        private void OnDisable()
        {
            ShelfController.OnShelfChanged -= GetBottleCount;
        }

        public void GetBottleCount()
        {
            _bottleControllers = GetComponentsInChildren<BottleController>();

            if (IsDone)
            {
                StartCoroutine(IsDoneAfterStartNew());
            }
        }

        private IEnumerator IsDoneAfterStartNew()
        {
            yield return new WaitForSeconds(1f);

            GameManager.Instance.StartAgain();

            Destroy(this.gameObject);
        }
    }
}

