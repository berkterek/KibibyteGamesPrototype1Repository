using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KibibyteGamesPrototype1.Controllers
{
    public class PillsController : MonoBehaviour
    {
        [SerializeField] BoxCollider frontBoxCollider;

        private void OnEnable()
        {
            GameManager.Instance.OnNextMission += HandleNextMission;
        }

        private void HandleNextMission(int obj)
        {
            frontBoxCollider.enabled = !frontBoxCollider.enabled;
        }
    }
}

