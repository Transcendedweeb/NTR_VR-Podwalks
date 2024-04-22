using UnityEngine;

public class ButtonListener : MonoBehaviour
{
    const OVRInput.Button AButton = OVRInput.Button.One;
    const OVRInput.Button BButton = OVRInput.Button.Two;
    const OVRInput.Button XButton = OVRInput.Button.Three;
    const OVRInput.Button YButton = OVRInput.Button.Four;
    const OVRInput.Button l_IndexButton = OVRInput.Button.PrimaryIndexTrigger;
    const OVRInput.Button r_IndexButton = OVRInput.Button.SecondaryIndexTrigger;


    public GameObject hiddenPlaceholder;
    public GameObject showPlaceholder;
    public GameObject[] pointers;
    public VideoManager vManager;
    
    bool forcedPause = false;
    bool pointersActive = true;
    bool iActive= false;
    InteractivesController interactivesController;
    GameObject[] interactivePlaceholders;


    public void PointerCheck(string hand, string tag, GameObject hit)
    {
        if((hand == "L" && !OVRInput.GetDown(l_IndexButton)) || (hand == "R" && !OVRInput.GetDown(r_IndexButton))) return;

        if (tag == "TestCube")
        {
            hit.SetActive(false);
        }

        else if (tag == "helperHidden")
        {
            hiddenPlaceholder.GetComponent<HelpMenuAnimation>().TriggerFadeOut();
            Invoke("ShowHelperPlaceHolder", 1f);
        }

        else if (tag == "helperActive")
        {
            showPlaceholder.GetComponent<HelpMenuAnimation>().TriggerFadeOut();
            Invoke("HideHelperPlaceholder", 1f);
        }

        else if (tag == "poi")
        {
            hit.GetComponent<PoiHide>().HideText();
        }

        else if (tag == "poiButton")
        {
            hit.transform.parent.GetComponent<PoiHide>().ShowText();
        }
    }

    public bool StartVideo(int cursor)
    {
        if (OVRInput.GetDown(AButton)) 
        {
            DisableInteractionPlaceholder();
            interactivesController.SetInteractive(cursor, false);
            return true;
        }
        else return false;
    }

    public bool StartGame()
    {
        if (OVRInput.GetDown(AButton)) 
        {
            return true;

        } else return false;
    }

    public void DisableInteractionPlaceholder()
    {
        iActive= false;
        interactivePlaceholders[interactivesController.pointerCursor].SetActive(iActive);
    }

    public void HideHelperPlaceholder()
    {
        hiddenPlaceholder.SetActive(true);
    }

    public void ShowHelperPlaceHolder()
    {
        showPlaceholder.SetActive(true);
    }

    public void DisablePointers()
    {
        foreach (GameObject item in pointers)
        {
            item.SetActive(false);
        }
    }

    public void EnablePointers()
    {
        foreach (GameObject item in pointers)
        {
            item.SetActive(true);
        }
    }


    void Start()
    {
        interactivesController= gameObject.GetComponent<InteractivesController>();
        interactivePlaceholders= interactivesController.placeholders;
    }

    void Update()
    {
        if (pointersActive && OVRInput.GetDown(YButton))
        {
            pointersActive= false;
            DisablePointers();
        } else if (!pointersActive && OVRInput.GetDown(YButton))
        {
            pointersActive= true;
            EnablePointers();
        } else if (interactivesController.interactiveActive && OVRInput.GetDown(XButton))
        {
            if (iActive)
            {
                DisableInteractionPlaceholder();
            } else
            {
                iActive= true;
                interactivePlaceholders[interactivesController.pointerCursor].SetActive(iActive);
            }
        }
        else if (OVRInput.GetDown(BButton))
        {
            vManager.Pause();
            forcedPause = true;
        }
        else if (forcedPause && OVRInput.GetDown(AButton))
        {
            vManager.Play();
            forcedPause = false;
        }
    }
}
