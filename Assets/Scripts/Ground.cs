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
		this.depth = a;

		if (a != 1 || a != 2)
			spriteRenderer.sprite = levels[0];
		else
			spriteRenderer.sprite = levels[a];
	}
	public int neighbourVerifySameDepth<T>(GameObject[][] cells, int x, int y)
	{
		Debug.Log(x + " asdasd " + y);
		int cont = 0;
		if (x > 0 && x < 91 && y < 51 && y > 0)
		{

			if (cells[x - 1][y] != null && cells[x - 1][y].GetComponent<T>() != null
				&& cells[x - 1][y].GetComponent<Ground>().depth == this.depth)
			{
				cont++;
			}
			if (cells[x - 1][y - 1] != null && cells[x - 1][y - 1].GetComponent<T>() != null
				&& cells[x - 1][y - 1].GetComponent<Ground>().depth == this.depth)
			{
				cont++;
			}
			if (cells[x][y - 1] != null && cells[x][y - 1].GetComponent<T>() != null
				&& cells[x][y - 1].GetComponent<Ground>().depth == this.depth)
			{
				cont++;
			}
			if (cells[x + 1][y - 1] != null && cells[x + 1][y - 1].GetComponent<T>() != null
				&& cells[x + 1][y - 1].GetComponent<Ground>().depth == this.depth)
			{
				cont++;
			}
			if (cells[x + 1][y] != null && cells[x + 1][y].GetComponent<T>() != null
				&& cells[x + 1][y].GetComponent<Ground>().depth == this.depth)
			{
				cont++;
			}
			if (cells[x + 1][y + 1] != null && cells[x + 1][y + 1].GetComponent<T>() != null
				&& cells[x + 1][y + 1].GetComponent<Ground>().depth == this.depth)
			{
				cont++;
			}
			if (cells[x][y + 1] != null && cells[x][y + 1].GetComponent<T>() != null
				&& cells[x][y + 1].GetComponent<Ground>().depth == this.depth)
			{
				cont++;
			}
			if (cells[x - 1][y + 1] != null && cells[x - 1][y + 1].GetComponent<T>() != null
				&& cells[x - 1][y + 1].GetComponent<Ground>().depth == this.depth)
			{
				cont++;
			}
		}
		Debug.Log(x + " asdasd " + y + " " + cont);
		return cont;
	}
}
