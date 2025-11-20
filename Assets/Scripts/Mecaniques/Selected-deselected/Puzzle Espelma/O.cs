using UnityEngine;

public class O : MonoBehaviour,IInteractuable
{
    public void Interactuar()
    {
        controlerPuzzleEspelma.Instance.RegistrarInteraccio(this);
    }
}
