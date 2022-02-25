using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CameraFocus : MonoBehaviour
{

    private void Start()
    {
        VuforiaApplication.Instance.OnVuforiaStarted += StartVuforiaFocus;
    }

    public void StartVuforiaFocus()
    {
        VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
}
