using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    private Item key;
    public string itemName;
    public const string itemType = "Key";
    public string keyColor;
   
    public Key(string itemName, string keyColor) : base(itemName, itemType)
    { 
        this.itemName = itemName;
        this.keyColor = keyColor;
    }

    void Start()
    {
        key = new Key(itemName, keyColor);
    }

    public override string GetItemType()
    {
        base.GetItemType();
        return keyColor + " " + itemType;
    }

    public override string GetItemName()
    {
       base.GetItemName();
       return itemName;
    }

    public override bool Equals(Item key)
    {
        base.Equals(key);

        if(key != null && key is Key) {
            if((this.itemName.Equals(key.GetItemName())) && (this.GetItemType().Equals(key.GetItemType())))
            {
                return true;
            }
        }
        return false;
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
        PlayerInventory.playerItems.Add(key);
    
    }

}
