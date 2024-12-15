using RicePaste.Scripts.Item;
using RicePaste.Scripts.Manager;
using RicePaste.Scripts.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace RicePaste.Scripts.UI
{
    public class Item : MonoBehaviour
    {
        public ItemData data;
        public int level;
        public GameObject weapon;

        private Image _icon;
        private Text _textLevel;

        private void Awake()
        {
            _icon = GetComponentsInChildren<Image>()[1];
            _icon.sprite = data.itemIcon;
            
            Text[] texts = GetComponentsInChildren<Text>();
            _textLevel = texts[0];
        }

        private void LateUpdate()
        {
            _textLevel.text = "Lv." + (level + 1);
        }

        public void OnClick()
        {
            if (GameManager.instance.player.statusPoint >= 1)
            {
                switch (data.itemType)
                {
                    case ItemData.ItemType.Melee:
                        var obj1 = weapon.GetComponent<Weapon>();
                        if (GameManager.instance.player.equippedWeapon != obj1 )
                            return;
                        obj1.SetMeleeWeaponStatus((obj1.knockBack + data.knockbacks[level]),
                            (obj1.damage + data.damages[level]), (obj1.radius + data.ranges[level]),
                            (data.baseScale * data.scales[level]), (data.baseCooldown - data.cooldowns[level]));
                        break;
                    case ItemData.ItemType.Range:
                        var bow = weapon.GetComponent<PlayerBow>();
                        var obj2 = weapon.GetComponent<Weapon>();
                        if (GameManager.instance.player.equippedWeapon != obj2 )
                            return;
                        bow.SetRangeWeaponStatus((bow.knockBack + data.knockbacks[level]),
                            (bow.damage + data.damages[level]), (bow.radius + data.ranges[level]), 1,
                            (bow.arrowCount + data.counts[level])
                            , data.baseScale * data.scales[level], (data.baseCooldown - data.cooldowns[level]));
                        break;
                    case ItemData.ItemType.Rotation:
                        var obj3 = weapon.GetComponent<RotationWeapon>();
                        obj3.SetRotationWeaponStatus((obj3.damage + data.damages[level]),
                            (obj3.count + data.counts[level]), (obj3.knockback + data.knockbacks[level]));
                        break;
                    case ItemData.ItemType.Shoe:
                        GameManager.instance.player.moveSpeed += data.playerSpeeds[level];
                        break;
                }
                GameManager.instance.player.statusPoint--;

                level++;
                // Time.timeScale = 1;

                if (level == data.damages.Length)
                    GetComponent<Button>().interactable = false;
            }
        }
    }   
}
