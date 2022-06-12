using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInspector : MonoBehaviour
{
    private int SCREEN_WIDTH = 91;//1920 pixeles, 90 unidades
    private int SCREEN_HEIGHT = 51;
    public GameObject mouseImput;
    public GameObject[] gameObject;
    public GameObject[][] gameObject2;
    public int mouseX;
    public int mouseY;
    // Start is called before the first frame update
    void Start()
    {
        gameObject2 = new GameObject[SCREEN_WIDTH+1][];
        for (int i=0;i<gameObject2.Length;i++)
        {
            gameObject2[i]=new GameObject[SCREEN_HEIGHT+1];
            for (int j=0;j< SCREEN_HEIGHT + 1; j++)
            {
                int r= Random.Range(0,6);
                gameObject2[i][j] = Instantiate(gameObject[r], new Vector3(i, j, 0), Quaternion.identity);
            }
        }
        Cursor.visible = false;
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
                gameObject2[mouseX][mouseY] = Instantiate(gameObject[0], new Vector3(mouseX,mouseY, 0), Quaternion.identity);
            else
                Debug.Log("fuera de rango.");
        }
            

        if (Input.GetMouseButtonDown(1))
        {
            if (mouseX >= 0 && mouseX <= SCREEN_WIDTH && mouseY <= SCREEN_HEIGHT && mouseY >= 0)
                Destroy(gameObject2[mouseX][mouseY]);
            else
                Debug.Log("fuera de rango.");
        }
            

    }
}
