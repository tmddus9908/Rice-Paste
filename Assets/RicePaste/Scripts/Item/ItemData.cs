using UnityEngine;


namespace RicePaste.Scripts.Item
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/ItemData")]
    public class ItemData : ScriptableObject
    {
        public enum ItemType{ Melee, Range, Shoe, Rotation}
        
        [Header("# Main Info")]
        public ItemType itemType;
        public string itemName;
        public string itemDesc;
        public Sprite itemIcon;

        [Header("# Level Data")] 
        public float baseDamage;
        public int baseCount;
        public float baseKnockback;
        public float baseRange;
        public Vector3 baseScale;
        public float baseCooldown;
        public float[] damages;
        public int[] counts;
        public float[] knockbacks;
        public float[] ranges;
        public float[] scales;
        public float[] cooldowns;
        public float[] playerSpeeds;
    }
    
}
