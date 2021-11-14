using UnityEngine;

public class ColorPickable : Pickable
{
    public Color PickColor;

    public override bool Pick()
    {
        if (CanBeCollected)
        {
            Debug.Log("Collected");
            Destroy(gameObject);

            return true;
        }

        return false;
    }
}