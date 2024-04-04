using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Code
{
    public class UIManager : MonoBehaviour
    {

        public Image WeaponAmmoes;
        
        
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