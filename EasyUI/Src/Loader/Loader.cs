using System;
using System.Collections.Generic;
using UnityEngine;

public interface Loader
{
    T Load<T>(string path,string name) where T : UnityEngine.Object;
    T Load<T>(string pathName) where T : UnityEngine.Object;
}

public class ResourceLoader : Loader
{
    public T Load<T>(string path, string name)where T:UnityEngine.Object
    {
        return Load<T>(path + "/" + name);
    }

    public T Load<T>(string pathName) where T : UnityEngine.Object
    {
        T obj = Resources.Load<T>(pathName);
        return obj;
    }
}



