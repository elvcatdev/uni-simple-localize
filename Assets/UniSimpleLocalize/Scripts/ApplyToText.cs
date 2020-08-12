using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using archieSakai.UniSimpleLocalize;

namespace archieSakai.UniSimpleLocalize
{
    public class ApplyToText : MonoBehaviour
    {
        private Text thisText = null;
        public UniSimpleLocalizeController langData = null;
        public List<string> langStrList = new List<string>();
        public string defaultText = null;

        private void Awake()
        {
            thisText = GetComponent<Text>();
            Apply();

        }

        public void Apply()
        {
            thisText.text = langData.langs.IndexOf(langData.GetSelectedLang()) >= 0
                ? langStrList[langData.langs.IndexOf(langData.GetSelectedLang())]
                : defaultText;
        }
    }
}
