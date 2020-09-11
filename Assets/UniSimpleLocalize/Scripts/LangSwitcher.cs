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
        [SerializeField] bool isShowNativeLavel = true;
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
                    list.Add(
                        isShowNativeLavel
                            ? MappingValueNam(SimpleLocalizeManager.langs[i])
                            : SimpleLocalizeManager.langs[i].ToString()
                        );
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

        private string MappingValueNam(SystemLanguage thisLandValue)
        {
            switch (thisLandValue)
            {
                case SystemLanguage.English:
                    return "English";
                case SystemLanguage.Japanese:
                    return "日本語";
                case SystemLanguage.ChineseSimplified:
                    return "中国语 简体字";
                case SystemLanguage.ChineseTraditional:
                    return "中国语 繁體字";
                case SystemLanguage.Chinese:
                    return "中国语";
                case SystemLanguage.Afrikaans:
                    return "Afrikane";
                case SystemLanguage.Arabic:
                    return "عربى";
                case SystemLanguage.Basque:
                    return "Euskara";
                case SystemLanguage.Belarusian:
                    return "Беларуская";
                case SystemLanguage.Bulgarian:
                    return "български";
                case SystemLanguage.Catalan:
                    return "Català";
                case SystemLanguage.Czech:
                    return "Český jazyk";
                case SystemLanguage.Danish:
                    return "dansk";
                case SystemLanguage.Dutch:
                    return "Nederlands";
                case SystemLanguage.Estonian:
                    return "Eestlane";
                case SystemLanguage.Faroese:
                    return "Føroyskt";
                case SystemLanguage.Finnish:
                    return "Suomen kieli, Suomi";
                case SystemLanguage.French:
                    return "français";
                case SystemLanguage.German:
                    return "Deutsch";
                case SystemLanguage.Greek:
                    return "Ελληνικά";
                case SystemLanguage.Hebrew:
                    return "עברית";
                case SystemLanguage.Hungarian:
                    return "magyar nyelv";
                case SystemLanguage.Icelandic:
                    return "íslenska";
                case SystemLanguage.Indonesian:
                    return "Bahasa Indonesia";
                case SystemLanguage.Italian:
                    return "Italiano";
                case SystemLanguage.Korean:
                    return "조선말";
                case SystemLanguage.Latvian:
                    return "Latviešu";
                case SystemLanguage.Lithuanian:
                    return "lietuvių kalba";
                case SystemLanguage.Norwegian:
                    return "norsk";
                case SystemLanguage.Polish:
                    return "język polski";
                case SystemLanguage.Portuguese:
                    return "Português";
                case SystemLanguage.Romanian:
                    return "limba română";
                case SystemLanguage.Russian:
                    return "русский язык";
                case SystemLanguage.SerboCroatian:
                    return "srpskohrvatski / српскохрватски";
                case SystemLanguage.Slovak:
                    return "Slovenčina";
                case SystemLanguage.Slovenian:
                    return "slovenščina";
                case SystemLanguage.Spanish:
                    return "español";
                case SystemLanguage.Swedish:
                    return "svenska";
                case SystemLanguage.Thai:
                    return "ภาษาไทย";
                case SystemLanguage.Turkish:
                    return "Türkçe";
                case SystemLanguage.Ukrainian:
                    return "українська мова";
                case SystemLanguage.Vietnamese:
                    return "Tiếng Việt";
                case SystemLanguage.Unknown:
                default:
                    return thisLandValue.ToString();
            }
        }
    }
}
