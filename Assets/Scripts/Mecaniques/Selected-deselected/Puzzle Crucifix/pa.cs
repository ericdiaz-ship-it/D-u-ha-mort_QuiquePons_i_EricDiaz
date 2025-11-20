using UnityEngine;

public class Pa : MonoBehaviour,IInteractuable
{
    public void Interactuar()
    {
        ControlerPuzzleCrucifix.Instance.RegistrarInteraccio(this);
    }
}
