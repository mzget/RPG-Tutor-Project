using UnityEngine;
using System.Collections;

public class MonsterManager : MonoBehaviour {

	private bool _isAlive = true;
	public bool _IsAlive {
		get { return _isAlive; }
		set { _isAlive = value; }
	}
	
	private Vector2 hpBarSize;
    private GameObject powerBar_Ins;
    private GameObject hpBar_Ins;
    private GameObject monsterName;
    private TextMesh textMeshName;
    private OTSprite hpBarSprite;
    private OTSprite powerBarSprite;
    private AIMonster aiMonster;
	private IDMonster idMonster;
	
    private OTAnimatingSprite animationSprite;
	public OTAnimatingSprite AnimatingSprite{ get {return animationSprite;} set{animationSprite = value;}}
	

	// Use this for initialization
    void Start()
    {		
		GameObject hpbarsObj = GameObject.FindGameObjectWithTag("HpBarsObj");
	    GameObject	monsterNameObj = GameObject.FindGameObjectWithTag("MonsterNameObj");
		
		if(OT.objectPooling) {	
			monsterName = Instantiate(Resources.Load("MonsterName", typeof(GameObject))) as GameObject;
            powerBar_Ins = OT.CreateObject("PowerBar");
            hpBar_Ins = OT.CreateObject("HPBar");
			
			monsterName.transform.parent = monsterNameObj.transform;
			powerBar_Ins.transform.parent = hpbarsObj.transform;
			hpBar_Ins.transform.parent = hpbarsObj.transform;
		}
        this._isAlive = true;

        textMeshName = monsterName.GetComponent<TextMesh>();
        aiMonster = this.gameObject.GetComponent<AIMonster>();
        idMonster = this.gameObject.GetComponent<IDMonster>();
		
        animationSprite = this.gameObject.GetComponent<OTAnimatingSprite>();
        animationSprite.animationFrameset = "Idle";
        animationSprite.playOnStart = true;
		animationSprite.pivot = OTObject.Pivot.Center;

        powerBarSprite = powerBar_Ins.GetComponent<OTSprite>();
        hpBarSprite = hpBar_Ins.GetComponent<OTSprite>() as OTSprite;
        hpBarSprite.pivot = OTObject.Pivot.Left;
        hpBarSprite.renderer.material.color = Color.red;

        //hpBarSprite.visible = false;
        //powerBarSprite.visible = false;
        hpBar_Ins.active = false;
        powerBar_Ins.active = false;
	}

    // Update is called once per frame
    void Update()
    {
        /// Check Dying Event.
        if (idMonster.hp <= 0 && _isAlive)
        {
            _isAlive = false;
            this.collider.enabled = false;

            DestroyObject(hpBar_Ins.gameObject);
            DestroyObject(powerBar_Ins.gameObject);
            DestroyObject(monsterName.gameObject);

            if (aiMonster.AnimationStateProp != AIMonster.AnimationState.dead)
            {
                aiMonster.AnimationStateProp = AIMonster.AnimationState.dead;
                aiMonster.PlayAnimation();
            }
        }  
	}

    #region All Mouse Event.
	
	private void OnMouseEnter() {
		
	}

    private void OnMouseOver() {
        ShowMonsterName();
    }

    void OnMouseDown() {
        
    }

    void OnMouseExit() {
		CloseMonsterName();
    }

    #endregion

    /// <summary>
    /// HookUp By Simple Event.
    /// </summary>
    public void ShowMonsterName()
    {
        textMeshName.text = idMonster.fixName;

        textMeshName.transform.position = this.gameObject.transform.position + Vector3.up * ((this.animationSprite.size.y/2) + 40);
        /// Set PowerBar Position.
        hpBar_Ins.active = true;
        powerBar_Ins.active = true;
        powerBarSprite.transform.position = this.transform.position + new Vector3(0, (this.animationSprite.size.y/2) + 20, 0);
        hpBarSprite.transform.position = this.transform.position + new Vector3(-50, (this.animationSprite.size.y/2) + 20, 0);
    }

    public void CloseMonsterName()
    {
        try
        {
            textMeshName.text = string.Empty;
            hpBar_Ins.active = false;
            powerBar_Ins.active = false;
        }
        catch { }
	}
	
    public void ReceiveDamage(int r_Damage)
    {
    	idMonster.hp -= r_Damage;
        SetHealth();
    }

    private void SetHealth()
    {
        if (hpBarSprite)
        {
            float hpBarScale = idMonster.hp * 100f / idMonster.maxHP;
            hpBarSprite.size = new Vector2(hpBarScale, hpBarSprite.size.y);
        }
    }
}
