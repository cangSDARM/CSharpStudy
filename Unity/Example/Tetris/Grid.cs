using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

	public static int w = 10;
	public static int h = 20;

	//converts the scene to a tow-dimensional array
	public static Transform[,] grid = new Transform[w, h];

	//back the integer which is more close to positive even
	public static Vector2 roundVector2(Vector3 v) {
		return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
	}

	//back true if the model in the border
	public static bool insider(Vector3 v) {
		return ((int)v.x >= -4 && (int)v.x <= 5 && (int)v.y >= 0);
	}

	//back true if the row is full
	public static bool isRowFull(int y) {
		for(int i = 0; i < w; i++) {
			if (grid[i, y] == null) return false;
		}

		return true;
	}


	//when delate a row, let its up-row drop down.
	public static void decreaseRowAbove(int _y) {
		for(int y = _y; y < h; y++) {
			for(int x = 0; x < w; x++) {
				//if up-row != null
				if (grid[x, y] != null) {

					//duplicate up-row data to this row
					grid[x, y - 1] = grid[x,y];
					
					//delate up-row data
					grid[x, y] = null;

					//visual drop-effect
					grid[x, y - 1].position += new Vector3(0f, -1f, 0f);
				}
			}
		}
	}

	//delate rows when it's full
	public static void delateFullRows() {
		for(int y = 0; y < h; ) {
			if (isRowFull(y)) {

				//destroy this full row, then empty data
				for (int i = 0; i < w; i++) {
					Destroy(grid[i, y].gameObject);
					grid[i, y] = null;
				}

				decreaseRowAbove(y + 1);
			} else {
				y++;
			}
		}
	}
}
