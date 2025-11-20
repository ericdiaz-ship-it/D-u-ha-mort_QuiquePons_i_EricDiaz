using UnityEngine;

public class Copa : MonoBehaviour,IInteractuable
{
    public void Interactuar()
    {
        ControlerPuzzleCrucifix.Instance.RegistrarInteraccio(this);
    }
}
