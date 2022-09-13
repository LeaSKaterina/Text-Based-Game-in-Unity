using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Actions/Use")]
public class Use : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        // use items in the room
        if (UseItems(controller, controller.player.currentLocation.items, noun))
            return;
        // use item in inventory
        if (UseItems(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "There is no " + noun;
    }

    private bool UseItems(GameController gameController, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (gameController.player.CanUseItem(gameController, item)) { 
                    if (item.InteractWith(gameController, "use"))
                        return true;
                }
                gameController.currentText.text = "The " + noun + " does nothing.";
                return true;
            }
        }
        return false;
    }

}
