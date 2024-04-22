using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    VideoPlayer videoPlayer;
    public float startTime;
    public bool pauseAtAwake = false;


    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        if (pauseAtAwake) Invoke("Pause", .1f);
        Invoke("SetStartime", .1f);
    }

    void SetStartime()
    {
        videoPlayer.time += startTime;
    }

    public void Play()
    {
        videoPlayer.Play();
    }

    public void Pause()
    {
        videoPlayer.Pause();
    }

    public void Stop()
    {
        videoPlayer.Stop();
    }

    public void SetTime(float time)
    {
        Play();
        videoPlayer.time += time;
        Pause();
    }

    public void ForceTime(float time)
    {
        videoPlayer.time = time;
    }

    public float GetTime()
    {
        return (float)videoPlayer.time;
    }
}
