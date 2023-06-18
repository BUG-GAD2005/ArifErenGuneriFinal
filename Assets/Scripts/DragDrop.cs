using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public BuildingType buildingType;
    
    //Prefabs to spawn
    [SerializeField] private GameObject pawnPrefab;
    [SerializeField] private GameObject housePrefab;
    [SerializeField] private GameObject flagPrefab;
    [SerializeField] private GameObject yachtPrefab;
    [SerializeField] private GameObject trainPrefab;
    [SerializeField] private GameObject castlePrefab;

    //Scriptable object references in order to check if the player can afford the cost.
    [SerializeField] private Building_SO pawnData;
    [SerializeField] private Building_SO houseData;
    [SerializeField] private Building_SO flagData;
    [SerializeField] private Building_SO yachtData;
    [SerializeField] private Building_SO trainData;
    [SerializeField] private Building_SO castleData;

    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Camera mainCamera;
    [SerializeField] GameObject blocker;

    private CanvasGroup canvasGroup;
    private GridManager gridManager;
    private bool isAffordable;
    public GameObject spawnedUnit;
    private Building building;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        gridManager = FindObjectOfType<GridManager>();
    }

    private void Update()
    {
        CheckIfAffordable();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.LogWarning("OnPointerDown");

        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = mainCamera.ScreenToWorldPoint(mousePos);
        SpawnIfAffordable(objectPos);

    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.LogWarning("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;

        if (spawnedUnit!= null)
        {
            building = spawnedUnit.GetComponent<Building>();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragSpawnedBuilding();
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.LogWarning("OnEndDrag");
        canvasGroup.blocksRaycasts = true;

        if (spawnedUnit!= null)
        {
            CheckTilesAndPlaceBuilding();
        }
    }
    
    private void CheckIfAffordable()
    {
        switch (buildingType)
        {
            case BuildingType.pawn:

                if (playerStats.currentCoin < pawnData.coinCost)
                {
                    blocker.SetActive(true);
                    isAffordable = false;
                    break;
                }
                else
                {
                    blocker.SetActive(false);
                    isAffordable = true;
                    break;
                }


            case BuildingType.house:

                if (playerStats.currentCoin < houseData.coinCost || playerStats.currentGem < houseData.gemCost)
                {
                    blocker.SetActive(true);
                    isAffordable = false;
                    break;
                }
                else
                {
                    blocker.SetActive(false);
                    isAffordable = true;
                    break;
                }

            case BuildingType.flag:

                if (playerStats.currentCoin < flagData.coinCost || playerStats.currentGem < flagData.gemCost)
                {
                    blocker.SetActive(true);
                    isAffordable = false;
                    break;
                }
                else
                {
                    blocker.SetActive(false);
                    isAffordable = true;
                    break;
                }

            case BuildingType.yacht:

                if (playerStats.currentCoin < yachtData.coinCost || playerStats.currentGem < yachtData.gemCost)
                {
                    blocker.SetActive(true);
                    isAffordable = false;
                    break;
                }
                else
                {
                    blocker.SetActive(false);
                    isAffordable = true;
                    break;
                }

            case BuildingType.train:

                if (playerStats.currentCoin < trainData.coinCost || playerStats.currentGem < trainData.gemCost)
                {
                    blocker.SetActive(true);
                    isAffordable = false;
                    break;
                }
                else
                {
                    blocker.SetActive(false);
                    isAffordable = true;
                    break;
                }

            case BuildingType.castle:

                if (playerStats.currentCoin < castleData.coinCost || playerStats.currentGem < castleData.gemCost)
                {
                    blocker.SetActive(true);
                    isAffordable = false;
                    break;
                }
                else
                {
                    blocker.SetActive(false);
                    isAffordable = true;
                    break;
                }
        }
    }
    
    private void SpawnIfAffordable(Vector3 objectPos)
    {
        switch (buildingType)
        {
            case BuildingType.pawn:

                if (isAffordable)
                {
                    Debug.LogWarning("Instantiate Pawn");
                    spawnedUnit = Instantiate(pawnPrefab, objectPos, Quaternion.identity);
                    break;
                }
                else
                {
                    Debug.LogWarning("CANT BUY!");
                    break;
                }


            case BuildingType.house:

                if (isAffordable)
                {
                    Debug.LogWarning("Instantiate House");
                    spawnedUnit = Instantiate(housePrefab, objectPos, Quaternion.identity);
                    break;
                }
                else
                {
                    Debug.LogWarning("CANT BUY!");
                    break;
                }

            case BuildingType.flag:

                if (isAffordable)
                {
                    Debug.LogWarning("Instantiate Flag");
                    spawnedUnit = Instantiate(flagPrefab, objectPos, Quaternion.identity);
                    break;
                }
                else
                {
                    Debug.LogWarning("CANT BUY!");
                    break;
                }

            case BuildingType.yacht:

                if (isAffordable)
                {
                    Debug.LogWarning("Instantiate Yacht");
                    spawnedUnit = Instantiate(yachtPrefab, objectPos, Quaternion.identity);
                    break;
                }
                else
                {
                    Debug.LogWarning("CANT BUY!");
                    break;
                }

            case BuildingType.train:

                if (isAffordable)
                {
                    Debug.LogWarning("Instantiate Train");
                    spawnedUnit = Instantiate(trainPrefab, objectPos, Quaternion.identity);
                    break;
                }
                else
                {
                    Debug.LogWarning("CANT BUY!");
                    break;
                }

            case BuildingType.castle:

                if (isAffordable)
                {
                    Debug.LogWarning("Instantiate Castle");
                    spawnedUnit = Instantiate(castlePrefab, objectPos, Quaternion.identity);
                    break;
                }
                else
                {
                    Debug.LogWarning("CANT BUY!");
                    break;
                }
        }
    }
    
    private void DragSpawnedBuilding()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = mainCamera.ScreenToWorldPoint(mousePos);

        if (spawnedUnit!= null)
        {
            spawnedUnit.transform.position = objectPos;
        }
        
    }

    private void CheckTilesAndPlaceBuilding()
    {
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

            if (tileOnMouse.x - 1 > -1)
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



            switch (buildingType)
            {
                case BuildingType.pawn:

                    if (tileAbove == null)
                    {
                        Debug.LogWarning("CANTPLACE");
                        Destroy(spawnedUnit);
                        break;
                    }
                    else
                    {
                        if (!tileOnMouse.isOccupied && !tileAbove.isOccupied) // If the tiles are available, puts the spawned unit to those tiles.
                        {
                            spawnedUnit.transform.position = tileOnMouse.transform.position;
                            tileOnMouse.isOccupied = true;
                            tileAbove.isOccupied = true;
                            building.isPlaced = true;
                            playerStats.currentCoin -= pawnData.coinCost;
                            playerStats.coinText.text = playerStats.currentCoin.ToString();
                            break;
                        }
                        else
                        {
                            Destroy(spawnedUnit);
                            break;
                        }
                    }

                case BuildingType.house:

                    if (!tileOnMouse.isOccupied) // If the tiles are available, puts the spawned unit to those tiles.
                    {
                        spawnedUnit.transform.position = tileOnMouse.transform.position;
                        tileOnMouse.isOccupied = true;
                        building.isPlaced = true;
                        playerStats.currentCoin -= houseData.coinCost;
                        playerStats.currentGem -= houseData.gemCost;
                        playerStats.coinText.text = playerStats.currentCoin.ToString();
                        playerStats.gemText.text = playerStats.currentGem.ToString();
                        break;
                    }
                    else
                    {
                        Destroy(spawnedUnit);
                        break;
                    }
                case BuildingType.flag:

                    if (tileAbove == null || tileBelow == null)
                    {
                        Debug.LogWarning("CANTPLACE");
                        Destroy(spawnedUnit);
                        break;
                    }
                    else
                    {
                        if (!tileOnMouse.isOccupied && !tileAbove.isOccupied && !tileBelow.isOccupied) // If the tiles are available, puts the spawned unit to those tiles.
                        {
                            spawnedUnit.transform.position = tileOnMouse.transform.position;
                            tileOnMouse.isOccupied = true;
                            tileAbove.isOccupied = true;
                            tileBelow.isOccupied = true;
                            building.isPlaced = true;
                            playerStats.currentCoin -= flagData.coinCost;
                            playerStats.currentGem -= flagData.gemCost;
                            playerStats.coinText.text = playerStats.currentCoin.ToString();
                            playerStats.gemText.text = playerStats.currentGem.ToString();
                            break;
                        }
                        else
                        {
                            Destroy(spawnedUnit);
                            break;
                        }
                    }

                case BuildingType.yacht:

                    if (tileOnRight == null || tileAbove == null)
                    {
                        Debug.LogWarning("CANTPLACE");
                        Destroy(spawnedUnit);
                        break;
                    }
                    else
                    {
                        if (!tileOnMouse.isOccupied && !tileAbove.isOccupied && !tileOnRight.isOccupied) // If the tiles are available, puts the spawned unit to those tiles.
                        {
                            spawnedUnit.transform.position = tileOnMouse.transform.position;
                            tileOnMouse.isOccupied = true;
                            tileAbove.isOccupied = true;
                            tileOnRight.isOccupied = true;
                            building.isPlaced = true;
                            playerStats.currentCoin -= yachtData.coinCost;
                            playerStats.currentGem -= yachtData.gemCost;
                            playerStats.coinText.text = playerStats.currentCoin.ToString();
                            playerStats.gemText.text = playerStats.currentGem.ToString();
                            break;
                        }
                        else
                        {
                            Destroy(spawnedUnit);
                            break;
                        }
                    }


                case BuildingType.train:

                    if (tileOnRight == null || tileOnLeft == null)
                    {
                        Debug.LogWarning("CANTPLACE");
                        Destroy(spawnedUnit);
                        break;
                    }
                    else
                    {
                        if (!tileOnMouse.isOccupied && !tileOnLeft.isOccupied && !tileOnLeft.isOccupied) // If the tiles are available, puts the spawned unit to those tiles.
                        {
                            spawnedUnit.transform.position = tileOnMouse.transform.position;
                            tileOnMouse.isOccupied = true;
                            tileOnRight.isOccupied = true;
                            tileOnLeft.isOccupied = true;
                            building.isPlaced = true;
                            playerStats.currentCoin -= trainData.coinCost;
                            playerStats.currentGem -= trainData.gemCost;
                            playerStats.coinText.text = playerStats.currentCoin.ToString();
                            playerStats.gemText.text = playerStats.currentGem.ToString();
                            break;
                        }
                        else
                        {
                            Destroy(spawnedUnit);
                            break;
                        }
                    }


                case BuildingType.castle:

                    if (tileAbove == null || tileOnRight == null || tileOnLeft == null || tileOnTwoLeft == null ||
                        tileOnTwoRight == null || tileOnTwoLeftOneAbove == null || tileOnTwoRightOneAbove == null)
                    {
                        Debug.LogWarning("CANTPLACE");
                        Destroy(spawnedUnit);
                        break;
                    }
                    else
                    {
                        // If the tiles are available, puts the spawned unit to those tiles.
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
                            building.isPlaced = true;
                            playerStats.currentCoin -= castleData.coinCost;
                            playerStats.currentGem -= castleData.gemCost;
                            playerStats.coinText.text = playerStats.currentCoin.ToString();
                            playerStats.gemText.text = playerStats.currentGem.ToString();
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
