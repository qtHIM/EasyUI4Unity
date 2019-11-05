using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void WindowEvent();
public class BaseWindow : MonoBehaviour {
    public string windowName = "";
    private Dictionary<string,LangComponent> langComs = new Dictionary<string,LangComponent>();
    public WindowEvent OnShow;
    public WindowEvent OnActive;
    public WindowEvent OnHide;

    private void Awake()
    {
        OnAwake();
    }

    private  void Start()
    {
        OnStart();
    }

    private void OnEnable()
    {
        Refresh();
        OnWindowEnable();
    }

    private void OnDestroy()
    {
        UIManager.Ins.RemoveWindow(this.windowName);
        OnWindwoDestroy();
    }

    public BaseWindow Show(string name = "")
    {
        if (name == "")
        {
            return UIManager.Ins.ShowWindow(windowName);
        }
        else
        {
            return UIManager.Ins.ShowWindow(name);
        }
    }

    public BaseWindow Hide(string name = "")
    {
        if (name == "")
        {
            return UIManager.Ins.HideWindow(this.name);
        }
        else
        {
            return UIManager.Ins.HideWindow(windowName);
        }
    }

    public virtual void OnAwake() { }
    public virtual void OnStart() { }
    public virtual void OnWindwoDestroy() { }
    public virtual void OnWindowEnable() { }

    public void AddLangComponent(string name,GameObject obj,string langId)
    {
        LangComponent oldLangCom = null;
        if(langComs.TryGetValue(name,out oldLangCom))
        {
            oldLangCom.SetLangId(langId);
            return;
        }
        else
        {
            oldLangCom = obj.GetComponent<LangComponent>();
            if (oldLangCom == null)
            {
                oldLangCom = obj.AddComponent<LangComponent>();
            }
            oldLangCom.SetLangId(langId);
            langComs[name] = oldLangCom;
        }
    }

    public void RemoveLangComponent(string name)
    {
        LangComponent oldLangCom = null;
        if (langComs.TryGetValue(name, out oldLangCom))
        {
            Destroy(oldLangCom);
            return;
        }
    }

    public void Refresh()
    {
        if (this.gameObject.activeInHierarchy)
        {
            foreach (LangComponent component in langComs.Values)
            {
                component.UpdateLang();
            }
        }
    }

}

