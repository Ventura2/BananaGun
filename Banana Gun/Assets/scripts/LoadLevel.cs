using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public int levelToLoad;

	public float timeToWait = 35;

	private float time;
	// Use this for initialization
	void Start () {
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(time>timeToWait)
			if(Input.GetKeyDown (KeyCode.Space))
				Application.LoadLevel (levelToLoad);

		if(time<=timeToWait)
			time += Time.deltaTime;

	}
}
