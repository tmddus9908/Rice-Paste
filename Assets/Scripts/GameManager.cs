using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public Player player;
    public PoolManager poolManager;

    private void Awake()
    {
        Instance = this;
    }
}
