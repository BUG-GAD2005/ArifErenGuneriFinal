using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private GameObject pawnPrefab;
    [SerializeField] private GameObject housePrefab;
    [SerializeField] private GameObject flagPrefab;
    [SerializeField] private GameObject yachtPrefab;
    [SerializeField] private GameObject trainPrefab;
    [SerializeField] private GameObject castlePrefab;

    [SerializeField] private Camera mainCamera;
    

    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.LogWarning("OnPointerDown");

        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = mainCamera.ScreenToWorldPoint(mousePos);

        if (gameObject.name == "PAWNButton")
        {
            Debug.LogWarning("Instantiate Pawn");
            var spawnedUnit = Instantiate(pawnPrefab, objectPos, Quaternion.identity);
        }
        else if (gameObject.name == "HOUSEButton")
        {

        }
        else if (gameObject.name == "FLAGButton")
        {

        }
        else if (gameObject.name == "YACHTButton")
        {

        }
        else if (gameObject.name == "TRAINButton")
        {

        }
        else if (gameObject.name == "CASTLEButton")
        {

        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.LogWarning("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.LogWarning("OnDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.LogWarning("OnEndDrag");
    }

    

}
