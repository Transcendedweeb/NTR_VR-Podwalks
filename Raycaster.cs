using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public string controllerHand= "L";
    readonly float raycastDistance = 50f;
    public ButtonListener btnListener;
    LineRenderer laserLine;

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.enabled = false;
    }

    void Update()
    {
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = transform.forward;


        if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hit, raycastDistance))
        {
            btnListener.PointerCheck(controllerHand, hit.collider.gameObject.tag, hit.collider.gameObject);
            VisualizeLaser(rayOrigin, hit.point);
        }
        else
        {
            VisualizeLaser(rayOrigin, rayOrigin + rayDirection * raycastDistance);
        }
    }

    void VisualizeLaser(Vector3 startPoint, Vector3 endPoint)
    {
        laserLine.enabled = true;
        laserLine.SetPosition(0, startPoint);
        laserLine.SetPosition(1, endPoint);
    }
}
