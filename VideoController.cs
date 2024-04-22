using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public float[] stopPoints;
    public float[] jumpPoints;
    public float[] soundPoints;
    public GameObject[] audioClips;
    public int pointCursor;
    public ButtonListener btnListener;
    public GameObject loadingScreen;
    public float setVolume = 1f;

    VideoManager s_Vm;
    bool videoPlaying= true;


    void CheckForPause()
    {
        float videoTime= s_Vm.GetTime();
        if (videoTime >= stopPoints[pointCursor] && videoTime <= stopPoints[pointCursor]+2f)
        {
            s_Vm.Pause();
            loadingScreen.SetActive(true);
        }
    }

    void CheckForStart()
    {
        if (btnListener.StartVideo(pointCursor-1)) 
        {
            if (pointCursor>2) SceneManager.LoadScene(1);
            else Continue();
        }
    }

    public float JumpTo()
    {
        videoPlaying= false;
        pointCursor+= 1;
        return jumpPoints[pointCursor-1];
    }

    public void Continue()
    {
        videoPlaying= true;
        s_Vm.Play();
    }

    void CheckSoundPlayer()
    {
        int counter = 0;
        float videoTime= s_Vm.GetTime();
        foreach (float timestamp in soundPoints)
        {
            if (videoTime > timestamp && videoTime < timestamp+1)
            {
                audioClips[counter].GetComponent<AudioSource>().volume = setVolume;
                audioClips[counter].GetComponent<AudioSource>().Play();
            }
            counter++;
        }
    }


    void Start()
    {
        s_Vm= GetComponent<VideoManager>();
    }

    void Update()
    {
        if (!videoPlaying) CheckForStart();
        else CheckForPause();

        CheckSoundPlayer();
    }

}
