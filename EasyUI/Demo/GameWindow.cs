using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWindow : BaseWindow {
    public Text title;
    public Button logoutBtn;
    public Text logoutTxt;

    public override void OnAwake()
    {
        InitComponent();
    }

    private void InitComponent()
    {
        EventRegister.Get(logoutBtn.gameObject).onClick += LogoutBtnClick;

        AddLangComponent("title", title.gameObject, "Component.Game.Title");
        AddLangComponent("logout", logoutTxt.gameObject, "Component.Game.Logout");
      
    }

    private void LogoutBtnClick(GameObject obj)
    {
        SceneManager.LoadScene("Main Scene");
    }

}
