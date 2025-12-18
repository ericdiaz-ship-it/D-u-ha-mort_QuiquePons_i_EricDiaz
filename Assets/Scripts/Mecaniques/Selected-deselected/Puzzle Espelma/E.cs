using UnityEngine;

public class E : MonoBehaviour,IInteractuable
{
    public GameObject foc;
    public void Interactuar()
    {
        controlerPuzzleEspelma.Instance.RegistrarInteraccio(this);
        foc.SetActive(true);
    }
}