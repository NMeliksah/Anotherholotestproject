using UnityEngine;

public class LockerControlSwitcher : MonoBehaviour
{
    public LockerControllerBase LockerController;

    private void Start()
    {
#if UNITY_ANDROID || UNITY_IOS || TEST_MOBILE
        LockerController = gameObject.AddComponent<LockerControllerMobile>();

#elif UNITY_STANDALONE || TEST_PC
        LockerController = gameObject.AddComponent<LockerControllerPC>();

#elif UNITY_WSA  || TEST_HOLOLENS
        LockerController = gameObject.AddComponent<LockerControllerHololens>();

#endif

    }
}
