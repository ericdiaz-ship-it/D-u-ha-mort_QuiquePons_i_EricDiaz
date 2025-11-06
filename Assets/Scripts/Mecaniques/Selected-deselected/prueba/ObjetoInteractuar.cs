using UnityEngine;

public class ObjetoInteractuar : MonoBehaviour, IInteractuable
{
    public void Interactuar()
    {
        Destroy(gameObject);
    }
}
