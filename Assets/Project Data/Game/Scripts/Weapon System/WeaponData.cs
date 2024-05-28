using UnityEngine;
using Watermelon;
using webgl;

namespace Watermelon.SquadShooter
{
    [System.Serializable]
    public class WeaponData
    {
        [SerializeField] string name;
        [SerializeField] string nameRU;
        public string Name => TextTranslator.GetText(nameRU, name);

        [SerializeField] WeaponType type;
        public WeaponType Type => type;

        [SerializeField] UpgradeType upgradeType;
        public UpgradeType UpgradeType => upgradeType;

        [SerializeField] Rarity rarity;
        public Rarity Rarity => rarity;

        [SerializeField] Sprite icon;
        public Sprite Icon => icon;

        public RarityData RarityData => WeaponsController.GetRarityData(rarity);

        private WeaponSave save;
        public WeaponSave Save => save;

        public int CardsAmount => save.CardsAmount;

        public void Initialise()
        {
            //TODO:Save
            //save = SaveController.GetSaveObject<WeaponSave>(string.Format("Weapon_{0}", type));
            save = SaveLoad.LoadT<WeaponSave>($"Weapon_{type}");
        }
    }
}