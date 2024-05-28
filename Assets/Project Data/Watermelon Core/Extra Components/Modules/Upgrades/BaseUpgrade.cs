using System;
using UnityEngine;
using webgl;

namespace Watermelon.Upgrades
{
    public abstract class BaseUpgrade : ScriptableObject, IUpgrade
    {
        private string _hash;
        
        [SerializeField]
        protected UpgradeType upgradeType;
        public UpgradeType UpgradeType => upgradeType;

        [SerializeField]
        protected string title;
        public string Title => title;

        public int UpgradeLevel { get => save.UpgradeLevel; set => save.UpgradeLevel = value; }

        [NonSerialized]
        protected UpgradeSavableObject save;

        public abstract BaseUpgradeStage[] Upgrades { get; }
        public int UpgradesCount => Upgrades.Length;
        public bool IsMaxedOut => UpgradeLevel + 1 >= UpgradesCount;

        public BaseUpgradeStage CurrentStage => Upgrades[UpgradeLevel];
        public BaseUpgradeStage NextStage => Upgrades.Length > UpgradeLevel + 1 ? Upgrades[UpgradeLevel + 1] : null;

        public abstract void Initialise();
        public abstract void UpgradeStage();

        public event SimpleCallback OnUpgraded;

        protected void InvokeOnUpgraded()
        {
            OnUpgraded?.Invoke();
            SaveLoad.SaveT(save, _hash);
        }

        public int GetUpgradeCost(int level)
        {
            if (level >= Upgrades.Length)
                return -1;

            var upgradeStage = Upgrades[level];

            return upgradeStage.Price;
        }

        public virtual void SetSave(UpgradeSavableObject save, string hash)
        {
            this.save = save;
            _hash = hash;
        }

        public virtual void ResetUpgrade()
        {
            UpgradeLevel = 0;

            InvokeOnUpgraded();
        }
    }
}