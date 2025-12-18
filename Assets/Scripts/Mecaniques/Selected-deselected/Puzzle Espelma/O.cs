using UnityEngine;

public class O : MonoBehaviour,IInteractuable
{
    public GameObject foc;
    public void Interactuar()
    {
        controlerPuzzleEspelma.Instance.RegistrarInteraccio(this);
        foc.SetActive(true);
    }
}
