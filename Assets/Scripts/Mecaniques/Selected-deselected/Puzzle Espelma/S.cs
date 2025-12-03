using UnityEngine;

public class S : MonoBehaviour,IInteractuable
{
    public void Interactuar()
    {
        controlerPuzzleEspelma.Instance.RegistrarInteraccio(this);
    }
}
