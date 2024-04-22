using System;
using UnityEngine;

public class GetSoundValues : MonoBehaviour
{
    public bool clipVolume = true;
    public bool add = true;
    public GlobalsHolder globals;
    public SetVolumeSettingsText text;
    float newValue;
    
    public void PassFlags()
    {
        if (add) Plus();
        else Minus();
    }

    void Minus()
    {
        if(clipVolume)
        {
            if (globals.volumeClip > 0f) 
            {
                newValue = globals.volumeClip;
                newValue -= 0.1f;
                newValue = (float)Math.Round(newValue, 1);
                globals.volumeClip = newValue;
                text.SetText(newValue);
            }
        }

        else
        {
            if (globals.volumeBg > 0f)
            {
                newValue = globals.volumeBg;
                newValue -= 0.1f;
                newValue = (float)Math.Round(newValue, 1);
                globals.volumeBg = newValue;
                text.SetText(newValue);
            }
        }
    }

    void Plus()
    {
        if(clipVolume)
        {
            if (globals.volumeClip < 1f) 
            {
                newValue = globals.volumeClip;
                newValue += 0.1f;
                newValue = (float)Math.Round(newValue, 1);
                globals.volumeClip = newValue;
                text.SetText(newValue);
            }
        }

        else
        {
            if (globals.volumeBg < 1f)
            {
                newValue = globals.volumeBg;
                newValue += 0.1f;
                newValue = (float)Math.Round(newValue, 1);
                globals.volumeBg = newValue;
                text.SetText(newValue);
            }
        }
    }

    void Start()
    {
        globals = GameObject.Find("GlobalsPlaceholder").GetComponent<GlobalsHolder>();
        if (clipVolume) newValue = globals.volumeClip;
        else newValue = globals.volumeBg;
    }
}
