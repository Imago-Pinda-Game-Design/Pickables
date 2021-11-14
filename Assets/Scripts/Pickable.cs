using UnityEngine;

public abstract class Pickable : MonoBehaviour
{
    public bool CanBeCollected;

    public abstract bool Pick();
}
