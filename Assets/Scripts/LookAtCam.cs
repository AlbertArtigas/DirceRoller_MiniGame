using Unity.VisualScripting;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    public Transform cam;
    private void Update()
    {
        if(cam == null)
            cam = Camera.main.transform;
        transform.LookAt(cam);
    }
    
}
