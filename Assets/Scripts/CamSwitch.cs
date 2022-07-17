using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Camera1;

    private void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if (MainCamera.activeSelf)
            {
                MainCamera.SetActive(false);
                Camera1.SetActive(true);
            } 
            else if (Camera1.activeSelf)
            {
                MainCamera.SetActive(true);
                Camera1.SetActive(false);
            }
        }
    }
}
