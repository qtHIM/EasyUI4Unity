using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LangComponent : MonoBehaviour {
    private Text text;
    [SerializeField]
    private string langId;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    public void SetLangId(string langId)
    {
        this.langId = langId;
        text.text = LangUtil.Ins.GetLang(langId);
    }

    public void UpdateLang()
    {
        if (langId != null||langId != string.Empty)
        {
            SetLangId(langId);
        }
    }


}
