using UnityEngine;

public class Pa : MonoBehaviour,IInteractuable
{
    public void Interactuar()
    {
        ControlerPuzzleCrucifix.Instance.RegistrarInteraccio(this);
        Debug.Log( this.GetType().Name.ToUpper() +" seleccionada");
    }
}
