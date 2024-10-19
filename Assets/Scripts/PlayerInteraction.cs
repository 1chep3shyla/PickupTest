using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f;
    public LayerMask interactableLayer;
    public BaseItem itemTake;
    private Outline currentItem;
    private BaseItem currentBaseItem;
    public Pickup currentPickup;
    public ItemsList itemsList;
    public GameObject textPress;

    void Update()
    {
        HandleHighlighting();
        HandleInteraction();
    }

    private void HandleHighlighting()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interactableLayer))
        {
            Debug.Log("Курсор на Объекте");
            Outline outline = hit.collider.GetComponent<Outline>();
            BaseItem baseItem = hit.collider.GetComponent<BaseItem>();
            Pickup pickup = hit.collider.GetComponent<Pickup>();

            if (outline != null)
            {
                if (currentItem != null)
                {
                    currentItem.SetHighlight(false);
                }
                textPress.SetActive(true);
                currentItem = outline;
                currentBaseItem = baseItem;
            }
            if(pickup !=null)
            {
                currentPickup = pickup;
            }
        }
        else if (currentItem != null)
        {
            currentItem.SetHighlight(false);
            textPress.SetActive(false);
            currentItem = null;
            currentPickup = null;
        }
        else
        {
            currentPickup = null;
            textPress.SetActive(false);
        }
    }

    private void HandleInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentItem != null && itemTake == null)
        {
            if (currentBaseItem != null)
            {
                Debug.Log("Подбираем...");
                itemTake = currentBaseItem;
                currentBaseItem.PickUp(); 
            }
        }
        if(Input.GetKeyDown(KeyCode.E) && itemTake !=null && currentPickup != null)
        {
            Debug.Log("Положил");
            itemsList.UpdateData(itemTake.Name);
            currentBaseItem.PlaceInPickup(); 
            itemTake = null;
            currentItem = null;
            currentPickup = null;
            currentBaseItem = null;
        }
        else if(currentItem !=null)
        {
            currentItem.SetHighlight(true);
        }
    }
}