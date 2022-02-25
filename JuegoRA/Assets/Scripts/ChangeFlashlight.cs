using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChangeFlashlight : MonoBehaviour
{
    public void SetFlashlight(bool enabled)
    {
        VuforiaBehaviour.Instance.CameraDevice.SetFlash(enabled);
    }
}
