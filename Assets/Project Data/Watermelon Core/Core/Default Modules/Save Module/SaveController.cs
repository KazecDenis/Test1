using System;
using System.Collections;
using UnityEngine;
using webgl;

namespace Watermelon
{
    public static class SaveController
    {
        private const Serializer.SerializeType SAVE_SERIALIZE_TYPE = Serializer.SerializeType.Binary;
        private const string SAVE_FILE_NAME = "save";
        private const int SAVE_DELAY = 30;

        private static GlobalSave globalSave;

        private static bool isSaveLoaded;
        public static bool IsSaveLoaded => isSaveLoaded;

        private static bool isSaveRequired;

        public static int LevelId { get => globalSave.LevelId; set => globalSave.LevelId = value; }
        public static float GameTime => globalSave.GameTime;

        public static DateTime LastExitTime => globalSave.LastExitTime;

        public static event SimpleCallback OnSaveLoaded;
        private static string tempSaveFileName;

        public static void Initialise(bool useAutoSave, bool clearSave = false, float overrideTime = -1f)
        {
            if (clearSave)
            {
                InitClear(overrideTime != -1f ? overrideTime : Time.time);
            }
            else
            {
                Load(overrideTime != -1f ? overrideTime : Time.time);
            }

            if (useAutoSave)
            {
                // Enable auto-save coroutine
                Tween.InvokeCoroutine(AutoSaveCoroutine());
            }
        }

        public static void UpdateTime(float time)
        {
            globalSave.Time = time;
        }

        public static T GetSaveObject<T>(int hash) where T : ISaveObject, new()
        {
            if (!isSaveLoaded)
            {
                Debug.LogError("Save controller has not been initialized");
                return default;
            }

            return globalSave.GetSaveObject<T>(hash);
        }

        public static T GetSaveObject<T>(string uniqueName) where T : ISaveObject, new()
        {
            return GetSaveObject<T>(uniqueName.GetHashCode());
        }

        private static void InitClear(float time)
        {
            globalSave = new GlobalSave();
            globalSave.Init(time);

            Debug.Log("[Save Controller]: Created clear save!");

            isSaveLoaded = true;
        }

        private static void Load(float time)
        {
            if (isSaveLoaded)
                return;

            // Try to read and deserialize file or create new one
            //globalSave = Serializer.DeserializeFromPDP<GlobalSave>(SAVE_FILE_NAME, SAVE_SERIALIZE_TYPE, logIfFileNotExists: false);
            globalSave = SaveLoad.Load(SAVE_FILE_NAME);

            globalSave.Init(time);

            Debug.Log("[Save Controller]: Save is loaded!");

            isSaveLoaded = true;

            OnSaveLoaded?.Invoke();
        }

        public static void Save()
        {
            if (!isSaveRequired)
                return;

            globalSave.Flush();
            SaveThreadFunction();
            // var saveThread = new Thread(SaveThreadFunction);
            // saveThread.Start();

            Debug.Log("[Save Controller]: Game is saved!");

            isSaveRequired = false;
        }

        public static void ForceSave()
        {
            //TODO: Save
            return;
            globalSave.Flush();
            SaveThreadFunction();
            // var saveThread = new Thread(SaveThreadFunction);
            // saveThread.Start();

            Debug.Log("[Save Controller]: Game is saved!");

            isSaveRequired = false;
        }

        private static void SaveThreadFunction()
        {
            SaveLoad.Save(globalSave, SAVE_FILE_NAME);
            //Serializer.SerializeToPDP(globalSave, SAVE_FILE_NAME, SAVE_SERIALIZE_TYPE);
        }

        public static void SaveCustom(GlobalSave globalSave)
        {
            //TODO: Save
            return;
            if(globalSave != null)
            {
                globalSave.Flush();
                SaveLoad.Save(globalSave, SAVE_FILE_NAME);
                //Serializer.SerializeToPDP(globalSave, SAVE_FILE_NAME, SAVE_SERIALIZE_TYPE);
            }
        }

        public static void MarkAsSaveIsRequired()
        {
            isSaveRequired = true;
        }

        private static IEnumerator AutoSaveCoroutine()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(SAVE_DELAY);

            while (true)
            {
                yield return waitForSeconds;

                Save();
            }
        }

        public static void PresetsSave(string fullFileName)
        {
            globalSave.Flush();

            tempSaveFileName = fullFileName;
            PresetsSaveThreadFunction();
            // var saveThread = new Thread(PresetsSaveThreadFunction);
            // saveThread.Start();
        }

        private static void PresetsSaveThreadFunction()
        {
            SaveLoad.Save(globalSave, tempSaveFileName);
            //Serializer.SerializeToPDP(globalSave, tempSaveFileName, SAVE_SERIALIZE_TYPE);
        }

        public static void Info()
        {
            globalSave.Info();
        }

        public static void DeleteSaveFile()
        {
            Serializer.DeleteFileAtPDP(SAVE_FILE_NAME);
        }

        public static GlobalSave GetGlobalSave()
        {
            //GlobalSave tempGlobalSave = Serializer.DeserializeFromPDP<GlobalSave>(SAVE_FILE_NAME, SAVE_SERIALIZE_TYPE, logIfFileNotExists: false);
            GlobalSave tempGlobalSave = SaveLoad.Load(SAVE_FILE_NAME);

            tempGlobalSave.Init(Time.time);

            return tempGlobalSave;
        }
    }
}