using UnityEngine;

public class C : MonoBehaviour,IInteractuable
{
    public void Interactuar()
    {
        controlerPuzzleEspelma.Instance.RegistrarInteraccio(this);
    }
}
