using TMPro;
using UnityEngine;

public class PoiHide : MonoBehaviour
{
    public GameObject poiButton;

    public void HideText()
    {
        poiButton.SetActive(true);
        this.gameObject.GetComponent<MeshCollider>().enabled = false;
        this.gameObject.GetComponent<Animator>().SetTrigger("disable");
    }

    public void ShowText()
    {
        poiButton.SetActive(false);
        this.gameObject.GetComponent<MeshCollider>().enabled = true;
        this.gameObject.GetComponent<Animator>().SetTrigger("enable");
    }
}
