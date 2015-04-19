using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerDead : MonoBehaviour {

	public GameObject gameoverMenu;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		if(collision.gameObject.tag == "Enemy")
		{
			gameoverMenu.SetActive(true);
			//GameObject.Destroy(this.gameObject);
			this.gameObject.SetActive(false);

		}
	}
}
