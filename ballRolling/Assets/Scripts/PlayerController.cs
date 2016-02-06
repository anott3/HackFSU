using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Networking;
using System;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public int speed = 15;
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		StartCoroutine(GetData ());
	}

	public void doMovements(string [] strings) {
		foreach (string str in strings) {
			Debug.Log (str);
			if (str.Equals ("Up")) {
				float moveVertical = Input.GetAxis ("Vertical");
				Vector3 movement = new Vector3 (0.0f, 0.0f, 1);
				rb.AddForce (speed * movement);
			}
			if (str.Equals ("Down")) {
				float moveVertical = Input.GetAxis ("Vertical");
				Vector3 movement = new Vector3 (0.0f, 0.0f, -1);
				rb.AddForce (speed * movement);
			}
			if (str.Equals ("Left")) {
				float moveVertical = Input.GetAxis ("Vertical");
				Vector3 movement = new Vector3 (-1, 0.0f, 0.0f);
				rb.AddForce (speed * movement);
			}
			if (str.Equals ("Right")) {
				float moveVertical = Input.GetAxis ("Vertical");
				Vector3 movement = new Vector3 (1, 0.0f, 0.0f);
				rb.AddForce (speed * movement);
			}
		}
	}
	IEnumerator GetData() {
		UnityWebRequest www = null;
		try {
		     www = UnityWebRequest.Get("https://tranquil-dawn-94616.herokuapp.com/obtainInstruction");
		}
		catch(Exception e) {
			Debug.Log (e.Message);
		}
		   yield return www.Send();

	   if(www.isError) {
		  Debug.Log(www.error);
		}
		else {
			byte[] results = www.downloadHandler.data;
			char[] array = new char[results.Length];
			for (int i = 0; i < results.Length; i++) {
				array[i] = Convert.ToChar(results[i]);
			}
			string [] names = new string[results.Length];
			for (int i = 0; i < results.Length; i++) {
				if (array[i] == 'U') {
					names[i] = "Up";
				}
				if (array[i] == 'D') {
					names[i] = "Down";
				}
				if (array[i] == 'L') {
					names[i] = "Left";
				}
				if (array[i] == 'R') {
					names[i] = "Right";
				}
			}
			if (names.Length != 0) {
			   doMovements(names);
			}
		}
	}

}
