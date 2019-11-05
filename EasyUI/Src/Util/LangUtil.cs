using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LangType { zh ,en}
public class LangUtil : MonoBehaviour {

    public LangType lang = LangType.zh;
    public string langPath = "EasyUI/Src";
    public static LangUtil Ins;
    private Dictionary<string, string> langDic = new Dictionary<string, string>();
    private Loader loader;

    private void Awake()
    {
        Ins = this;
        loader = new ResourceLoader();
        InitSetting();
    }

    private void InitSetting()
    {
        LangChange(lang);
    }

    public void LangChange(LangType lang)
    {
        string langFile = "zh_lang";
        this.lang = lang;
        if (lang == LangType.zh)
        {
            langFile = "zh_lang";
        }
        else if(lang == LangType.en)
        {
            langFile = "en_lang";
        }
        TextAsset langTxt = loader.Load<TextAsset>(langPath, langFile); 
        MyUtil.SetConfigs(langTxt.text, langDic);
        if (UIManager.Ins)
        {
            UIManager.Ins.Refresh();
        }
    }

    public string GetLang(string id)
    {
        string str = "";
        str = langDic[id];
        return str;
    }
}
