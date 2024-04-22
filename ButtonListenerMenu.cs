using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonListenerMenu : MonoBehaviour
{
    const OVRInput.Button AButton = OVRInput.Button.One;
    const OVRInput.Button BButton = OVRInput.Button.Two;
    const OVRInput.Button XButton = OVRInput.Button.Three;
    const OVRInput.Button YButton = OVRInput.Button.Four;
    const OVRInput.Button l_IndexButton = OVRInput.Button.PrimaryIndexTrigger;
    const OVRInput.Button r_IndexButton = OVRInput.Button.SecondaryIndexTrigger;

    public GameObject menuMain;
    public GameObject menuHeaders;
    public GameObject menuSettings;
    public GameObject globals;

    GameObject[] array = new GameObject[2];


    void MenuHandler(GameObject active, GameObject[] inactive)
    {
        foreach (GameObject item in inactive)
        {
            item.SetActive(false);   
        }
        active.SetActive(true);
    }

    public void PointerCheck(string hand, string tag, GameObject hit)
    {
        if((hand == "L" && !OVRInput.GetDown(l_IndexButton)) || (hand == "R" && !OVRInput.GetDown(r_IndexButton))) return;

        if (tag == "TestCube")
        {
            hit.SetActive(false);
        }

        else if(tag == "menu_Start")
        {
            globals.GetComponent<GlobalsHolder>().Beginning();
            SceneManager.LoadScene(2);
        }

        else if(tag == "menu_Headers")
        {
            GameObject[] array = {menuMain};
            MenuHandler(menuHeaders, array);
        }

        else if(tag == "menu_Settings")
        {
            GameObject[] array = {menuMain};
            MenuHandler(menuSettings, array);
        }

        else if(tag == "menu_Back")
        {
            GameObject[] array = {menuHeaders, menuSettings};
            MenuHandler(menuMain, array);
        }

        else if (tag == "header1")
        {
            globals.GetComponent<GlobalsHolder>().Chapter1();
            SceneManager.LoadScene(2);
        }

        else if (tag == "header2")
        {
            globals.GetComponent<GlobalsHolder>().Chapter2();
            SceneManager.LoadScene(2);
        }

        else if (tag == "header3")
        {
            globals.GetComponent<GlobalsHolder>().Chapter3();
            SceneManager.LoadScene(2);
        }

        else if (tag == "SoundValues")
        {
            hit.GetComponent<GetSoundValues>().PassFlags();
        }
    }

    
    void Start()
    {
        globals = GameObject.Find("GlobalsPlaceholder");
    }
}
