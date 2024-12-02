using RicePaste.Scripts.Weapons;
using UnityEngine;

namespace RicePaste.Scripts.Players
{
    public class Wall : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other.tag);
            if(other.CompareTag("Weapon"))
            {
                other.gameObject.SetActive(false);
                other.GetComponent<Arrow>().currentCount = 0;
            }
            else
            {
                return;
            }
        }
    }   
}
