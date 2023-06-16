using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IDropHandler
{
    public bool isOccupied;
    public int x, y;

    [SerializeField] GameObject highlight;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.LogWarning("DROPPED");
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
