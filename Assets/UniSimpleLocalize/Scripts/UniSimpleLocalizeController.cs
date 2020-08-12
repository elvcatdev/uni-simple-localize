using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace archieSakai.UniSimpleLocalize
{
    [CreateAssetMenu(menuName = "UniSimpleLocalize/UniSimpleLocalizeController")]
    public class UniSimpleLocalizeController : ScriptableObject
	{
        public List<SystemLanguage> langs = new List<SystemLanguage>();
        private SystemLanguage selectedLang = SystemLanguage.English;
        private string DATA_KEY = "archieSakai.UniSimpleLocalize";

        private void Awake()
        {
            if (PlayerPrefs.HasKey(DATA_KEY))
            {
                UniSimpleLocalizeData prevData = ReadData();
                selectedLang = prevData.selectedLang;
            }
            else
            {
                selectedLang = Application.systemLanguage;
            }
        }

        public void SetSelectedLang(SystemLanguage nextLang)
        {
            selectedLang = nextLang;
            UniSimpleLocalizeData saveData = new UniSimpleLocalizeData
            {
                langs = langs,
                selectedLang = nextLang
            };
            SaveData(saveData);
        }

        public SystemLanguage GetSelectedLang()
        {
            return selectedLang;
        }

        private void SaveData(UniSimpleLocalizeData nextSaveData)
        {
            var json = JsonUtility.ToJson(nextSaveData);
            PlayerPrefs.SetString(DATA_KEY, json);
            PlayerPrefs.Save();
        }

        public UniSimpleLocalizeData ReadData()
        {
            var json = PlayerPrefs.GetString(DATA_KEY);
            var data = JsonUtility.FromJson<UniSimpleLocalizeData>(json);
            return data;
        }
    }

    [Serializable]
    public class UniSimpleLocalizeData
    {
        public List<SystemLanguage> langs;
        public SystemLanguage selectedLang;
    }
}
