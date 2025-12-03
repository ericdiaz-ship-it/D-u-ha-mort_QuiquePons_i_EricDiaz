using UnityEngine;

public class E : MonoBehaviour,IInteractuable
{
    public void Interactuar()
    {
        controlerPuzzleEspelma.Instance.RegistrarInteraccio(this);
    }
}
