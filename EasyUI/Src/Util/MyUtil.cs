using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUtil {

    public static void SetConfigs(string content, Dictionary<string,string> dic)
    {
        dic.Clear();
        if (content.Trim().Length > 0)
        {
            content = content.Trim().Replace("\r\n", "\n");
            string[] configs = content.Split('\n');
            string line, tKey;
            string[] singleWord;
            for (int i = 0; i < configs.Length; i++)
            {
                line = configs[i];
                if (line.Trim().Length > 0)
                {
                    singleWord = line.Split('=');
                    tKey = singleWord[0];
                    if (!dic.ContainsKey(tKey))
                    {
                        if (singleWord.Length == 2)
                            dic.Add(tKey, singleWord[1]);
                        else if (singleWord.Length > 2)
                            dic.Add(tKey, line.Substring(line.IndexOf("=")+1));
                    }
                }
            }
        }
    }







}
