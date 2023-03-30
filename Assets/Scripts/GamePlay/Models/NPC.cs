using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GamePlay
{
    public class NPC : MonoBehaviour
    {
        [SerializeField] private float _point;

        public float Point { get => _point; set => _point = value; }
    }
}