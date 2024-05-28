using UnityEngine;
using webgl;

namespace Watermelon.SquadShooter
{
    [System.Serializable]
    public class RarityData
    {
        [SerializeField] Rarity rarity;
        public Rarity Rarity => rarity;

        [SerializeField] string name;
        [SerializeField] string nameRU;
        public string Name => TextTranslator.GetText(nameRU, name);

        [SerializeField] Color mainColor;
        public Color MainColor => mainColor;

        [SerializeField] Color textColor;
        public Color TextColor => textColor;
    }
}