using Newtonsoft.Json;
using UnityEngine;
using Watermelon;

namespace webgl
{
    public class SaveLoad : MonoBehaviour
    {
        public static SaveLoad Instance;

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
            }
        }

        public static void Save(GlobalSave globalSave, string fileName)
        {
            var json = JsonConvert.SerializeObject(globalSave);
            Debug.Log($"Save {fileName}: {json}");
            PlayerPrefs.SetString("globalSave_" + fileName, json);
        }

        public static GlobalSave Load(string fileName)
        {
            var json = PlayerPrefs.GetString("globalSave_" + fileName, "");
            Debug.Log($"Load {fileName}: {json}");
            if (json == "") return new GlobalSave();
            return JsonConvert.DeserializeObject<GlobalSave>(json);
        }
        
        public static void SaveT<T>(T obj, string key)
        {
            var json = JsonConvert.SerializeObject(obj);
            PlayerPrefs.SetString(key, json);
        }

        public static T LoadT<T>(string key) where T : new()
        {
            var json = PlayerPrefs.GetString(key, "");
            if (json == "") return new T();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
