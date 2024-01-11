using DG.Tweening;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ITARUIManagerHolo : MonoBehaviour
{
    [Header("Splash Screen")]
    public Image splashScreenImage;
    public Image splashScreenBG;
    public float splashScreenDuration = 3f;

    [Header("Connection Button")]
    public Interactable connectionButton;
    public GameObject networkPerformanceMetrics;

    [Header("Network Metrics")]
    public float metricsUpdateInterval = 5f; 

    public MetricVisualizer latencyVisualizer;
    public MetricVisualizer signalStrengthVisualizer;
    public MetricVisualizer packetLossVisualizer;
    public MetricVisualizer throughputVisualizer;
    public MetricVisualizer coverageAreaVisualizer;
    private void Start()
    {
        // Initialize the splash screen
        InitializeSplashScreen();

        // Set up connection button listener
        connectionButton.OnClick.AddListener(ToggleNetworkPerformanceMetrics);

        // Start updating network metrics
        InvokeRepeating(nameof(UpdateNetworkMetrics), metricsUpdateInterval, metricsUpdateInterval);
    }

    private void InitializeSplashScreen()
    {
        if (splashScreenImage != null)
        {
            splashScreenImage.DOColor(new Color(0,0,0,0), splashScreenDuration).OnComplete(
                () => splashScreenBG.DOColor(new Color(0,0,0,0), splashScreenDuration).OnComplete(
                    ()=>splashScreenImage.transform.parent.gameObject.SetActive(false)
                    )
                );
        }
    }

    private void ToggleNetworkPerformanceMetrics()
    {
        networkPerformanceMetrics.SetActive(!networkPerformanceMetrics.activeSelf);
    }

    private void UpdateNetworkMetrics()
    {
        latencyVisualizer.UpdateVisualizer(GetLatency());
        signalStrengthVisualizer.UpdateVisualizer(GetSignalStrength());
        packetLossVisualizer.UpdateVisualizer(GetPacketLoss());
        throughputVisualizer.UpdateVisualizer(GetThroughput());
        coverageAreaVisualizer.UpdateVisualizer(GetCoverageArea());
    }

    // Placeholder methods for fetching network metrics
    private float GetLatency() { /* Fetch latency data */ return Random.Range(0f,1f); }
    private float GetSignalStrength() { /* Fetch signal strength data */ return Random.Range(0f,1f); }
    private float GetPacketLoss() { /* Fetch packet loss data */ return Random.Range(0f,1f); }
    private float GetThroughput() { /* Fetch throughput data */ return Random.Range(0f,1f); }
    private float GetCoverageArea() { /* Fetch coverage area data */ return Random.Range(0f,1f); }
}

[System.Serializable]
public class MetricVisualizer
{
    public Image fillImage;
    public TMP_Text dataText;

    public void UpdateVisualizer(float value)
    {
        fillImage.fillAmount = value;
        dataText.text = (value*100).ToString("F2") + " %";
    }
}
