using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator _animator;
    private PolygonCollider2D _polyCollider;
    private SpriteRenderer _spriteRenderer;
    private bool _isFlipY = false;
    
    private Vector2[][] _swordShape;
    private Vector2[][] _spearShape;
    private Vector2[][] _bowShape;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _polyCollider = GetComponent<PolygonCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Start()
    {
        SwordShape();
    }
    public void SetPolygonColliderSize(float sizeMultiplier)
    {
        if (_polyCollider == null) return;

        // 기본 경로 가져오기
        var originalPath = _polyCollider.GetPath(0);
        Vector2[] newPath = new Vector2[originalPath.Length];

        // 각 점의 위치를 sizeMultiplier로 조정하여 새 경로 생성
        for (int i = 0; i < originalPath.Length; i++)
        {
            newPath[i] = originalPath[i] * sizeMultiplier;
        }

        // 새 경로를 콜라이더에 적용
        _polyCollider.SetPath(0, newPath);
    }
    // x 값에만 -1을 곱하는 메서드
    void InvertXOnly(Vector2[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                // x 값에만 -1 곱하기
                array[i][j] = new Vector2(array[i][j].x * -1, array[i][j].y);
            }
        }
    }
    public void SetSwordShape(int idx)
    {
        if (_spriteRenderer.flipY && !_isFlipY)
        {
            _isFlipY = true;
            InvertXOnly(_swordShape);
        }
        else if(!_spriteRenderer.flipY && _isFlipY)
            _isFlipY = false;
        
        _polyCollider.SetPath(0, _swordShape[idx]);
    }
    private void SwordShape()
    {
        _swordShape = new Vector2[5][];
        
        _swordShape[0] = new Vector2[] {
            new Vector2(0.1597222f, 0.04166667f),
            new Vector2(0.1458333f, 0.01388889f),
            new Vector2(0.1458333f, -0.125f),
            new Vector2(0.1875f, -0.2083333f),
            new Vector2(0.6041667f, -0.5138889f),
            new Vector2(0.7013889f, -0.5138889f),
            new Vector2(0.7013889f, -0.4166667f),
            new Vector2(0.4097222f, 0f)
        };
        _swordShape[1] = new Vector2[] {
            new Vector2(0.1458333f, 0.8888889f),
            new Vector2(-0.006944444f,0.8888889f),
            new Vector2(-0.4236111f, 0.5416667f),
            new Vector2(-0.4375f, 0.4027778f),
            new Vector2(-0.4375f, 0.375f),
            new Vector2(-0.3819444f, 0.3194444f),
            new Vector2(-0.2847222f, 0.3194444f),
            new Vector2(0.1424272f, 0.7647867f)
        };
        _swordShape[2] = new Vector2[] {
            new Vector2(0.1830104f, -0.04141355f),
            new Vector2(-0.2323656f, 0.6325898f),
            new Vector2(-0.6597222f, 0.5972222f),
            new Vector2(-0.8603114f, 0.08668658f),
            new Vector2(-0.5453565f, -0.4546156f),
            new Vector2(-0.2120232f, -0.6262907f),
            new Vector2(0.5652358f, -0.5695989f),
            new Vector2(0.7847222f, -0.4169755f)
        };
        _swordShape[3] = new Vector2[] {
            new Vector2(0.1830104f, -0.04141355f),
            new Vector2(-0.2008702f, 0.645188f),
            new Vector2(-0.6219275f, 0.5972223f),
            new Vector2(-0.8540124f, 0.09928477f),
            new Vector2(-0.5453565f, -0.4546156f),
            new Vector2(-0.2120232f, -0.6262907f),
            new Vector2(0.5652358f, -0.5695989f),
            new Vector2(0.7847222f, -0.4169755f)
        };
        _swordShape[4] = new Vector2[] {
            new Vector2(0.1830104f, -0.04141355f),
            new Vector2(-0.2008702f, 0.645188f),
            new Vector2(-0.6219275f, 0.5972223f),
            new Vector2(-0.8540124f, 0.09928477f),
            new Vector2(-0.5453565f, -0.4546156f),
            new Vector2(-0.2120232f, -0.6262907f),
            new Vector2(0.5652358f, -0.5695989f),
            new Vector2(0.7847222f, -0.4169755f)
        };
    }
}
