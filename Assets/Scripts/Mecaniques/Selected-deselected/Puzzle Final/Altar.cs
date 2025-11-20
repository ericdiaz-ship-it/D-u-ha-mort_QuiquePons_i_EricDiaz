using UnityEngine;

public class AltarInteractuable : MonoBehaviour, IInteractuable
{
    public controlPuzzleFinal gestor;

    public void Interactuar()
    {
        if (gestor != null)
        {
            gestor.ComprovarAltar();
        }
    }
}
