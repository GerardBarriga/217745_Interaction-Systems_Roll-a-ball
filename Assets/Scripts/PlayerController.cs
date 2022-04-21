using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	
	public TextMeshProUGUI countText;
	public GameObject winTextObject;
        private float movementX;
        private float movementY;

	private Rigidbody rb;
	private int count;

	// At the start of the game..
	void Start ()
	{

		rb = GetComponent<Rigidbody>();
		speed = 10;
		count = 0;
		SetCountText ();
               winTextObject.SetActive(false);
	}

	void FixedUpdate ()
	{

		Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("PickUp"))
		{
			
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText();
		}
	}

        void OnMove(InputValue movementValue)
        {
        	Vector2 movementVector = movementValue.Get<Vector2>();
        	movementX = movementVector.x;
        	movementY = movementVector.y;
        }

        void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 12) 
		{
                    winTextObject.SetActive(true);
		}
	}
}
