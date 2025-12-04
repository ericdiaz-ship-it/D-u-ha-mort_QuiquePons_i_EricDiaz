using UnityEngine;

public class llibreInteractuable : MonoBehaviour, IInteractuable
{
    public llegirBiblia lector;  // Script que controla el panel
    [Range(0, 11)]
    public int indiceNota;               // Índice de la nota (0 a 11)

    public void Interactuar()
    {
        if (lector != null)
        {
            lector.ObrirPassatge(indiceNota);
        }
    }
}
