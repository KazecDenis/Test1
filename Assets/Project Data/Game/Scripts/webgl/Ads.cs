using System;
using UnityEngine;

namespace webgl
{
    public class Ads : MonoBehaviour
    {
        public static Ads Instance;
        private float _cooldown = 0;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        private void Update()
        {
            _cooldown += Time.unscaledDeltaTime;
        }

        public void ShowReward(Action onComplete)
        {
        }

        public void ShowInterstitial()
        {
            if (_cooldown < 60) return;
            _cooldown = 0;
        }
    }
}