using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInspector : MonoBehaviour
{
    private int SCREEN_WIDTH = 90;//1920 pixeles, 90 unidades
    private int SCREEN_HEIGHT = 50;
    public GameObject mouseImput;
    public GameObject[] gameObject;
    public GameObject[][] gameObject2;
    public float mouseX;
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
                if ((i + j) % 3 == 0)
                {
                    //gameObject2[i][j] = Instantiate(gameObject[0], new Vector3(i, j, 0), Quaternion.identity);
                }
                else if ((i + j) % 2 == 0)
                {
                   // gameObject2[i][j] = Instantiate(gameObject[1], new Vector3(i, j, 0), Quaternion.identity);
                }
                else
                {
                    //gameObject2[i][j] = Instantiate(gameObject[2], new Vector3(i, j, 0), Quaternion.identity);
                }
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
        mouseImput.transform.position =new Vector3((int)Mathf.Floor(worldPosition.x), (int)Mathf.Floor(worldPosition.y), 0);
        if (Input.GetMouseButtonDown(0))
        {
            if (mouseX > 0 && mouseX <= 1920 && mouseY > 0 && mouseY <= 1080) {
                Debug.Log("Pressed primary button."); 
                Debug.Log((int)Mathf.Floor(worldPosition.x));
                Debug.Log((int)Mathf.Floor(worldPosition.y));
                if((int)Mathf.Floor(worldPosition.x)>0&& (int)Mathf.Floor(worldPosition.y)>0)
                    gameObject2[(int)Mathf.Floor(worldPosition.x)][(int)Mathf.Floor(worldPosition.y)] = Instantiate(gameObject[0], new Vector3(Mathf.Floor(worldPosition.x), Mathf.Floor(worldPosition.y), 0), Quaternion.identity);
            }
            else
                Debug.Log("fuera de rango.");
        }
            

        if (Input.GetMouseButtonDown(1))
        {
            if (mouseX > 0 && mouseX <= 1920 && mouseY > 0 && mouseY <= 1080)
            {
                Debug.Log("Pressed secundary button.");
                Debug.Log((int)Mathf.Floor(worldPosition.x));
                Debug.Log((int)Mathf.Floor(worldPosition.y));
                if ((int)Mathf.Floor(worldPosition.x) > 0 && (int)Mathf.Floor(worldPosition.y) > 0)
                Destroy(gameObject2[(int)Mathf.Floor(worldPosition.x)][(int)Mathf.Floor(worldPosition.y)]);
            }
            else
                Debug.Log("fuera de rango.");
        }
            

    }
}
