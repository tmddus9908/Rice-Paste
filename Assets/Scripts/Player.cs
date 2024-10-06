using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public float speed;
    
    Vector2 _inputVec;
    Rigidbody2D _rigidbody;
    SpriteRenderer _spriteRenderer;
    Animator _animator;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Vector2 nextVec = _inputVec * speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + nextVec);
    }

    private void LateUpdate()
    {
        _animator.SetFloat("Speed", _inputVec.magnitude);
        
        if (_inputVec.x != 0)
            _spriteRenderer.flipX = _inputVec.x > 0;
    }

    public void OnMove(InputValue value)
    {
        _inputVec = value.Get<Vector2>();
    }
}
