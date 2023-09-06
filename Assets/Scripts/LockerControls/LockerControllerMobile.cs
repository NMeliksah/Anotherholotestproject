using UnityEngine;

public class LockerControllerMobile : LockerControllerBase
{
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == this.transform)
            {
                SwitchDoorState();
            }
        }
    }
}