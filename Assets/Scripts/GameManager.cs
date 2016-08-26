using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	private const int kMAX_TANKS = 10;
	// which tank is currently selected
	private GameObject currentTank = null;

	// all the tank objects on the page
	private GameObject[] tanks = new GameObject[kMAX_TANKS];

	// the select box to go around tanks
	private GameObject tankSelectBox;

	public GameObject tankPrefab;
	public GameObject tankSelectBoxPrefab;

	public void Start()
	{
		// create tank select box
		tankSelectBox = (GameObject)Instantiate(tankSelectBoxPrefab);

		Vector3[] startingPositions = new Vector3[kMAX_TANKS];
		startingPositions[0] = new Vector3(340, 812, 0);
		startingPositions[1] = new Vector3(340, 1012, 0);
		startingPositions[2] = new Vector3(340, 1212, 0);

		startingPositions[3] = new Vector3(1340, 812, 0);
		startingPositions[4] = new Vector3(1340, 1012, 0);
		startingPositions[5] = new Vector3(1340, 1212, 0);


		// create tanks
		for (int count = 0; count < 6; count++) {
			tanks[count] = (GameObject)Instantiate(tankPrefab);
			tanks[count].GetComponent<Tank>().Init(this);
			tanks[count].GetComponent<SpriteRenderer>().transform.position = startingPositions[count];
			if (count >= 3) {
				tanks[count].GetComponent<SpriteRenderer>().transform.rotation = Quaternion.Euler(0, 0, -90);
			}
		}

		selectTank(tanks[0]);
	}

	public void selectTank(GameObject tank)
	{
		currentTank = tank;
		SpriteRenderer spriteRenderer = getCurrentTank();
		tankSelectBox.transform.position = spriteRenderer.transform.position;
	}

	public SpriteRenderer getCurrentTank()
	{
		return currentTank.GetComponent<SpriteRenderer>();
	}
}
