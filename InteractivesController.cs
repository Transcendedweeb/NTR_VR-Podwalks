using UnityEngine;

public class InteractivesController : MonoBehaviour
{
    public GameObject[] interactives;
    public GameObject[] placeholders;
    public bool interactiveActive= false;
    public int pointerCursor;

    public void SetInteractive(int cursor, bool active)
    {
        pointerCursor= cursor;
        interactives[pointerCursor].SetActive(active);
        interactiveActive= active;
    }
}
