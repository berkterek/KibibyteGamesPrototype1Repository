using KibibyteGamesPrototype1.Actions;
using KibibyteGamesPrototype1.Enums;
using KibibyteGamesPrototype1.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KibibyteGamesPrototype1.Controllers
{
    public class BottleController : MonoBehaviour
    {
        [SerializeField] MyColorEnum color;
        [SerializeField] GameObject topBottle;
         
        SelectMaterial _selectMaterial;
        PillInsert _pillInsert;
        BottleMouseDrag _bottleMouseDrag;

        public MyColorEnum Color => color;
        public SelectMaterial SelectMaterial => _selectMaterial;
        public PillInsert PillInsert => _pillInsert;

        private void Awake()
        {
            _selectMaterial = GetComponent<SelectMaterial>();
            _pillInsert = GetComponent<PillInsert>();
            _bottleMouseDrag = GetComponent<BottleMouseDrag>();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnNextMission += HandleOnNextMission;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnNextMission -= HandleOnNextMission;
        }

        private void OnTriggerEnter(Collider other)
        {
            //ColorSelectionController colorSelection = other.GetComponent<ColorSelectionController>();
            IControllerAction myAction = other.GetComponent<IControllerAction>();

            if (myAction != null)
            {
                myAction.DoAction(this);
            }

            //if (colorSelection != null)
            //{
            //    _selectMaterial.ChangeBottomMaterial(color,colorSelection);
            //    return;
            //}

            //PillController pillController = other.GetComponent<PillController>();

            //if (pillController != null)
            //{
            //    _pillInsert.SetRightPill(pillController, color);
            //}
        }


        private void HandleOnNextMission(int index)
        {
            topBottle.SetActive(!topBottle.activeSelf);
            _bottleMouseDrag.CanMove();
        }
    }
}

