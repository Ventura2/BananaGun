using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitButton : MonoBehaviour {
	
	private Button button;
	// Use this for initialization
	void Start () {
		button = GetComponent<Button>();
		button.onClick.AddListener(clicked);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void clicked(){
		Application.Quit();
	}
}
