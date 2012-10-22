using UnityEngine;
using System.Collections;

public class GUI_ButtonBeh : MonoBehaviour {
	
	private Vector3 originalScale;
	
	void Awake() {
		this.gameObject.AddComponent(typeof(MeshCollider));
	}
	
	// Use this for initialization
	void Start () {
		originalScale = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseOver() {
		this.transform.localScale = originalScale + Vector3.one*0.3f;
	}
	
	void OnMouseExit() {
		this.transform.localScale = originalScale;
	}
}
