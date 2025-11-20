using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlPuzzleFinal : MonoBehaviour
{
    // Nom dels objectes que ha de tenir el jugador
    private HashSet<string> objectesRecollits = new HashSet<string>();
    private string[] objectesCorrectes = { "Biblia", "Espelma", "Caliz", "Crucifix" };

    public void AgafarObjecte(string nomObjecte)
    {
        // Només afegeix si és correcte i encara no està recollit
        if (System.Array.Exists(objectesCorrectes, x => x == nomObjecte))
        {
            if (!objectesRecollits.Contains(nomObjecte))
            {
                objectesRecollits.Add(nomObjecte);
                Debug.Log("Objecte recollit: " + nomObjecte);
            }
        }
        else
        {
            Debug.Log("Objecte incorrecte: " + nomObjecte);
        }
    }

    // Aquesta funció la crida l’altar quan el jugador interactua
    public void ComprovarAltar()
    {
        if (objectesRecollits.Count == objectesCorrectes.Length)
        {
            Debug.Log("Tots els objectes correctes! Enviant a Menu...");
            SceneManager.LoadScene("Menu");
        }
        else
        {
            Debug.Log("Falten objectes per completar el puzle!");
        }
    }
}
