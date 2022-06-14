using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    // Start is called before the first frame update    
    void Start()
    {

    }
    // count obcjects of a multidimensional array                  
    public int neighbourVerify<T>(GameObject[][] cells, int x, int y)
    {
        Debug.Log(x + " " + y);
        int cont = 0;
        if (x > 0 && x < 91 && y < 51 && y > 0)
        {

            if (cells[x - 1][y] != null && cells[x - 1][y].GetComponent<T>() != null)
                cont++;
            if (cells[x - 1][y - 1] != null && cells[x - 1][y - 1].GetComponent<T>() != null)
                cont++;
            if (cells[x][y - 1] != null && cells[x][y - 1].GetComponent<T>() != null)
                cont++;
            if (cells[x + 1][y - 1] != null && cells[x + 1][y - 1].GetComponent<T>() != null)
                cont++;
            if (cells[x + 1][y] != null && cells[x + 1][y].GetComponent<T>() != null)
                cont++;
            if (cells[x + 1][y + 1] != null && cells[x + 1][y + 1].GetComponent<T>() != null)
                cont++;
            if (cells[x][y + 1] != null && cells[x][y + 1].GetComponent<T>() != null)
                cont++;
            if (cells[x - 1][y + 1] != null && cells[x - 1][y + 1].GetComponent<T>() != null)
                cont++;
        }
        return cont;
    }


}
