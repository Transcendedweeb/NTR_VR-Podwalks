using TMPro;
using UnityEngine;

public class SetVolumeSettingsText : MonoBehaviour
{
    public bool clip = true;
    public GlobalsHolder globals;
    TextMeshPro text;

    public void SetText(float value)
    {
        float set = value;;
        text.text = set.ToString();
    }

    void Start()
    {
        globals = GameObject.Find("GlobalsPlaceholder").GetComponent<GlobalsHolder>();
        text = GetComponent<TextMeshPro>();

        if (clip) SetText(globals.volumeClip);
        else SetText(globals.volumeBg);
    }
}
