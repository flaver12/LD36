using UnityEngine;
using System.Collections;

public class LoadLevelLD36: MonoBehaviour {

	public SimpleLevelDictionary[] LevelGeometryDictonary;

    public SimpleLevelDictionary[] LevelGeometryDictonaryDecoAndAI;

    public Texture2D LevelPathGeometry;
    public Texture2D LevelPathDeco;
    // public string LevelFolderPath;

	// Use this for initialization
	void Start () {
		LoadLevel levelLoadedCore = GetComponent<LoadLevel>();
        if (levelLoadedCore == null)
        {
            gameObject.AddComponent<LoadLevel>();
            levelLoadedCore = GetComponent<LoadLevel>();
        }

		SimpleLevel LevelGeo = new SimpleLevel(LevelPathGeometry);
		levelLoadedCore.LevelGeometryDictonary = LevelGeometryDictonary;
		levelLoadedCore.SimpleLevel = LevelGeo;
		SendMessage("loadLevelAndProess");

        SimpleLevel LevelDeco = new SimpleLevel(LevelPathDeco);
        levelLoadedCore.LevelGeometryDictonary = LevelGeometryDictonaryDecoAndAI;
        levelLoadedCore.SimpleLevel = LevelDeco;
        SendMessage("loadExtraLevelPart");


        // TODO: make this Dynamic and fitting to the current Loaded map
        Pathfinder pf = GameObject.Find("Pathfinder").GetComponent<Pathfinder>();
        pf.MapEndPosition = new Vector2(-200, -200);
        pf.MapStartPosition = new Vector2(200, 200);
    }
}
