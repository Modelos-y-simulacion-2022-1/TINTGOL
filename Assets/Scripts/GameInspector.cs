using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInspector : MonoBehaviour
{
    private int SCREEN_WIDTH = 91;//1920 pixeles, 90 unidades
    private int SCREEN_HEIGHT = 51;
    public GameObject mouseImput;
    public GameObject inspector;
    public GameObject menu;
    public GameObject[] gameObject;
    public GameObject[][] ground, water;
    public int mouseX;
    public int mouseY;
    public int[,] map;
    // Start is called before the first frame update
    void Start()
    {
        ground = new GameObject[SCREEN_WIDTH + 1][];
        water = new GameObject[SCREEN_WIDTH + 1][];
        for (int i=0;i< ground.Length;i++)
        {
            ground[i]=new GameObject[SCREEN_HEIGHT + 1];
            water[i] = new GameObject[SCREEN_HEIGHT + 1];
            map = inspector.GetComponent<MapGenerator>().GenerateMap();
            for (int j=0;j< SCREEN_HEIGHT + 1; j++)
            {
                if(map[i,j]==0)
                ground[i][j] = Instantiate(gameObject[0], new Vector3(i, j, 0), Quaternion.identity);
                else
                    ground[i][j] = Instantiate(gameObject[1], new Vector3(i, j, 0), Quaternion.identity);
                int r= Random.Range(0,6);
            }
        }
        Cursor.visible = false;
        menu.SetActive(false);
        setCellvalueComplex(ground);
        setCellvalueComplex(ground);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseP = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mouseP);
        mouseX = (int)Mathf.Floor(worldPosition.x);     
        mouseY = (int)Mathf.Floor(worldPosition.y);
        mouseImput.transform.position =new Vector3(mouseX, mouseY, -1);//mouse que se mueve de manera discreta
        if (Input.GetMouseButtonDown(0))
        {
            if (mouseX >= 0 && mouseX <= SCREEN_WIDTH && mouseY <= SCREEN_HEIGHT && mouseY >= 0)
            {
                water[mouseX][mouseY] = Instantiate(gameObject[1], new Vector3(mouseX, mouseY, -3), Quaternion.identity);
                water[mouseX][mouseY].GetComponent<Water>().setAmount(20);
                //water[mouseX][mouseY].GetComponent<Water>().water(water, mouseX, mouseY);
                
            }
            else
                Debug.Log("fuera de rango.");
        }
            

        if (Input.GetMouseButtonDown(1))
        {
            if (mouseX >= 0 && mouseX <= SCREEN_WIDTH && mouseY <= SCREEN_HEIGHT && mouseY >= 0)
                Destroy(water[mouseX][mouseY]);
            else
                Debug.Log("fuera de rango.");
        }
        if (Input.GetKeyDown("escape"))
        {
            if (menu.active == true)
            {
                menu.SetActive(false);
            }
            else 
                menu.SetActive(true);
        }
        checkWater();
    }
    void setCellvalue(GameObject[][] ground)
    {
        for (int i = 0; i < ground.Length; i++)
        {
            for (int j = 0; j < ground[i].Length; j++)
            {
                if (ground[i][j]!=null)
                {
                    
                    if (ground[i][j].GetComponent<Water>() != null)
                    {
                        int numNeigh = ground[i][j].GetComponent<Water>().neighbourVerify<Water>(ground, i, j);
                        if (numNeigh < 4)
                            ground[i][j].GetComponent<Water>().setAmount(0);
                        else if (numNeigh <7)
                            ground[i][j].GetComponent<Water>().setAmount(1);
                        else
                            ground[i][j].GetComponent<Water>().setAmount(2);
                    }
                    else
                    {
                        int numNeigh = ground[i][j].GetComponent<Ground>().neighbourVerify<Ground>(ground, i, j);
                        if (numNeigh < 4)
                            ground[i][j].GetComponent<Ground>().setDepth(0);
                        else if (numNeigh < 7)
                            ground[i][j].GetComponent<Ground>().setDepth(1);
                        else
                            ground[i][j].GetComponent<Ground>().setDepth(2);
                    }
                }
            }
        }
    }//basico
    void setCellvalueComplex(GameObject[][] ground)
    {
        for (int i = 0; i < ground.Length; i++)
        {
            for (int j = 0; j < ground[i].Length; j++)
            {
                if (ground[i][j] != null)
                {
                    
                    if ((ground[i][j].GetComponent<Water>())as Water != null)
                    {
                        int numNeigh = ground[i][j].GetComponent<Water>().neighbourVerifySameAmount<Water>(ground, i, j);
                        if (numNeigh < 4)
                            ground[i][j].GetComponent<Water>().setAmount(0);
                        else if (numNeigh < 6)
                            ground[i][j].GetComponent<Water>().setAmount(1);
                        else
                            ground[i][j].GetComponent<Water>().setAmount(2);
                    }
                    else
                    {
                        int numNeigh = ground[i][j].GetComponent<Ground>().neighbourVerifySameDepth<Ground>(ground, i, j);
                        if (numNeigh < 4)
                            ground[i][j].GetComponent<Ground>().setDepth(0);
                        else if (numNeigh < 7)
                            ground[i][j].GetComponent<Ground>().setDepth(1);
                        else
                            ground[i][j].GetComponent<Ground>().setDepth(2);
                    }
                }
            }
        }
    }//basico
    void checkWater()
    {
        int cont = 0;
        for (int i = 0; i < water.Length; i++)
        {
            cont++;
            for (int j = 0; j < water[i].Length; j++)
            {
                cont++;
                if (water[i][j] != null)
                {
                    water[i][j].GetComponent<Water>().water(water,i,j,cont%4);
                }
            }
        }
    }

}
