using UnityEngine;

public class DisableObjectInEditor : MonoBehaviour
{
    void Start()
    {
        #if UNITY_EDITOR
            gameObject.SetActive(false);
        #endif
    }
}
