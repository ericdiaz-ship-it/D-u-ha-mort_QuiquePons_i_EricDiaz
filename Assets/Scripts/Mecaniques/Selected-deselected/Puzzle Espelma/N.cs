using UnityEngine;

public class N : MonoBehaviour,IInteractuable
{
    public void Interactuar()
    {
        controlerPuzzleEspelma.Instance.RegistrarInteraccio(this);
    }
}
