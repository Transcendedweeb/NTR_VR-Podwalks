using UnityEngine;

public class GlobalsHolder : MonoBehaviour
{
    public int startTime = 0;
    public int pointer = 0;
    public bool playVideo = false;

    public float volumeClip;
    public float volumeBg;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Beginning()
    {
        startTime= 0;
        pointer= 0;
        playVideo= false;
    }

    public void Chapter1()
    {
        startTime= 44;
        pointer= 0;
        playVideo= true;
    }

    public void Chapter2()
    {
        startTime= 109;
        pointer= 1;
        playVideo= true;
    }

    public void Chapter3()
    {
        startTime= 139;
        pointer= 2;
        playVideo= true;
    }
}
