using KibibyteGamesPrototype1.Actions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KibibyteGamesPrototype1.Managers
{
    public class MaterialManager : MonoBehaviour
    {
        [SerializeField] float delayNextMission = 2f;
        SelectMaterial[] _selectMaterials;

        private void Awake()
        {
            _selectMaterials = GetComponentsInChildren<SelectMaterial>();

            foreach (var item in _selectMaterials)
            {
                item.OnMaterialChanged += ControlAllMaterialSet;
            }
        }

        private void ControlAllMaterialSet()
        {
            if(_selectMaterials.All(x => x.IsTakeMaterial))
            {
                StartCoroutine(WaitAndGoNextMission());
            }
        }

        private IEnumerator WaitAndGoNextMission()
        {
            yield return new WaitForSeconds(delayNextMission);

            GameManager.Instance.GoNextMission();

            this.enabled = false;
        }
    }
}

