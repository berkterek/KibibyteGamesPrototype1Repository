using KibibyteGamesPrototype1.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KibibyteGamesPrototype1.Managers
{
    public class PillManager : MonoBehaviour
    {
        [SerializeField] float delayTime = 2f;

        List<PillController> _pillControllers;

        private void Awake()
        {
            _pillControllers = new List<PillController>();
        }

        public void AddPill(PillController pill)
        {
            pill.OnPillSetted += HandleOnPillSetted;
            _pillControllers.Add(pill);
        }

        private void HandleOnPillSetted()
        {
            if (_pillControllers.All(x => x.IsInBottle))
            {
                StartCoroutine(GoToNextMissionAsync());
            }
        }

        private IEnumerator GoToNextMissionAsync()
        {
            foreach (PillController pill in _pillControllers)
            {
                pill.GetComponent<BoxCollider>().enabled = false;
            }

            yield return new WaitForSeconds(delayTime);

            _pillControllers = new List<PillController>();

            GameManager.Instance.GoNextMission();
        }
    }
}

