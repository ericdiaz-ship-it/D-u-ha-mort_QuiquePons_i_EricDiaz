using System.Collections.Generic;
using UnityEngine;

public class controlPuzzleFinal : MonoBehaviour
{
    private HashSet<string> objectesRecollits = new HashSet<string>();
    private string[] objectesCorrectes = { "Biblia", "Espelma", "Caliz", "Crucifix" };

    public FinalHistoria finalHistoria; // Assigna-ho al Inspector

    public void AgafarObjecte(string nomObjecte)
    {
        if (System.Array.Exists(objectesCorrectes, x => x == nomObjecte))
        {
            objectesRecollits.Add(nomObjecte);
        }
    }

    public void ComprovarAltar()
    {
        if (objectesRecollits.Count == objectesCorrectes.Length)
        {
            finalHistoria.IniciarHistoria();
        }
        else
        {
            Debug.Log("Encara falten objectes.");
        }
    }
}
