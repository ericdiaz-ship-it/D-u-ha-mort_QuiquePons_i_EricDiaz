using UnityEngine;

public class ControlerPuzzleCrucifix : MonoBehaviour
{
    public static ControlerPuzzleCrucifix Instance;

    // Ordre correcte: Creu, Pa, Copa, Creu
    private string[] ordreCorrecte = { "CREU", "PA", "COPA", "CREU" };
    private string[] ordreActual = new string[4];
    private int index = 0;

    public GameObject crucifixOcult;

    private void Awake()
    {
        Instance = this;
        if (crucifixOcult != null)
            crucifixOcult.SetActive(false);
    }

    public void RegistrarInteraccio(IInteractuable obj)
    {
        if (index >= 4) return;

        ordreActual[index] = obj.GetType().Name.ToUpper();
        index++;

        if (index == 4)
        {
            Comprovar();
        }
    }

    private void Comprovar()
    {
        bool correcte = true;

        for (int i = 0; i < 4; i++)
        {
            if (ordreActual[i] != ordreCorrecte[i])
            {
                correcte = false;
                break;
            }
        }

        if (correcte)
        {
            if (crucifixOcult != null)
                crucifixOcult.SetActive(true);
        }
        else
        {
             ResetPuzzle();
        }

       
    }

    private void ResetPuzzle()
    {
        ordreActual = new string[4];
        index = 0;
    }
}
