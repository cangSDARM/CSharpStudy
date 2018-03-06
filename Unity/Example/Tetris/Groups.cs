using UnityEngine;

public class Groups : MonoBehaviour {

	float lastFall;

	private void Start() {
		if (!isValidGridPos()) {
			Debug.Log("GAME OVER");
		}
	}

	private void Update() {

		//if the gameObject can move, transform and update data. if not, transform back

		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			transform.position += new Vector3(-1f, 0f, 0f);

			if (isValidGridPos()) {
				updateGrid();
			} else {
				transform.position += new Vector3(1f, 0f, 0f);
			}
		}

		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			transform.position += new Vector3(1f, 0f, 0f);

			if (isValidGridPos()) {
				updateGrid();
			} else {
				transform.position += new Vector3(-1f, 0f, 0f);
			}
		}

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			transform.Rotate(0f, 0f, 90f);

			if (isValidGridPos()) {
				updateGrid();
			} else {
				transform.Rotate(0f, 0f, -90f);
			}
		}

		if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastFall >= 1) {
			transform.position += new Vector3(0f, -1f, 0f);
			lastFall = Time.time;

			if (isValidGridPos()) {
				updateGrid();
			} else {
				transform.position += new Vector3(0f, 1f, 0f);

				Grid.delateFullRows();

				FindObjectOfType<Spawner>().spawnNext();
				enabled = false;
			}
		}
	}

	//back true if player can still put the gameObject
	private bool isValidGridPos() {
		foreach(Transform child in transform) {
			var v = Grid.roundVector2(child.position);

			if (!Grid.insider(v)) {
				return false;
			}
			
			if(Grid.grid[(int)(v.x + 4),(int)v.y] != null && Grid.grid[(int)(v.x + 4), (int)v.y].parent != transform) {
				Debug.Log("Now, grid is't null");
				return false;
			}
		}

		return true;
	}

	//update the gameObject position data to Grid.grid[][]
	void updateGrid() {
		for(int y = 0; y < Grid.h; y++) {
			for(int x = 0; x < Grid.w; x++) {
				if(Grid.grid[x,y] != null && Grid.grid[x, y].parent == transform) {
					Grid.grid[x, y] = null;
				}
			}
		}

		foreach(Transform child in transform) {
			var v = Grid.roundVector2(child.position);
			Grid.grid[(int)(v.x + 4), (int)v.y] = child;
		}
	}
}
