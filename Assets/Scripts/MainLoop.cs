using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainLoop: MonoBehaviour {
	
	// Array of 3 gameObjects randomly generate stones with random material
	public GameObject[] stones = new GameObject[3];
	public float torque = 5.0f; //torque force make our object to rotate
	public float minAntiGravity = 20.0f, maxAntiGravity = 40.0f; //Random numbers to min to max to unpredict the next stone
	public float minLateralForce = -15.0f, maxLateralForce = 15.0f; // lateral force to push stone to right +ve or left -ve
	public float minTimeBetweenStones = 1f, maxTimeBetweenStones = 3f; //timing will be random from 1 to 3 seconds
	public float minX = -30.0f, maxX = 30.0f; //randomize left or right 
	public float minZ = -5.0f, maxZ = 20.0f; //close or far to the camera
	
	private bool enableStones = true;
	private Rigidbody rb;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(ThrowStones());
	}
	
	// Update is called once per frame
	void Update () {
	}
	//coroutine
	IEnumerator ThrowStones()
	{
		// Initial delay wait for second the player needs some time
		yield return new WaitForSeconds(2.0f);
		
		while(enableStones) { //infinite loop


			GameObject stone = (GameObject) Instantiate(stones[Random.Range(0, stones.Length)]); //instantiate the stone prefabs from the array of prefabs
			stone.transform.position = new Vector3(Random.Range(minX, maxX), -30.0f, Random.Range(minZ, maxZ)); // create below the screen which will not be visiable
			stone.transform.rotation = Random.rotation; //random rotation

			rb = stone.GetComponent<Rigidbody>(); //get the rigidbody and add forces
			
			rb.AddTorque(Vector3.up * torque, ForceMode.Impulse); //up is vertical rotate along 3 axis angular velocities
			rb.AddTorque(Vector3.right * torque, ForceMode.Impulse);
			rb.AddTorque(Vector3.forward * torque, ForceMode.Impulse);
			
			rb.AddForce(Vector3.up * Random.Range(minAntiGravity, maxAntiGravity), ForceMode.Impulse); //throwing force of stone with min and max random antigravity force
			rb.AddForce(Vector3.right * Random.Range(minLateralForce, maxLateralForce), ForceMode.Impulse); //go to the right +ve or left -ve

			GameManager.currentNumberStonesThrown++;
			if (GameManager.currentNumberStonesThrown == 50)
				SceneManager.LoadScene("Final");
			yield return new WaitForSeconds(Random.Range(minTimeBetweenStones, maxTimeBetweenStones)); //random number of seconds waiting
			
		}
		
	}
}

