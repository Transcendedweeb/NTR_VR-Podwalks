using UnityEngine;

public class GetGlobals : MonoBehaviour
{
    public GameObject preGame;
    public GameObject bgSound;
    public GlobalsHolder globalsHolder;
    VideoManager vManager;
    VideoController vController;


    void SetGlobals()
    {
        vManager.startTime = globalsHolder.startTime;
        vManager.pauseAtAwake = globalsHolder.playVideo;
        vController.pointCursor = globalsHolder.pointer;
        bgSound.GetComponent<AudioSource>().volume = globalsHolder.volumeBg;
        vController.setVolume = globalsHolder.volumeClip;

        if (vManager.startTime == 0) 
        {
            preGame.SetActive(true);
            Invoke("RunVideo", .5f);
        }
        else
        {
            preGame.SetActive(false);
            Invoke("RunVideo", .5f);
        }
    }

    void RunVideo()
    {
        if (globalsHolder.playVideo) vManager.Play();
        else vManager.Pause();
    }


    void Start()
    {
        globalsHolder = GameObject.Find("GlobalsPlaceholder").GetComponent<GlobalsHolder>();
        vManager = this.gameObject.GetComponent<VideoManager>();
        vController = this.gameObject.GetComponent<VideoController>();
        SetGlobals();
    }
}
