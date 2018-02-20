using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	private Quaternion myRotation;
	public float timeToRotate = 3.0f;
	private Coroutine rotationCoroutine;
	public UnityEvent afterRotate;

	public void ExitGame(){
		Debug.Log ("Exit");
		Application.Quit ();
	}

	void Start(){
		myRotation = gameObject.transform.rotation;
	}

	public void StartRotation(){
		rotationCoroutine = StartCoroutine ("Rotate");
	}

	public void StopRotation(){
		StopCoroutine (rotationCoroutine);
		gameObject.transform.rotation = myRotation;
	}

	IEnumerator Rotate(){
		float startTime = Time.time;
		float overTime = startTime + timeToRotate;
		while (Time.time < overTime) {
			gameObject.transform.Rotate (new Vector3(0,0, Mathf.Lerp (1, 15, 1.0f-(overTime-Time.time)/timeToRotate)));
			yield return null;
		}
		if (afterRotate != null) {
			afterRotate.Invoke ();
		}
	}

}
