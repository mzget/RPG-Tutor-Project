using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StageManager : MonoBehaviour
{
    public Texture mapTex;

    enum MonsterNames {
        Bodyguard = 0,
        SkeletonArcher,
        SkeletonSolder,
        CommanderSkeleton,
    }

    private OTFilledSprite background;
    private List<GameObject> monstersList = new List<GameObject>();
	private List<Vector2> bodyguardPos = new List<Vector2>(5);
    private List<Vector2> skeletonArcherPos = new List<Vector2>(5);
    private List<Vector2> skeletonSolderPos = new List<Vector2>(5);
	private List<Vector2> commanderSkeletonPos = new List<Vector2>(5);


    void Awake() {
        monstersList.Add(GameObject.Find("Bodyguard"));
        monstersList.Add(GameObject.Find("SkeletonArcher"));
        monstersList.Add(GameObject.Find("SkeletonSolder"));
        monstersList.Add(GameObject.Find("CommanderSkeleton"));
    }

    // Application initialization
    void Start()
    {
        //foreach (GameObject monster in monstersList)
        //{
        //    monster.gameObject.active = false;
        //}

		#region Bodyguard Position List.
		
		bodyguardPos.Add(new Vector2(600, -168));
		bodyguardPos.Add(new Vector2(414, -458));
		bodyguardPos.Add(new Vector2(800, -355));
		
		#endregion
		
		#region Skeleton Archer Position List.

        skeletonArcherPos.Add(new Vector2(880, -100));
        skeletonArcherPos.Add(new Vector2(1060, -160));
        skeletonArcherPos.Add(new Vector2(1150, 190));

        #endregion

        #region Skeleton Solder Position List.

        skeletonSolderPos.Add(new Vector2(100, 400));
        skeletonSolderPos.Add(new Vector2(372, 380));
        skeletonSolderPos.Add(new Vector2(540, 80));

        #endregion

        #region Commander Skeleton Possition List.

        commanderSkeletonPos.Add(new Vector2(590, 268)); 
		commanderSkeletonPos.Add(new Vector2(900, 362)); 
		commanderSkeletonPos.Add(new Vector2(960, 130));
		
		#endregion
		
        OT.objectPooling = true;
        if(OT.objectPooling)
            CreateObjectPools();

        GenerateBackground();
    }

    // Update is called once per frame
    void Update() {

    }

    // Create objects for this application
    void CreateObjectPools()
    {
		OT.PreFabricate("PowerBar", 24);
		OT.PreFabricate("HPBar", 24);
        OT.PreFabricate("Bodyguard", 5);
        OT.PreFabricate(MonsterNames.SkeletonArcher.ToString(), 5);
        OT.PreFabricate(MonsterNames.SkeletonSolder.ToString(), 5);
        OT.PreFabricate(MonsterNames.CommanderSkeleton.ToString(), 5);
		
		/// Create Bodyguard.
		foreach(Vector2 pos in bodyguardPos) {
	        GameObject bodyguard = OT.CreateObject("Bodyguard");
	        OTAnimatingSprite bodyguardSprite = bodyguard.GetComponent<OTAnimatingSprite>();
	        // Set sprite's position
	        bodyguardSprite.position = pos;
		} 

        /// Skeleton Archer.
        foreach (Vector2 pos in skeletonArcherPos) {
            GameObject skeletonArcher = OT.CreateObject(MonsterNames.SkeletonArcher.ToString());
            OTAnimatingSprite skeletonArcherSprite = skeletonArcher.GetComponent<OTAnimatingSprite>();

            skeletonArcherSprite.position = pos;
        }

        /// Skekleton Solder.
        foreach (Vector2 pos in skeletonSolderPos) {
            GameObject skeletonSolder = OT.CreateObject(MonsterNames.SkeletonSolder.ToString());
            OTAnimatingSprite skeletonSolderSprite = skeletonSolder.GetComponent<OTAnimatingSprite>();

            skeletonSolderSprite.position = pos;
        }

		/// Commander Skekleton.
		foreach(Vector2 pos in commanderSkeletonPos) {
            GameObject commanderSkeleton = OT.CreateObject(MonsterNames.CommanderSkeleton.ToString());
        	OTAnimatingSprite commanderSkeletonSprite = commanderSkeleton.GetComponent<OTAnimatingSprite>();
			
			commanderSkeletonSprite.position = pos;
		}
    }

    void GenerateBackground()
    {
        // To create the background lets create a filled sprite object
        background = OT.CreateObject(OTObjectType.FilledSprite).GetComponent<OTFilledSprite>();
        // Set the image to our wyrmtale tile
        background.image = mapTex;
        // But this all the way back so all other objects will be located in front.
        background.depth = 10;
        // Set material reference to 'custom' green material - check OT material references
//        background.materialReference = "white";
        // Set the size to match the screen resolution.
        background.size = new Vector2(4096, 1024);
        // Set the fill image size to 50 x 50 pixels
        background.fillSize = new Vector2(128, 128);

        background.name = "Background";
    }
}
