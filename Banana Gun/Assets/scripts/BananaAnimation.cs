using UnityEngine;
using System.Collections;

public class BananaAnimation : MonoBehaviour {
	public Texture2D[] frames;
	public float FrameTime = 0.1f;
	
	void Start(){
		PlayAnimation();
	}
	
	public void PlayAnimation(){
		StartCoroutine(SpriteAnimation());
	}
	
	IEnumerator SpriteAnimation(){
		int nFrame=0;
		while(true){
			/* CAMBIAMOS LA TEXTURA DEL SHADER*/
			nFrame = nFrame==frames.Length-1 ? 0:nFrame+1;
			GetComponent<Renderer>().material.mainTexture = frames[nFrame];
			
			/* ESPERAMOS EL TIEMPO DEL FRAME */
			yield return new WaitForSeconds(FrameTime);
		}
	}
	
}