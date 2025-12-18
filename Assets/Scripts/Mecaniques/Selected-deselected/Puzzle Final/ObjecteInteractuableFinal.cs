using UnityEngine;

public class ObjecteInteractuableFinal : MonoBehaviour, IInteractuable
{
    public string nomObjecte; // "Biblia", "Espelma", "Caliz", "Crucifix"
    public controlPuzzleFinal gestor;
    public GameObject objecte;

    public void Interactuar()
    {
        if (gestor != null)
        {
            gestor.AgafarObjecte(nomObjecte);
            objecte.SetActive(false); // desapareix l’objecte
            
        }
    }
}
