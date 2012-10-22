using UnityEngine;
using System.Collections;

public class HPbarScript : MonoBehaviour {

    public int frameIndex;
    private OTSprite sprite;
    //private OTSpriteAtlasCocos2D container;

    void Awake() {
        sprite = this.gameObject.GetComponent<OTSprite>();
    }

	// Use this for initialization
	void Start () {

        sprite.spriteContainer = OT.ContainerByName("Bar_Data") as OTSpriteAtlasCocos2D;
        sprite.frameIndex = this.frameIndex;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
