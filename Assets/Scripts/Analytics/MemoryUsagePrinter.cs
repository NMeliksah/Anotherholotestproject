using System;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class MemoryUsagePrinter : MonoBehaviour
{
    [SerializeField] private Image _memoryFillImage;
    [SerializeField] private Text _memoryText;

    private float _totalMemory = 0f;
    private float _totalAllocatedMemory = 0f;
    private float _usedMemoryRatio = 0f;
    
    private void OnEnable()
    {
        _totalMemory = (float) SystemInfo.systemMemorySize;
    }

    void Update()
    {
        float _totalAllocatedMemory = Profiler.GetTotalAllocatedMemoryLong() / (1024f * 1024f); // MB

        _usedMemoryRatio = _totalAllocatedMemory / _totalMemory;

        _memoryFillImage.fillAmount = _usedMemoryRatio;
        
        _memoryText.text = "RAM: "  + (_usedMemoryRatio*100f).ToString("F2") + " % Used";
    }
}