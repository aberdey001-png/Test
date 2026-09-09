using UnityEngine;

public class ChekTriggerPoint : MonoBehaviour
{     
   public static System.Action OnChekTriggerPoint; 

   private void OnTriggerEnter(Collider other)
   {  
      if(other.CompareTag ("Player"))
      {
         OnChekTriggerPoint?.Invoke();
      }
   }
}
