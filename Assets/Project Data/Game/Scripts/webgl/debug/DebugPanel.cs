using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace webgl.debug
{
    public class DebugPanel : MonoBehaviour
    {
        public static DebugPanel Instance;
        
        private const string DebugButtonPath = "DebugButton";
        
        [SerializeField] private Button _visibleButton;
        private DebugButton _buttonPrefab;

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(transform.parent.gameObject);
            }
            else
            {
                Destroy(transform.parent.gameObject);
                return;
            }
            
            Init();
        }

        public void Init()
        {
            _visibleButton.onClick.AddListener(ChangeVisible);
            _buttonPrefab = Resources.Load<DebugButton>(DebugButtonPath);
            AddButtons();
        }

        public void AddButton(string name, string buttonText, UnityAction action)
        {
            var button = Instantiate(_buttonPrefab, transform);
            button.name = name;
            button.Construct(name, buttonText, action);
        }

        private void ChangeVisible()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        private void AddButtons()
        {
            // AddButton("Money", "+1000", () => PlayerData.g_money += 1000);
            // AddButton("Gem", "+100", () => PlayerData.g_gem += 100);
            // AddButton("Wave in game", "Add", () => PlayerData.levelInGame++);
            // AddButton("Map level", "Add", () =>
            // {
            //     PlayerData.mapLevel++;
            //     MirraSDK.Prefs.SetInt("mapLevel", PlayerData.mapLevel);
            // });
            // AddButton("Save", "Reset", () =>
            // {
            //     MirraSDK.Prefs.DeleteAll();
            //     Application.Quit();
            // });
        }
    }
}
