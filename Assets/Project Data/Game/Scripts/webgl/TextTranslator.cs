using TMPro;
using UnityEngine;

namespace webgl
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextTranslator : MonoBehaviour
    {
        private static SystemLanguage CurrentLanguage = SystemLanguage.Russian;

        [SerializeField, TextArea] private string _en;
        [SerializeField, TextArea] private string _ru;
         
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            CurrentLanguage = SystemLanguage.Russian;
            SetText(_ru, _en, _text);
        }

        public static void SetText(string ru, string en, TMP_Text text)
        {
            text.text = GetText(ru, en);
        }

        public static string GetText(string ru, string en)
        {
            return CurrentLanguage is SystemLanguage.English ? en : ru;
        }
    }
}
