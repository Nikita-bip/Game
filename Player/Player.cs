using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _characterSprite;

    private Animator _animatorController;
    private Rigidbody2D _rigidbody2D;
    private MoveState _moveState = MoveState.State;
    private Vector3 _input;

    enum MoveState
    {
        State,
        Movement,
        Up,
        Down
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animatorController = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_rigidbody2D.velocity == Vector2.zero)
        {
            State();
        }
    }

    private void State()
    {
        _moveState = MoveState.State;
        _animatorController.Play("State");
    }

    public void Movement()
    {
        _moveState = MoveState.Movement;

        if (_input.x != 0)
        {
            _characterSprite.flipX = !(_input.x > 0);
        }
        _animatorController.Play("Movement");
    }
}
