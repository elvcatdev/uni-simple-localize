using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using archieSakai.UniSimpleLocalize;

namespace archieSakai.UniSimpleLocalize
{
    [ExecuteInEditMode()]
    public class ApplyToImage : MonoBehaviour
    {
        private Image thisImage = null;
        public UniSimpleLocalizeController langData = null;
        public List<Sprite> langSpriteList = new List<Sprite>();
        public Sprite defaultSprite = null;

        private void Awake()
        {
            thisImage = GetComponent<Image>();
            Apply();
        }

        public void Apply()
        {
            thisImage.sprite = langData.langs.IndexOf(langData.GetSelectedLang()) >= 0
                ? langSpriteList[langData.langs.IndexOf(langData.GetSelectedLang())]
                : defaultSprite;
        }
    }
}
