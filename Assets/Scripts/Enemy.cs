using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;

    public bool isLive = true;
    
    Rigidbody2D _rigidbody;
    SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        target = GameManager.Instance.player.GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!isLive)
            return;
        
        Vector2 dirVec = target.position - _rigidbody.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        
        _rigidbody.MovePosition(_rigidbody.position + nextVec);
        _rigidbody.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!isLive)
            return;

        _spriteRenderer.flipX = target.position.x > _rigidbody.position.x;
    }
}
