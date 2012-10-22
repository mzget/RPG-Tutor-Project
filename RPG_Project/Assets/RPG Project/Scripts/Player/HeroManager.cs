using UnityEngine;
using System.Collections;

public class HeroManager : MonoBehaviour {

    public GUISkin mainInterface;
    public GUISkin heroSkin;
    public Texture2D hero_icon;

    private float maxHP;
    private float hp;
    private float hpBarScale;

    private GameObject nameBar;
    private TextMesh textMeshName;
    private OTAnimatingSprite animatingSprite;
    private OTAnimation animation;
    private AIPlayer player;


    void Awake()
    {
        maxHP = 1000000;
        hp = maxHP;
    }

    // Use this for initialization
    void Start()
    {
        this.gameObject.name = name;

        nameBar = Instantiate(Resources.Load("PlayerName", typeof(GameObject))) as GameObject;
        textMeshName = nameBar.GetComponent<TextMesh>();
        player = this.gameObject.GetComponent<AIPlayer>();

        // To put our walking man on screen we create an animting sprite object
        animatingSprite = this.gameObject.GetComponent<OTAnimatingSprite>();
        animation = this.gameObject.GetComponent<OTAnimatingSprite>().animation;

        animatingSprite.animationFrameset = animation.framesets[0].name;
        animatingSprite.playOnStart = true;

        animation.GetFrameset("Skill_1").singleDuration = 2f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReceiveDamage(float damage)
    {
        hp -= damage;
    }

    #region Mouse Event.

    void OnMouseOver()
    {
        textMeshName.text = this.gameObject.name;

        textMeshName.transform.position = this.gameObject.transform.position + Vector3.up * 80;
    }

    void OnMouseDown()
    {

    }

    void OnMouseExit()
    {
        textMeshName.text = null;
    }

    #endregion

    void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / Main.setWidth, Screen.height / Main.setHeight, 1));

        GUI.BeginGroup(new Rect(0, 0, 300, 100));
        {
            GUI.Box(new Rect(0, 0, 60, 60), new GUIContent(hero_icon, "Icon"), GUIStyle.none);

            /// HP Management.
            hpBarScale = hp * 320f / maxHP;
            if (hp > 2 * (maxHP / 3))
            {
                GUI.Box(new Rect(60, 0, hpBarScale, 12), new GUIContent(hp.ToString() + "/" + maxHP.ToString(), "HP"), heroSkin.customStyles[0]);
            }
            else if (hp > maxHP / 3 && hp <= 2 * (maxHP / 3))
            {
                GUI.Box(new Rect(60, 0, hpBarScale, 12), new GUIContent(hp.ToString() + "/" + maxHP.ToString(), "HP"), heroSkin.customStyles[1]);
            }
            else
            {
                GUI.Box(new Rect(60, 0, hpBarScale, 12), new GUIContent(hp.ToString() + "/" + maxHP.ToString(), "HP"), heroSkin.customStyles[2]);
            }

            /// MP Management.
            GUI.Box(new Rect(60, 12.5f, 300, 12), new GUIContent("256 / 256", "MP"), heroSkin.customStyles[3]);

            //            GUI.BeginGroup(new Rect(85, 45, 125, 60), GUIContent.none, mainInterface.box);
            //            {
            //
            //            }
            //            GUI.EndGroup();

            //            GUI.BeginGroup(new Rect(215, 50, 185, 50), GUIContent.none, mainInterface.box);
            //            {
            //                GUI.Box(new Rect(5, 5, 40, 40), "Q");
            //                GUI.Box(new Rect(50, 5, 40, 40), "W");
            //                GUI.Box(new Rect(95, 5, 40, 40), "E");
            //                GUI.Box(new Rect(140, 5, 40, 40), "R");
            //            }
            //            GUI.EndGroup();
        }
        GUI.EndGroup();
    }
}
