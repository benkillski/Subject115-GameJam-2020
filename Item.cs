using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private string itemName;
    private string itemType;

    
    public Item(string itemName, string itemType) 
    {
        this.itemName = itemName;
        this.itemType = itemType;
    }

    public virtual string GetItemType()
    {
        return itemType;
    }

    public virtual string GetItemName()
    {
        return itemName;
    }

    public virtual bool Equals(Item item)
    {
        base.Equals(item);

        if(item != null && item is Item) {
            if((this.itemName.Equals(item.GetItemName())) && (this.itemType.Equals(item.GetItemType())))
            {
                return true;
            }
        }
        return false;
    }

    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
