using UnityEngine;
using RicePaste.Scripts.Players;
using RicePaste.Scripts.UI;

namespace RicePaste.Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        
        public UIManager uiManager;
        [Header("# Game Control")]
        public float gameTime;
        public float maxGameTime = 2 * 10f;
        
        [Header("# Game Object")]
        public Player player;
        public PoolManager poolManager;

        [Header("# Player Info")] 
        public int health;
        public int maxHealth = 100;
        public int level;
        public int kill;
        public int exp;
        public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600};

        public int count;
        private void Awake()
        {
            instance = this;
            // Cursor.visible = false;
        }

        private void Start()
        {
            health = maxHealth;
        }

        void Update()
        {
            gameTime += Time.deltaTime;

            if (gameTime > maxGameTime)
            {
                gameTime = maxGameTime;
            }
        }

        public void GetExp()
        {
            exp++;

            if (exp == nextExp[level])
            {
                level++;
                exp = 0;
                ++player.statusPoint;
            }
        }
    }
}

