using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _score;
    [SerializeField] private float _step;

    public float Score { get => _score; set => _score = value; }
    public float Step { get => _step; set => _step = value; }
}
