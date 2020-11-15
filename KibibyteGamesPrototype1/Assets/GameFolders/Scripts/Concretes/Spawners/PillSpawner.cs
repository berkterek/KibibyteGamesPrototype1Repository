using KibibyteGamesPrototype1.Controllers;
using KibibyteGamesPrototype1.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KibibyteGamesPrototype1.Spawners
{
    public class PillSpawner : MonoBehaviour
    {
        [SerializeField] float delayTime = 1f;
        [SerializeField] PillController[] pills;

        PillManager _pillManager;

        private void Awake()
        {
             _pillManager = GetComponentInParent<PillManager>();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnStartAgain += Spawn;
        }

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            StartCoroutine(SpawnAsync());
        }

        private IEnumerator SpawnAsync()
        {
            for (int j = 0; j < pills.Length; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    yield return new WaitForSeconds(delayTime);

                    PillController pill = Instantiate(pills[j], transform.position, Quaternion.identity);
                    pill.transform.parent = _pillManager.transform;
                    _pillManager.AddPill(pill);
                }
            }
        }
    }
}

