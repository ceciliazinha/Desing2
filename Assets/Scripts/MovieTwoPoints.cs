using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieTwoPoints : MonoBehaviour
{
   public GameObject obj;
   public Transform pos1, pos2;
   public float WaitTime = 0.5f;
   public float speed = 2f;

   Vector3 nextPos;

    void Start()
    {
        nextPos = pos1.localPosition;
        StartCoroutine(Move());
    }

    // Update is called once per frame
    
     IEnumerator Move(){
         while (true){
             if(obj.transform.localPosition == pos1.localPosition){
                 nextPos = pos2.localPosition;
                 yield return new WaitForSeconds(WaitTime);
             }
             if(obj.transform.localPosition == pos2.localPosition){
                 nextPos = pos1.localPosition;
                 yield return new WaitForSeconds(WaitTime);
             }
         obj.transform.localPosition = Vector3.MoveTowards(obj.transform.localPosition, nextPos, speed * Time.deltaTime);
         yield return null;
     }   
    }
    void OnDrawGizmos(){
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
