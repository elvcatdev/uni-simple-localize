using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using archieSakai.UniSimpleLocalize;

namespace archieSakai.UniSimpleLocalize
{
    public class LangSwitcher : MonoBehaviour
    {
        [SerializeField] UniSimpleLocalizeController SimpleLocalizeManager = null;
        private Dropdown dropdown = null;

        private void Start()
        {
            dropdown = GetComponent<Dropdown>();
            if (dropdown != null)
            {
                dropdown.ClearOptions();
                List<string> list = new List<string>();
                for (int i = 0; i < SimpleLocalizeManager.langs.Count; i++)
                {
                    list.Add(SimpleLocalizeManager.langs[i].ToString());
                }
                dropdown.AddOptions(list);
                dropdown.value = SimpleLocalizeManager.langs.IndexOf(SimpleLocalizeManager.GetSelectedLang());
                dropdown.onValueChanged.AddListener(delegate {
                    DropdownValueChanged(dropdown);
                });

                dropdown.value = SimpleLocalizeManager.langs.IndexOf(SimpleLocalizeManager.GetSelectedLang()) >= 0
                    ? SimpleLocalizeManager.langs.IndexOf(SimpleLocalizeManager.GetSelectedLang())
                    : 0;
            }
        }

        private void DropdownValueChanged(Dropdown change)
        {
            SimpleLocalizeManager.SetSelectedLang(SimpleLocalizeManager.langs[change.value]);
            ApplyToImage[] images = FindObjectsOfType(typeof(ApplyToImage)) as ApplyToImage[];
            foreach (ApplyToImage img in images)
            {
                img.Apply();
            }
            ApplyToText[] texts = FindObjectsOfType(typeof(ApplyToText)) as ApplyToText[];
            foreach (ApplyToText txt in texts)
            {
                txt.Apply();
            }
        }
    }
}
