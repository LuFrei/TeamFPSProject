using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    protected Transform head;
    protected Transform body;

    [SerializeField] private float health;
    [SerializeField] private float speed;

    public float Speed { get => speed; }
}
