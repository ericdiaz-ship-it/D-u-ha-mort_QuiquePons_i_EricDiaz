using UnityEngine;

public class Pare : MonoBehaviour, IInteractuable
{
   public void Interactuar()
   {
       controllerPuzzleCaliz.Instance.RegistrarInteraccio(this);
   }
}
