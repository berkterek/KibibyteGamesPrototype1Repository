using KibibyteGamesPrototype1.Controllers;
using KibibyteGamesPrototype1.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KibibyteGamesPrototype1.Actions
{
    public class PillInsert : MonoBehaviour
    {
        public void SetRightPill(PillController pill, MyColorEnum color)
        {
            if (color == pill.Color)
            {
                pill.SetPillToBottle(this.transform);
                GameManager.Instance.IncreaseScore();
            }
        }
    }
}

