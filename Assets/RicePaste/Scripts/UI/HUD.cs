using System;
using RicePaste.Scripts.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace RicePaste.Scripts.UI
{
    public class HUD : MonoBehaviour
    {
        public enum InfoType
        {
            Exp,
            Level,
            Status,
            Kill,
            Time,
            Health
        }

        public InfoType type;

        private Text _myText;
        private Slider _mySlider;

        private void Awake()
        {
            _myText = GetComponent<Text>();
            _mySlider = GetComponent<Slider>();
        }

        private void LateUpdate()
        {
            switch (type)
            {
                case InfoType.Exp:
                    float currentExp = GameManager.instance.exp;
                    float maxExp = GameManager.instance.nextExp[GameManager.instance.level];
                    _mySlider.value = currentExp / maxExp;
                    break;
                case InfoType.Level:
                    _myText.text = string.Format("Lv.{0:F0}", GameManager.instance.level);
                    break;
                case InfoType.Status:
                    _myText.text = string.Format("{0:F0}pt", GameManager.instance.player.statusPoint);
                    break;
                case InfoType.Kill:
                    _myText.text = string.Format("X {0:F0}", GameManager.instance.kill);
                    break;
                case InfoType.Time:
                    float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
                    int minutes = Mathf.FloorToInt(remainTime / 60);
                    int seconds = Mathf.FloorToInt(remainTime % 60);
                    _myText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
                    break;
                case InfoType.Health:
                    float currentHealth = GameManager.instance.health;
                    float maxHealth = GameManager.instance.maxHealth;
                    _mySlider.value = currentHealth / maxHealth;
                    break;
            }
        }
    }
}

