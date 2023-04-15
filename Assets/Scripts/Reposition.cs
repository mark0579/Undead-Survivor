using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area")) return;
  
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
       

        switch (transform.tag)
        {
            case "Ground":
                float diffX = playerPos.x - myPos.x; //절대값
                float diffY = playerPos.y - myPos.y; //절대값
                float dirX = diffX < 0 ? -1 : 1;
                float dirY = diffY < 0 ? -1 : 1;
                diffX = Mathf.Abs(diffX);
                diffY = Mathf.Abs(diffY);

                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40); //Translate : 어느 정도 네모 양 만큼 이동하곘다
                } else if (diffY > diffX)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            
            case "Enemy":
                if(coll.enabled)
                {
                    Vector3 dist = playerPos - myPos;
                    Vector3 ran = new Vector3(Random.Range(-3,3), Random.Range(-3,3),0);
                    transform.Translate(ran + dist * 2);
                }
                break;

        }
    }
    
  }
