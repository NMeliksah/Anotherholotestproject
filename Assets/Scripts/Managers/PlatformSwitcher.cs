using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformSwitcher : MonoBehaviour
{
    public List<UnityEvent> MobileActivationEvents;
    public List<UnityEvent> DesktopActivationEvents;
    public List<UnityEvent> HoloLensActivationEvents;

    private void Start()
    {
#if UNITY_ANDROID || UNITY_IOS || TEST_MOBILE

        foreach (var activationEvent in MobileActivationEvents)
        {
            activationEvent.Invoke();
        }

#elif UNITY_STANDALONE || TEST_PC
        
        foreach (var activationEvent in DesktopActivationEvents)
        {
            activationEvent.Invoke();
        }

#elif (UNITY_WSA && !UNITY_EDITOR) || TEST_HOLOLENS

        foreach (var activationEvent in HoloLensActivationEvents)
        {
            activationEvent.Invoke();
        }

#endif
    }
}
