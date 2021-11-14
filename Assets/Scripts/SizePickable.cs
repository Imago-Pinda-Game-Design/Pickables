using UnityEngine;

public class SizePickable : Pickable
{
    public float Scale;

    public override bool Pick()
    {
        if (CanBeCollected)
        {
            Debug.Log("Collected");
            return true;
        }

        return false;
    }
}