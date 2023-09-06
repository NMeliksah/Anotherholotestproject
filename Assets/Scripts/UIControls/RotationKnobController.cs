using System;
using System.Collections;
using System.Collections.Generic;
using LeTai.TrueShadow.Demo;
using UnityEngine;
using UnityEngine.UI;

public class RotationKnobController : MonoBehaviour
{
    [SerializeField] private DirectionalKnob _knob;
    [SerializeField] private HingedObjectRotator _standRotator;
    [SerializeField] private Text _angleText;

    [SerializeField] private float _minRotationAngle;
    [SerializeField] private float _maxRotationAngle;

    private float _currentRotationAngle = 0f;

    private void OnEnable()
    {
        _knob.knobValueChanged.AddListener(KnobvalueChanged);
    }
    
    private void OnDisable()
    {
        _knob.knobValueChanged.AddListener(KnobvalueChanged);
    }

    private void KnobvalueChanged(float knobValue)
    {
        Debug.Log("Current knob value: " + knobValue);

        _currentRotationAngle = Mathf.Lerp(_minRotationAngle, _maxRotationAngle, knobValue);
        
        Debug.Log("Current rotation angle: " + _currentRotationAngle);
        
        _standRotator.RotateObject(_currentRotationAngle);
        _angleText.text = "Current Angle: " + _currentRotationAngle.ToString("F2");
    }

}
