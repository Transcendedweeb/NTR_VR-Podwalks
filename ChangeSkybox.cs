using UnityEngine;

public class ChangeSkybox : MonoBehaviour
{
    public Material mVideo;
    public Material mImage;


    void OnEnable()
    {
        RenderSettings.skybox = mImage;
        RenderSettings.skybox.SetFloat("_Rotation", 180f);
    }

    void OnDisable()
    {
        RenderSettings.skybox = mVideo;
        RenderSettings.skybox.SetFloat("_Rotation", 0f);
    }
}
