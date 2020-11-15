using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KibibyteGamesPrototype1.Movements
{
    public class MoveDirection : MonoBehaviour
    {
        [SerializeField] Transform[] directions;

        public Transform[] Directions => directions;
    }
}

