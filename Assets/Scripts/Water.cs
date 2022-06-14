using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Cell
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] levels;
    public int amount;
    // Start is called before the first frame update
    public void setAmount(int a)
    {
        if (a>3)
        {
            spriteRenderer.sprite = levels[2];
        }
        else if (a > 1)
        {
            spriteRenderer.sprite = levels[1];
        }
        else
        {
            spriteRenderer.sprite = levels[0];
        }
        amount = a;
    }
    public int neighbourVerifySameAmount<T>(GameObject[][] cells, int x, int y)
    {
        Debug.Log(x + " asdasd " + y);
        int cont = 0;
        if (x > 0 && x < 91 && y < 51 && y > 0)
        {

            if (cells[x - 1][y] != null && cells[x - 1][y].GetComponent<T>() != null)
            {
                if (cells[x - 1][y].GetComponent<Water>().amount == this.amount)
                    cont++;
            }
            if (cells[x - 1][y - 1] != null && cells[x - 1][y - 1].GetComponent<T>() != null)
            {
                if (cells[x - 1][y - 1].GetComponent<Water>().amount == this.amount)
                    cont++;
            }
            if (cells[x][y - 1] != null && cells[x][y - 1].GetComponent<T>() != null)
            {
                if (cells[x][y - 1].GetComponent<Water>().amount == this.amount)
                    cont++;
            }
            if (cells[x + 1][y - 1] != null && cells[x + 1][y - 1].GetComponent<T>() != null)
            {
                if (cells[x + 1][y - 1].GetComponent<Water>().amount == this.amount)
                    cont++;
            }
            if (cells[x + 1][y] != null && cells[x + 1][y].GetComponent<T>() != null)
            {
                if (cells[x + 1][y].GetComponent<Water>().amount == this.amount)
                    cont++;
            }
            if (cells[x + 1][y + 1] != null && cells[x + 1][y + 1].GetComponent<T>() != null)
            {
                if (cells[x + 1][y + 1].GetComponent<Water>().amount == this.amount)
                    cont++;
            }
            if (cells[x][y + 1] != null && cells[x][y + 1].GetComponent<T>() != null)
            {
                if (cells[x][y + 1].GetComponent<Water>().amount == this.amount)
                    cont++;
            }
            if (cells[x - 1][y + 1] != null && cells[x - 1][y + 1].GetComponent<T>() != null)
            {
                if (cells[x - 1][y + 1].GetComponent<Water>().amount == this.amount)
                    cont++;
            }
        }
        Debug.Log(x + " asdasd " + y + " " + cont);
        return cont;
    }
    void waterInstantiate(GameObject[][] cells, int x, int y,int xincrease, int yincrease)
    {
        cells[x + xincrease][y+yincrease] = Instantiate(cells[x][y], new Vector3(x + xincrease, y+yincrease, -3), Quaternion.identity);
        cells[x + xincrease][y + yincrease].GetComponent<Water>().setAmount(1); 
    }
    public void water1(GameObject[][] cells,int x, int y) {// no tiene encuenta a las otras celulas 
        if (amount > 0)
        {
            this.setAmount(this.amount - 1);
            waterInstantiate(cells, x, y, 0, -1);
            waterInstantiate(cells, x, y, 0, 1);
            waterInstantiate(cells, x, y, 1, 0);
            waterInstantiate(cells, x, y, -1, 0);
        }
    }
    void waterIC(GameObject[][] cells, int x, int y, int xincrease, int yincrease)
    {
        if (cells[x + xincrease][y +  yincrease] == null)
        {
            waterInstantiate(cells, x, y, xincrease, yincrease);
            cells[x][y].GetComponent<Water>().setAmount(cells[x][y].GetComponent<Water>().amount - 1);            
        }
        else
        {
            if (cells[x + xincrease][y + yincrease].GetComponent<Water>().amount < this.amount)
            {
                cells[x + xincrease][y + yincrease].GetComponent<Water>().setAmount(cells[x + xincrease][y + yincrease].GetComponent<Water>().amount + 1);
                cells[x][y].GetComponent<Water>().setAmount(cells[x][y].GetComponent<Water>().amount - 1);
            }
        }
    }
    public void water(GameObject[][] cells, int x, int y,int mod)
    {
        if (amount > 1)
        {
            Debug.Log("water" + cells[x][y].GetComponent<Water>().amount);
            if (mod == 0)
            {
                waterIC(cells, x, y, 0, -1);
                waterIC(cells, x, y, 0, 1);
                waterIC(cells, x, y, -1, 0);
                waterIC(cells, x, y, 1, 0);
                
            }
            else if (mod == 1)
            {
                waterIC(cells, x, y, -1, 0);
                waterIC(cells, x, y, 1, 0);
                waterIC(cells, x, y, 0, 1);
                waterIC(cells, x, y, 0, -1);
                
            }
            else if (mod == 2)
            {
                waterIC(cells, x, y, 1, 0);
                waterIC(cells, x, y, -1, 0);
                waterIC(cells, x, y, 0, 1);
                waterIC(cells, x, y, 0, -1);
                
            }
            else
            {
                waterIC(cells, x, y, 0, 1);
                waterIC(cells, x, y, 0, -1);
                waterIC(cells, x, y, -1, 0);
                waterIC(cells, x, y, 1, 0);
            }

          
            Debug.Log("water2" + cells[x][y].GetComponent<Water>().amount);
        }
    }


    
}
