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
        SpearShape();
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
    public void SetSpearShape(int idx)
    {
        if (_spriteRenderer.flipY && !_isFlipY)
        {
            _isFlipY = true;
            InvertXOnly(_spearShape);
        }
        else if(!_spriteRenderer.flipY && _isFlipY)
            _isFlipY = false;
        
        _polyCollider.SetPath(0, _spearShape[idx]);
        _polyCollider.autoTiling = true;
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

    private void SpearShape()
    {
        _spearShape = new Vector2[6][];
        
        _spearShape[0] = new Vector2[]
        {
            new Vector2(0.4996701f, 0.5f),
            new Vector2(0.4070409f, 0.375f),
            new Vector2(0.1804456f, -0.3980748f),
            new Vector2(0.1850386f, -0.4998901f),
            new Vector2(0.2547029f, -0.4401813f),
            new Vector2(0.4452141f, 0.2218923f),
            new Vector2(0.5187018f, 0.3530247f)
        };
        _spearShape[1] = new Vector2[]
        {
            new Vector2(0.5501928f, 0.4678491f),
            new Vector2(0.4300057f, 0.3474422f),
            new Vector2(0.1482949f, -0.3934818f),
            new Vector2(0.1437018f, -0.4769253f),
            new Vector2(0.240924f, -0.4309953f),
            new Vector2(0.477365f, 0.2035204f),
            new Vector2(0.5462596f, 0.3208739f)
        };
        _spearShape[2] = new Vector2[]
        {
            new Vector2(0.5639718f, 0.4678491f),
            new Vector2(0.4483777f, 0.4483777f),
            new Vector2(0.1666668f, -0.3934818f),
            new Vector2(0.1712597f, -0.4815183f),
            new Vector2(0.2592959f, -0.4355882f),
            new Vector2(0.477365f, 0.2035204f),
            new Vector2(0.5462596f, 0.3208739f)
        };
        _spearShape[3] = new Vector2[]
        {
            new Vector2(-0.3770989f, -0.1326673f),
            new Vector2(-0.1891896f, -0.1847921f),
            new Vector2(-0.06578487f, -0.163833f),
            new Vector2(0.6397434f, -0.1508239f),
            new Vector2(0.6552386f, -0.08192903f),
            new Vector2(0.6319828f, -0.0848904f),
            new Vector2(-0.2391395f, -0.07871521f)
        };
        _spearShape[4] = new Vector2[]
        {
            new Vector2(-0.8951366f, -0.127097f),
            new Vector2(-0.4443005f, -0.235143f),
            new Vector2(-0.06578487f, -0.163833f),
            new Vector2(0.8377901f, -0.1508239f),
            new Vector2(0.8197181f, -0.1188529f),
            new Vector2(0.6689068f, -0.06810674f),
            new Vector2(-0.3802068f, -0.01294208f)
        };
        _spearShape[5] = new Vector2[]
        {
            new Vector2(-0.8338196f, -0.1301629f),
            new Vector2(-0.6527786f, -0.1860893f),
            new Vector2(-0.5256631f, -0.1668988f),
            new Vector2(0.187829f, -0.1416263f),
            new Vector2(0.1942838f, -0.09126025f),
            new Vector2(-0.5175788f, -0.08037016f),
            new Vector2(-0.6254751f, -0.06812739f),
        };
    }
}
