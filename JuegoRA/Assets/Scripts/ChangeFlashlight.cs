using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChangeFlashlight : MonoBehaviour
{
    /// <summary>
    /// Enables or diables flaslight
    /// </summary>
    /// <param name="enabled"></param>
    public void SetFlashlight(bool enabled)
    {
        VuforiaBehaviour.Instance.CameraDevice.SetFlash(enabled);
    }
}
