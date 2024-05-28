using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace webgl.debug
{
    public class DebugButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _buttonText;
        [SerializeField] private Button _button;

        public void Construct(string name, string buttonText, UnityAction action)
        {
            _name.text = name;
            _buttonText.text = buttonText;
            _button.onClick.AddListener(action);
        }
    }
}
