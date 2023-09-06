using UnityEngine;
using System.Collections;

public class PositionInitializer : MonoBehaviour 
{
    [SerializeField]
    private Transform mixedRealityPlayspace;
    
    [SerializeField]
    private Transform referenceTransform;

    private void Start() 
    {
        if (referenceTransform == null || mixedRealityPlayspace == null)
        {
            Debug.LogError("Reference transform or MixedRealityPlayspace is not set!");
            return;
        }

        StartCoroutine(SetTransformAfterInitialization());
    }

    private IEnumerator SetTransformAfterInitialization() 
    {
        yield return new WaitForSeconds(0.1f);
        SetPlayspaceTransform();
    }

    private void SetPlayspaceTransform()
    {
        mixedRealityPlayspace.position = referenceTransform.position;
        mixedRealityPlayspace.rotation = referenceTransform.rotation;
    }
}
