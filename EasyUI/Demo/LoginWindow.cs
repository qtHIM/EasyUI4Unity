using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginWindow : BaseWindow {
    public GameObject loginBtn;
    public InputField account;
    public Text accountTxt;
    public InputField password;
    public Text passwordTxt;
    public Text btnTxt;

    public override void OnAwake()
    {
        InitComponent();
    }

    private void InitComponent()
    {
        EventRegister.Get(loginBtn).onClick += LoginBtnClick;

        AddLangComponent("account", accountTxt.gameObject, "Component.Login.Account");
        AddLangComponent("password", passwordTxt.gameObject, "Component.Login.Password");
        AddLangComponent("login", btnTxt.gameObject, "Component.Login.Login");
    }

    private void LoginBtnClick(GameObject obj)
    {
        if ("123" != account.text || "123" != password.text)
        {
            Debug.Log(LangUtil.Ins.GetLang("Login.PasswordError"));
        }
        else
        {
            Debug.Log(LangUtil.Ins.GetLang("Login.EnterGame"));
            SceneManager.LoadScene("Game Scene");
        }
    }

}
