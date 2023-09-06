using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPSPrinter : MonoBehaviour
{
    [SerializeField] private Text _textFPS;
    [SerializeField] private float updateInterval = 0.5f;

    private void Start()
    {
        StartCoroutine(UpdateFPS());
    }

    private IEnumerator UpdateFPS()
    {
        while (true)
        {
            _textFPS.text = "FPS: " + (1 / Time.deltaTime).ToString("F2");
            yield return new WaitForSeconds(updateInterval);
        }
    }
}