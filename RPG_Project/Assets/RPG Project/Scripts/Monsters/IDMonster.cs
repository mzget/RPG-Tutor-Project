using UnityEngine;
using System.Collections;

public class IDMonster : MonoBehaviour
{
    public string fixName;
	public bool _isLeft = true;
    public bool _isMalee = true;
    public OTSprite bullet;

    public float damage = 120F;
	public float atkSpeed = 1F;
    public float maxHP = 400F;
    public float hp = 400F;
    public float rangeVisible = 300F;
    public float rangeFormAbode = 300f; 

    private AIMonster aiMonster;
    private OTAnimatingSprite animatingSprite;


	// Use this for initialization
	void Start () {
		
        this.name = fixName;
        hp = maxHP;
		
        aiMonster = this.gameObject.GetComponent<AIMonster>() as AIMonster;
        aiMonster.RangeVisible = this.rangeVisible;
        aiMonster.RangeFromAbode = this.rangeFormAbode;
        aiMonster.CalculationDamage = this.damage;
        aiMonster.AtkSpeed = this.atkSpeed;

        // Instant bullet
        if (_isMalee == false)
            animatingSprite = this.gameObject.GetComponent<OTAnimatingSprite>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void CreateBullet(Vector2 target) {
        OTSprite nBullet = (Instantiate(bullet.gameObject) as GameObject).GetComponent<OTSprite>();
        nBullet.position = this.animatingSprite.position + (Vector2)this.animatingSprite.transform.up * (this.animatingSprite.size.y / 2);
        nBullet.RotateTowards(target);
        nBullet.GetComponent<ArrowBeh>().Damage = this.damage;
    }
}

