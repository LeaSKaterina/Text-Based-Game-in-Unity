using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        // use items in the room
        if (ReadItems(controller, controller.player.currentLocation.items, noun))
            return;
        // use item in inventory
        if (ReadItems(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "There is no " + noun;
    }

    private bool ReadItems(GameController gameController, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (gameController.player.CanReadItem(gameController, item))
                {
                    if (item.InteractWith(gameController, "read"))
                        return true;
                }
                gameController.currentText.text = "The " + noun + " does nothing.";
                return true;
            }
        }
        return false;
    }
}
