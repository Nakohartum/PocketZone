using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Root.Code
{
    public class UIManager : MonoBehaviour
    {

        [Header("Weapon UI")]
        public Image CurrentAmmoBar;

        public TMP_Text AmmoText;
        
        
        private static UIManager _instance;
        public static UIManager Instance
        {
            get
            {
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}