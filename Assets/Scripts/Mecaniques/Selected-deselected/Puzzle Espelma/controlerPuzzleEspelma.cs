using UnityEngine;

public class controlerPuzzleEspelma : MonoBehaviour
{
    public static controlerPuzzleEspelma Instance;

    private string[] ordreCorrecte = { "N", "C", "S" };
    private string[] ordreActual = new string[3];
    private int index = 0;

    [Header("Espelmes")]
    public GameObject EspelmaOculta;       // Espelma que apareix si s’acompleix l’ordre
    
    public GameObject[] focsActius;        // Array amb tots els focs/espelmes que es poden apagar

    private void Awake()
    {
        Instance = this;

        // Oculta l’espelma oculta al començar
        if (EspelmaOculta != null)
            EspelmaOculta.SetActive(false);
    }

    public void RegistrarInteraccio(IInteractuable obj)
    {
        if (index >= 3) return;

        ordreActual[index] = obj.GetType().Name;
        index++;

        if (index == 3)
        {
            Comprovar();
        }
    }

    private void Comprovar()
    {
        bool correcte = true;

        for (int i = 0; i < 3; i++)
        {
            if (ordreActual[i] != ordreCorrecte[i])
            {
                correcte = false;
                break;
            }
        }

        if (correcte)
        {
            if (EspelmaOculta != null)
                EspelmaOculta.SetActive(true);
        }
        else
        {
            ResetPuzzle();
        }
    }

    private void ResetPuzzle()
    {
        // Reinicia l'ordre del puzzle
        index = 0;
        ordreActual = new string[3];

        // Apaga tots els focs actius
        if (focsActius != null)
        {
            foreach (GameObject foc in focsActius)
            {
                if (foc != null)
                    foc.SetActive(false);  // Apaga directament, sense comprovar si està actiu
            }
        }

        // Apaga també l'espelma oculta
        if (EspelmaOculta != null)
        {
            EspelmaOculta.SetActive(false);
        }
    }
}
