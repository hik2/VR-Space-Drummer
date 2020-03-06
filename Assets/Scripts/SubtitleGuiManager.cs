using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubtitleGuiManager : MonoBehaviour
{
    public TextMeshProUGUI textBox;

    public void Clear()
    {
        textBox.text = string.Empty;
    }
    
    public void SetText(string text)
    {
        textBox.text = text;
    }
}
