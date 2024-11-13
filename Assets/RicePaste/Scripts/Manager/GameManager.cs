using UnityEngine;
using RicePaste.Scripts.Players;
namespace RicePaste.Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public float gameTime;
        public float maxGameTime = 2 * 10f;
    
        public Player player;
        public GameObject center;
        public PoolManager poolManager;

        private void Awake()
        {
            Instance = this;
            // Cursor.visible = false;
        }

        void Update()
        {
            gameTime += Time.deltaTime;

            if (gameTime > maxGameTime)
            {
                gameTime = maxGameTime;
            }
        }
    }
}

