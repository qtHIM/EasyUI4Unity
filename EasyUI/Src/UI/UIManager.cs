using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public string winPath = "EasyUI/Src";
    public static UIManager Ins;
    private Dictionary<string, string> winPathDic = new Dictionary<string, string>();
    private Dictionary<string, BaseWindow> winDic = new Dictionary<string, BaseWindow>();

    private Loader loader;

    private void Awake()
    {
        Ins = this;
        loader = new ResourceLoader();
        InitSetting();
    }

    private void InitSetting()
    {
        TextAsset winPathTxt = loader.Load<TextAsset>(winPath, "winPath");
        MyUtil.SetConfigs(winPathTxt.text, winPathDic); 
    }
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="name"></param>
    public BaseWindow ShowWindow(string name)
    {
        BaseWindow window = null;
        if(winDic.TryGetValue(name,out window))
        {
            ActiveWindow(window);
            if (window.OnActive != null) window.OnActive();
        }
        else
        {
            window = LoadWindow(name);
            winDic[name] = window;
            ActiveWindow(window);
        }
        window.windowName = name;
        if (window.OnShow != null) window.OnShow();
        return window;
    }

    public BaseWindow HideWindow(string name)
    {
        BaseWindow window = null;
        if (winDic.TryGetValue(name, out window))
        {
            if (window.OnHide != null) window.OnHide(); 
            window.gameObject.SetActive(false);
        }
        return window;
    }

    public void RemoveWindow(string name)
    {
        winDic.Remove(name);
    }

    /// <summary>
    /// 激活窗口，并且显示在最上层
    /// </summary>
    /// <param name="window"></param>
    public void ActiveWindow(BaseWindow window)
    {
        GameObject root = GameObject.FindGameObjectWithTag("UIRoot");
        window.transform.SetParent(root.transform);
        window.transform.SetAsLastSibling();
        window.transform.localPosition = Vector3.zero;
        window.gameObject.SetActive(true);
    }

    private BaseWindow LoadWindow(string name)
    {
        string path = null;
        GameObject root = GameObject.FindGameObjectWithTag("UIRoot");
        if (winPathDic.TryGetValue(name,out path))
        {
            GameObject prefab = loader.Load<GameObject>(path);
            BaseWindow window = Instantiate(prefab, root.transform).GetComponent<BaseWindow>();
            window.gameObject.SetActive(false);
            return window;
        }
        throw new System.Exception("没有找到【"+name+"】窗口！");
    }

    public void Refresh()
    {
        foreach (BaseWindow win in winDic.Values)
        {
            win.Refresh();
        }
    }


}
