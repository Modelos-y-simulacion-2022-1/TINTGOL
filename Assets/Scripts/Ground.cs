using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : Cell
{

	public Sprite[] levels;
	public int depth;
	public SpriteRenderer spriteRenderer;
	// Start is called before the first frame update
	public void setDepth(int a)
	{
		depth = a;
		if (a == 2)
		{
			spriteRenderer.sprite = levels[2];

		}
		else if (a == 1)
		{
			spriteRenderer.sprite = levels[1];
		}
		else
		{
			spriteRenderer.sprite = levels[0];
		}
	}
	public int neighbourVerifySameDepth<T>(GameObject[][] cells, int x, int y)
	{
		Debug.Log(x + " asdasd " + y);
		int cont = 0;
		if (x > 0 && x < 91 && y < 51 && y > 0)
		{

			if (cells[x - 1][y] != null && cells[x - 1][y].GetComponent<T>() != null)
			{
				if (cells[x - 1][y].GetComponent<Ground>().depth == this.depth)
					cont++;
			}
			if (cells[x - 1][y - 1] != null && cells[x - 1][y - 1].GetComponent<T>() != null)
			{
				if (cells[x - 1][y - 1].GetComponent<Ground>().depth == this.depth)
					cont++;
			}
			if (cells[x][y - 1] != null && cells[x][y - 1].GetComponent<T>() != null)
			{
				if (cells[x][y - 1].GetComponent<Ground>().depth == this.depth)
					cont++;
			}
			if (cells[x + 1][y - 1] != null && cells[x + 1][y - 1].GetComponent<T>() != null)
			{
				if (cells[x + 1][y - 1].GetComponent<Ground>().depth == this.depth)
					cont++;
			}
			if (cells[x + 1][y] != null && cells[x + 1][y].GetComponent<T>() != null)
			{
				if (cells[x + 1][y].GetComponent<Ground>().depth == this.depth)
					cont++;
			}
			if (cells[x + 1][y + 1] != null && cells[x + 1][y + 1].GetComponent<T>() != null)
			{
				if (cells[x + 1][y + 1].GetComponent<Ground>().depth == this.depth)
					cont++;
			}
			if (cells[x][y + 1] != null && cells[x][y + 1].GetComponent<T>() != null)
			{
				if (cells[x][y + 1].GetComponent<Ground>().depth == this.depth)
					cont++;
			}
			if (cells[x - 1][y + 1] != null && cells[x - 1][y + 1].GetComponent<T>() != null)
			{
				if (cells[x - 1][y + 1].GetComponent<Ground>().depth == this.depth)
					cont++;
			}
		}
		Debug.Log(x + " asdasd " + y + " " + cont);
		return cont;
	}
}
