using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public enum unitEnum
{
    pawn,
    house,
    flag,
    yacht,
    train,
    castle
}

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public unitEnum spawnedUnitEnum;
    
    [SerializeField] private GameObject pawnPrefab;
    [SerializeField] private GameObject housePrefab;
    [SerializeField] private GameObject flagPrefab;
    [SerializeField] private GameObject yachtPrefab;
    [SerializeField] private GameObject trainPrefab;
    [SerializeField] private GameObject castlePrefab;

    [SerializeField] private Camera mainCamera;
    private CanvasGroup canvasGroup;
    private GridManager gridManager;

    public GameObject spawnedUnit;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        gridManager = FindObjectOfType<GridManager>();
    }

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
            spawnedUnit = Instantiate(pawnPrefab, objectPos, Quaternion.identity);
            spawnedUnitEnum = unitEnum.pawn;
        }
        else if (gameObject.name == "HOUSEButton")
        {
            Debug.LogWarning("Instantiate House");
            spawnedUnit = Instantiate(housePrefab, objectPos, Quaternion.identity);
            spawnedUnitEnum = unitEnum.house;
        }
        else if (gameObject.name == "FLAGButton")
        {
            Debug.LogWarning("Instantiate Flag");
            spawnedUnit = Instantiate(flagPrefab,objectPos, Quaternion.identity);
            spawnedUnitEnum = unitEnum.flag;
        }
        else if (gameObject.name == "YACHTButton")
        {
            Debug.LogWarning("Instantiate Yacht");
            spawnedUnit = Instantiate(yachtPrefab, objectPos, Quaternion.identity);
            spawnedUnitEnum= unitEnum.yacht;
        }
        else if (gameObject.name == "TRAINButton")
        {
            Debug.LogWarning("Instantiate Train");
            spawnedUnit = Instantiate(trainPrefab, objectPos, Quaternion.identity);
            spawnedUnitEnum = unitEnum.train;
        }
        else if (gameObject.name == "CASTLEButton")
        {
            Debug.LogWarning("Instantiate Castle");
            spawnedUnit = Instantiate(castlePrefab, objectPos, Quaternion.identity);
            spawnedUnitEnum = unitEnum.castle;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.LogWarning("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.LogWarning("OnDrag");
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = mainCamera.ScreenToWorldPoint(mousePos);
        spawnedUnit.transform.position = objectPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.LogWarning("OnEndDrag");
        canvasGroup.blocksRaycasts = true;

        Vector2 ray = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(ray, ray);
        if (hit.transform != null)
        {
            Tile tileOnMouse = hit.collider.GetComponent<Tile>();
            
            Tile tileAbove;
            
            if (tileOnMouse.y + 1 < 10)
            {
                tileAbove = gridManager.GetTileAtPos(new Vector2(tileOnMouse.x, tileOnMouse.y + 1));
            }
            else
            {
                tileAbove = null;
            }


            Tile tileBelow;

            if (tileOnMouse.y - 1 > -1)
            {
                tileBelow = gridManager.GetTileAtPos(new Vector2(tileOnMouse.x, tileOnMouse.y - 1));
            }
            else
            {
                tileBelow = null;
            }


            Tile tileOnRight;

            if (tileOnMouse.x + 1 < 10)
            {
                tileOnRight = gridManager.GetTileAtPos(new Vector2(tileOnMouse.x + 1, tileOnMouse.y));
            }
            else
            {
                tileOnRight = null;
            }


            Tile tileOnLeft;

            if (tileOnMouse.x -1 > -1)
            {
                tileOnLeft = gridManager.GetTileAtPos(new Vector2(tileOnMouse.x - 1, tileOnMouse.y));
            }
            else
            {
                tileOnLeft = null;
            }


            Tile tileOnTwoRight;

            if (tileOnMouse.x + 2 < 10)
            {
                tileOnTwoRight = gridManager.GetTileAtPos(new Vector2(tileOnMouse.x + 2, tileOnMouse.y));
            }
            else
            {
                tileOnTwoRight = null;
            }


            Tile tileOnTwoLeft;

            if (tileOnMouse.x - 2 > -1)
            {
                tileOnTwoLeft = gridManager.GetTileAtPos(new Vector2(tileOnMouse.x - 2, tileOnMouse.y));
            }
            else
            {
                tileOnTwoLeft = null;
            }


            Tile tileOnTwoRightOneAbove;

            if (tileOnMouse.x + 2 < 10 && tileOnMouse.y + 1 < 10)
            {
                tileOnTwoRightOneAbove = gridManager.GetTileAtPos(new Vector2(tileOnMouse.x + 2, tileOnMouse.y + 1));
            }
            else
            {
                tileOnTwoRightOneAbove = null;
            }


            Tile tileOnTwoLeftOneAbove;

            if (tileOnMouse.x - 2 > -1 && tileOnMouse.y + 1 < 10)
            {
                tileOnTwoLeftOneAbove = gridManager.GetTileAtPos(new Vector2(tileOnMouse.x - 2, tileOnMouse.y + 1));
            }
            else
            {
                tileOnTwoLeftOneAbove = null;
            }



            switch (spawnedUnitEnum)
            {
                case unitEnum.pawn:

                    if (tileAbove == null)
                    {
                        Debug.LogWarning("CANTPLACE");
                        Destroy(spawnedUnit);
                        break;
                    }
                    else
                    {
                        if (!tileOnMouse.isOccupied && !tileAbove.isOccupied)
                        {
                            spawnedUnit.transform.position = tileOnMouse.transform.position;
                            tileOnMouse.isOccupied = true;
                            tileAbove.isOccupied = true;
                            break;
                        }
                        else
                        {
                            Destroy(spawnedUnit);
                            break;
                        }
                    }
                    
                case unitEnum.house:

                    if (!tileOnMouse.isOccupied)
                    {
                        spawnedUnit.transform.position = tileOnMouse.transform.position;
                        tileOnMouse.isOccupied = true;
                        break;
                    }
                    else
                    {
                        Destroy(spawnedUnit);
                        break;
                    }
                case unitEnum.flag:

                    if (tileAbove == null || tileBelow == null)
                    {
                        Debug.LogWarning("CANTPLACE");
                        Destroy(spawnedUnit);
                        break;
                    }
                    else
                    {
                        if (!tileOnMouse.isOccupied && !tileAbove.isOccupied && !tileBelow.isOccupied)
                        {
                            spawnedUnit.transform.position = tileOnMouse.transform.position;
                            tileOnMouse.isOccupied = true;
                            tileAbove.isOccupied = true;
                            tileBelow.isOccupied = true;
                            break;
                        }
                        else
                        {
                            Destroy(spawnedUnit);
                            break;
                        }
                    }

                case unitEnum.yacht:

                    if (tileOnRight == null || tileAbove == null)
                    {
                        Debug.LogWarning("CANTPLACE");
                        Destroy(spawnedUnit);
                        break;
                    }
                    else
                    {
                        if (!tileOnMouse.isOccupied && !tileAbove.isOccupied && !tileOnRight.isOccupied)
                        {
                            spawnedUnit.transform.position = tileOnMouse.transform.position;
                            tileOnMouse.isOccupied = true;
                            tileAbove.isOccupied = true;
                            tileOnRight.isOccupied = true;
                            break;
                        }
                        else
                        {
                            Destroy(spawnedUnit);
                            break;
                        }
                    }

                    
                case unitEnum.train:

                    if (tileOnRight == null || tileOnLeft == null)
                    {
                        Debug.LogWarning("CANTPLACE");
                        Destroy(spawnedUnit);
                        break;
                    }
                    else
                    {
                        if (!tileOnMouse.isOccupied && !tileOnLeft.isOccupied && !tileOnLeft.isOccupied)
                        {
                            spawnedUnit.transform.position = tileOnMouse.transform.position;
                            tileOnMouse.isOccupied = true;
                            tileOnRight.isOccupied = true;
                            tileOnLeft.isOccupied = true;
                            break;
                        }
                        else
                        {
                            Destroy(spawnedUnit);
                            break;
                        }
                    }
                    
                    
                case unitEnum.castle:

                    if (tileAbove == null || tileOnRight == null || tileOnLeft == null || tileOnTwoLeft == null ||
                        tileOnTwoRight == null || tileOnTwoLeftOneAbove == null || tileOnTwoRightOneAbove == null)
                    {
                        Debug.LogWarning("CANTPLACE");
                        Destroy(spawnedUnit);
                        break;
                    }
                    else
                    {
                        if (!tileOnMouse.isOccupied && !tileAbove.isOccupied && !tileOnRight.isOccupied && !tileOnLeft.isOccupied
                        && !tileOnTwoRight.isOccupied && !tileOnTwoLeft.isOccupied && !tileOnTwoRightOneAbove.isOccupied && !tileOnTwoLeftOneAbove.isOccupied)
                        {
                            spawnedUnit.transform.position = tileOnMouse.transform.position;
                            tileOnMouse.isOccupied = true;
                            tileAbove.isOccupied = true;
                            tileOnRight.isOccupied = true;
                            tileOnLeft.isOccupied = true;
                            tileOnTwoRight.isOccupied = true;
                            tileOnTwoLeft.isOccupied = true;
                            tileOnTwoRightOneAbove.isOccupied = true;
                            tileOnTwoLeftOneAbove.isOccupied = true;
                            break;
                        }
                        else
                        {
                            Destroy(spawnedUnit);
                            break;
                        }
                    }

                    

            }

        }
        else
        {
            Destroy(spawnedUnit);
        }
    }

    

}
