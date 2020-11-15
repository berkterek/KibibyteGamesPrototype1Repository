using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KibibyteGamesPrototype1.Movements
{
    public class BottleMover : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 5f;

        int _index = 0;
        MoveDirection _moveDirection;

        private void Awake()
        {
            _moveDirection = FindObjectOfType<MoveDirection>();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnNextMission += HandleNextMission;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnNextMission -= HandleNextMission;
        }
        
        private void Update()
        {
            if (_index >= _moveDirection.Directions.Length || transform.position == _moveDirection.Directions[_index].position) return;

            transform.position = Vector3.MoveTowards
                (transform.position, _moveDirection.Directions[_index].position, moveSpeed * Time.deltaTime);
        }

        private void HandleNextMission(int index)
        {
            _index += index;
        }
    }
}

