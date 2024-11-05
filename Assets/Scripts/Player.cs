using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;
    public Vector2 inputVec;

    Rigidbody2D _rigidbody;
    SpriteRenderer _spriteRenderer;
    Animator _animator;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + nextVec);
    }

    private void LateUpdate()
    {
        _animator.SetFloat("Speed", inputVec.magnitude);
        
        if (inputVec.x != 0)
            _spriteRenderer.flipX = inputVec.x > 0;
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 
                Camera.main.transform.position.z));
            Debug.Log(pos);

        }
    }

    public void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
