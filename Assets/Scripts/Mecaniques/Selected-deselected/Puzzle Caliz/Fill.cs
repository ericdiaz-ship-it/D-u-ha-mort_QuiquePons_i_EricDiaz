using UnityEngine;

public class Fill : MonoBehaviour, IInteractuable
{
   public void Interactuar()
   {
       controllerPuzzleCaliz.Instance.RegistrarInteraccio(this);
   }
}
