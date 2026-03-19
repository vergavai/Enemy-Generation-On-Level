using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Rigidbody _rigidBody;
    private Vector3 _moveDirection;
    

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = _moveDirection * _speed;
    }

    public void Init(Vector3 direction)
    {
        _moveDirection = direction.normalized;
    }
    
}
