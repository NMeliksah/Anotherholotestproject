using System;
using System.Collections;
using System.Collections.Generic;
using LeTai.TrueShadow.Demo;
using UnityEngine;
using UnityEngine.UI;

public class ResetButtonController : MonoBehaviour
{
    [SerializeField] private DirectionalKnob _knob;
    [SerializeField] private Button _resetButton;

    private void OnEnable()
    {
        _resetButton.onClick.AddListener(ResetButton);
    }
    
    private void OnDisable()
    {
        _resetButton.onClick.RemoveListener(ResetButton);
    }

    public void ResetButton()
    {
        foreach (LockerControlSwitcher controlSwitcher in RuntimeGridGenerator.Instance.SpawnedLockerSwitchers)
        {
            controlSwitcher.LockerController.CloseDoor();
        }
        _knob.SetValue(0.5f);
    }
}
