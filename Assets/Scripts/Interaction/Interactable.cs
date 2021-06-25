using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;


namespace Game
{
    [RequireComponent(typeof(Collider2D))]
    public class Interactable : MonoBehaviour
    {
        public AtomAction InteractAction;
    }
}