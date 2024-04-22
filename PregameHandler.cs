using UnityEngine;

public class PregameHandler : MonoBehaviour
{
    public GameObject btnListener;
    public GameObject vManager;
    void Update()
    {
        if (btnListener.GetComponent<ButtonListener>().StartGame())
        {
            vManager.GetComponent<VideoManager>().Play();
            gameObject.SetActive(false);
        }
    }
}
