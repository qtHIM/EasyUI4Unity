using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeWindow : BaseWindow {
    public Text title;
    public GameObject enterBtn;
    public Text btnTxt;
    public GameObject langBtn;
    public Text langTxt;

    public override void OnAwake()
    {
        InitComponent();
    }


    private void InitComponent()
    {
        EventRegister.Get(enterBtn).onClick += 
            (GameObject obj) => {
                Show("LoginWindow");
            };
        EventRegister.Get(langBtn).onClick += LangBtnClick;

        AddLangComponent("title", title.gameObject, "Component.Welcome.Title");
        AddLangComponent("enter", btnTxt.gameObject, "Component.Welcome.Enter");
        AddLangComponent("lang", langTxt.gameObject, "Component.Welcome.ChangLang");
    }

    private void LangBtnClick(GameObject go)
    {
        if (LangUtil.Ins.lang == LangType.en)
        {
            LangUtil.Ins.LangChange(LangType.zh);
        }
        else
        {
            LangUtil.Ins.LangChange(LangType.en);
        }
    }

}
