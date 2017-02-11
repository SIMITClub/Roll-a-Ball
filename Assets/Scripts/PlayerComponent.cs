using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerComponent : MonoBehaviour {

	private float speed;
	public Text countText;
	public Text WinText;

	private Rigidbody rb;
	private int count;

	public Mesh objectToCreate;

	void Start()
	{
		count = 0;
		speed = 10f;
		setCountText ();
		WinText.text = "";
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//For desktop
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce(movement * speed);

		//For Mobile Devices
		//Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y);
		//rb.velocity = movement * speed;


	}

	void Update()
	{
		increaseSpeed ();
//		var gameObject = new GameObject("Pick Up");
//		gameObject.tag = "Pick Up";
//		gameObject.SetActive (true);
//		var meshFilter = gameObject.AddComponent<MeshFilter>();
//		gameObject.AddComponent<MeshRenderer>();
//		meshFilter.sharedMesh = objectToCreate;
//		Vector3 movement = new Vector3 (transform.position.x-2f, 0.5f, transform.position.z-5f);
//		gameObject.transform.position = movement;
//
//		gameObject.transform.rotation = transform.rotation;
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count++;

			setCountText ();
			if (count >= 11)
				WinText.text = "You Win";
		}
	}

	void increaseSpeed()
	{
		speed += 0.1f;
	}

	void setCountText()
	{
		countText.text = "Count: " + count.ToString();
	}
}
