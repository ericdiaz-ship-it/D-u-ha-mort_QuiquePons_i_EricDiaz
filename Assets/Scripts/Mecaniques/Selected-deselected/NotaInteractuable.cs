using UnityEngine;

public class NotaInteractuable : MonoBehaviour, IInteractuable
{
    public LlegirNotasMultiples lector;  // Script que controla el panel
    [Range(0, 11)]
    public int indiceNota;               // Índice de la nota (0 a 11)

    public void Interactuar()
    {
        if (lector != null)
        {
            lector.InteractuarNota(indiceNota);
        }
    }
}
