using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseItem : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    private Outline outline;
    public Vectors inHands; 
    public Vectors inPickup; 

    protected virtual void Awake()
    {
        outline = GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = false;
        }
    }

    public string Name => itemName;

    public void Highlight(bool state)
    {
        if (outline != null)
        {
            outline.enabled = state;
        }
    }

    public virtual void PickUp()
    {
        Debug.Log($"{itemName} взят с полки.");
        SetParent("Player/Main Camera/Hands");
        transform.localPosition = inHands.position;
        transform.localRotation = Quaternion.Euler(inHands.rotation); 
    }

    public virtual void PlaceInPickup()
    {
        Debug.Log($"{itemName} положен в пикап.");
        SetParent("pickUp");
        transform.localPosition = inPickup.position;
        transform.localRotation = Quaternion.Euler(inPickup.rotation); 
        Destroy(this);
        Destroy(GetComponent<Outline>());
    }

    private void SetParent(string parentPath)
    {
        Transform parentTransform = GameObject.Find(parentPath).transform;
        if (parentTransform != null)
        {
            transform.SetParent(parentTransform);
        }
    }

    [System.Serializable]
    public class Vectors
    {
        public Vector3 position;
        public Vector3 rotation;
    }
}