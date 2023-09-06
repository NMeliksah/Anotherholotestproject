using UnityEngine;

public static class BoundsExtensions
{
    public static Bounds CalculateBounds(GameObject obj)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();

        if (renderers.Length == 0)
            return new Bounds();

        Bounds bounds = renderers[0].bounds;
        for (int i = 1; i < renderers.Length; i++)
        {
            bounds.Encapsulate(renderers[i].bounds);
        }

        return bounds;
    }
}