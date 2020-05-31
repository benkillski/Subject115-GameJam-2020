using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : Item
{
    private Item upgrade;

    public GameObject player;

    public string itemName;
    public string upgradeType;
    public const string itemType = "Upgrade";

    public Upgrade(string itemName, string upgradeType) : base(itemName, upgradeType)
    {
        this.itemName = itemName;
        this.upgradeType = upgradeType;
    }

    // Start is called before the first frame update
    void Start()
    {
        upgrade = new Upgrade(itemName, upgradeType);
    }

    public string GetUpgradeType()
    {
        return upgradeType;
    }

     public override string GetItemName()
    {
       base.GetItemName();
       return itemName;
    }

    public override bool Equals(Item upgrade)
    {
        base.Equals(upgrade);

        if(upgrade != null && upgrade is Key) {
            if((this.itemName.Equals(upgrade.GetItemName())) && (this.GetItemType().Equals(upgrade.GetItemType())))
            {
                return true;
            }
        }
        return false;
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);

        if(col.gameObject.tag == "Player")
        {
            PlayerInventory.playerItems.Add(upgrade);

            if(GetUpgradeType() == "Health Upgrade")
            {
                Debug.Log("Health Increased");
                player.GetComponent<PlayerHealth>().SetMaxHealth(100);
                player.GetComponent<PlayerHealth>().SetHealth(player.GetComponent<PlayerHealth>().GetMaxHealth());
            }

            else if(GetUpgradeType() == "Missle Upgrade")
            {
                Debug.Log("Missle Increased");
                player.GetComponent<PlayerInventory>().SetMissleAbilityStatus(true);
                player.GetComponent<PlayerInventory>().IncreaseMissleCapacity(5);
                player.GetComponent<PlayerInventory>().SetCurrentMissleCount(player.GetComponent<PlayerInventory>().GetMissleCapacity());
            }
        }
    }
}
