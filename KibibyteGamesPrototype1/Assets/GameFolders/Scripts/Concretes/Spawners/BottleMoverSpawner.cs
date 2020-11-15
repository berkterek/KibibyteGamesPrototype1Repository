using KibibyteGamesPrototype1.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KibibyteGamesPrototype1.Spawners
{
    public class BottleMoverSpawner : MonoBehaviour
    {
        [SerializeField] BottleMover bottleMover;
        [SerializeField] int maxSpawn = 3;

        int _spawnCount = 0;

        private void OnEnable()
        {
            GameManager.Instance.OnStartAgain += Spawn;
        }

        private void Start()
        {
            Spawn();
        }

        private void OnDisable()
        {
            GameManager.Instance.OnStartAgain -= Spawn;
        }

        private void Spawn()
        {
            if (_spawnCount < maxSpawn)
            {
                Instantiate(bottleMover, transform.position, Quaternion.identity);
                _spawnCount++;
            }
        }
    }
}

