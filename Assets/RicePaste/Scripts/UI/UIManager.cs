using System;
using UnityEngine;
namespace RicePaste.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        public Canvas canvas;

        public ESCUI escui;
        public PassUI passUI;
        private void Update()
        {
            if (Input.GetKeyDown("escape"))
            {
                escui.EscUI();
            }
        }
    }
}