using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Location currentLocation;

    public List<Item> inventory = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ChengeLocation(GameController controller, string connectionNoun){
        Connection connection = currentLocation.GetConnection(connectionNoun);
        if (connection != null){
            if (connection.connectionEnabled){
                currentLocation = connection.location;
                return true;
            }
        }
        return false;
    }

    public void Teleport(GameController controller, Location destination)
    {
        currentLocation = destination;
    }

    public bool CanReadItem(GameController gameController, Item item)
    {
        return item.playerCanRead;
    }

    internal bool CanGiveToItem(GameController controller, Item item)
    {
        return item.playerCanGiveTo;
    }

    internal bool CanTalkToItem(GameController controller, Item item)
    {
        return item.playerCanTalkTo;
    }

    internal bool CanUseItem(GameController gameController, Item item)
    {
        if (item.targetItem == null)
            return true;
        if (HasItem(item.targetItem))
            return true;
        if (currentLocation.HasItem(item.targetItem))
            return true;
        return false;
    }

    private bool HasItem(Item item)
    {
        foreach(Item inventoryItem in inventory)
        {
            if (inventoryItem == item && item.itemEnabled)
                return true;
        }
        return false;
    }

    public bool HasItemByName(string noun)
    {
        foreach (Item item in inventory)
        {
            if (item.itemName.ToLower() == noun.ToLower())
                return true;
        }
        return false;
    }

}
