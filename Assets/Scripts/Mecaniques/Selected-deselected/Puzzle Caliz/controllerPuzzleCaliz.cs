using UnityEngine;

public class controllerPuzzleCaliz : MonoBehaviour
{
    public static controllerPuzzleCaliz Instance;
    private string[] ordreCorrecte = {"Pare", "Fill", "Esperit"};
    private string[] ordreActual = new string[3];
    private int index = 0;
    public GameObject calizOcult;
    private void Awake()
    {
        Instance = this;
        if (calizOcult != null)
            calizOcult.SetActive(false);
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
            if (calizOcult != null)
                calizOcult.SetActive(true);
        }
        else
        {
             ResetPuzzle();
        }

       
    }
    private void ResetPuzzle()
    {
        index = 0;
        ordreActual = new string[3];
    }
}
