using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    private Dictionary<string, string> lines = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    public string resourceFile = "subtitlesScript";

    public string GetText(string textKey)
    {
        string tmp = "";
        if (lines.TryGetValue(textKey, out tmp))
            return tmp;
        return string.Empty;
    }

    private void Awake()
    {
        var textAsset = Resources.Load<TextAsset>(resourceFile);
        var voText = JsonUtility.FromJson<VoiceoverText>(textAsset.text);

        foreach(var t in voText.lines)
        {
            lines[t.key] = t.line;
        }
    }
}
