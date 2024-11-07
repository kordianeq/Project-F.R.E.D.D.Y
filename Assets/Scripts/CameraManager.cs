using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static List<GameObject> cameras = new List<GameObject>();

    public static void FindCameras()
    {
        cameras.Clear();
        cameras.AddRange(GameObject.FindGameObjectsWithTag("Camera"));
    }

    public static void ActivateCamera(GameObject activatedCamera)
    {
        foreach (GameObject cam in cameras)
        {
            if (cam == activatedCamera)
            {
                cam.SetActive(true);
            }
            else
            {
                cam.SetActive(false);
            }
        }

    }
}