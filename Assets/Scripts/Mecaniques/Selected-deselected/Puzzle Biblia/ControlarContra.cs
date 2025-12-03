using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlarContra : MonoBehaviour
{
    [Header("Entrades dels 4 dígits")]
    public TMP_Text digit1;
    public TMP_Text digit2;
    public TMP_Text digit3;
    public TMP_Text digit4;

    [Header("Codi Correcte")]
    public string codiCorrecte = "1715";

    [Header("Objectes del Puzle")]
    public GameObject biblia;
    public GameObject uiCandau;



    private bool jaResolt = false;

    private void Start()
    {
        if (biblia != null)
            biblia.SetActive(false);
    }

    public void RevisarCodi() // Aquesta funció es crida automàticament per cada canvi de dígit
    {
        if (jaResolt) return; // Evita repeticions

        string codiIntroduit =
            digit1.text +
            digit2.text +
            digit3.text +
            digit4.text;

        if (codiIntroduit.Length < 4)
            return; // Encara no s’han seleccionat els 4 dígits

        if (codiIntroduit == codiCorrecte)
        {
            jaResolt = true;
            Debug.Log("Codi correcte!");

            RevelarObjecte();
        }

    }

    private void RevelarObjecte()
    {
        if (biblia != null)
            biblia.SetActive(true);

        if (uiCandau != null)
            uiCandau.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
