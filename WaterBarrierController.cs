using UnityEngine;

public class WaterBarrierController : MonoBehaviour
{
    public VideoManager videoManager;
    public VideoController videoController;
    public InteractivesController interactivesController;

    void DisableSelf()
    {
        gameObject.SetActive(false);
    }

    void SetNewVideoLocation()
    {
        interactivesController.SetInteractive(videoController.pointCursor, true);
        videoManager.ForceTime(videoController.JumpTo());
    }
}
