using UnityEngine;

public class Esperit : MonoBehaviour, IInteractuable
{
   public void Interactuar()
   {
       controllerPuzzleCaliz.Instance.RegistrarInteraccio(this);
   }
}
