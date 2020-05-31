// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Collectable : MonoBehaviour
// {
//     private string collectableName;
//     private string itemType;

//     public Collectable(string collectableName, string itemType)
//     {
//         this.collectableName = collectableName;
//         this.itemType = itemType;
//     }

//     void OnCollisionEnter2D(Collision2D col)
//     {
//         if(col.gameObject.tag == "Player")
//         {
//             PlayerInventory.playerItems.Add(new Collectable(collectableName, itemType));
//             Destroy(gameObject);
//         }
//     }

//     public string GetItemType()
//     {
//         return itemType;
//     }
// }
