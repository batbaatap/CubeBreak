using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObsGenerator : MonoBehaviour {
	// public List<GameObject> tiles = new List<GameObject>();	
	public static ObsGenerator instance {get; private set;}

	public GameObject tile;

	public bool stepUp=false;
	public bool SpawnOb=true;
	public int  stepNum;

	public GameObject RoadsCont;

	GameObject groupObs;

	float rr;
	int RandRet ;
	int RandTileIndex ;

	float space;

	float spawnwoodtime = 0;

	public Text bestScore;
	//gemnumber deer ashiglaj bga
	public const string gemCountPrefs = "gemCountPrefs";
	//GameScore deer ashiglaj bga
	public Text GameScore;
	int countNum = 0;


	// Use this for initialization
	void Start () {
		instance = this;

		RoadsCont = GameObject.Find("RoadsGenerator");
		
		groupObs = new GameObject("GameObject");
		
        // float n = -3.5f;
        // while (n <= 3.5f)
        // {
        //     n+=0.2f;

        //     AvSpaces.Add(n);

        //     if (n >= 3.5f)
        //         break;
        // }

		bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
		GameScore.text = PlayerPrefs.GetInt("GameScorePrefs").ToString();
		
		StartCoroutine(GameScoreFunction());

		// PlayerPrefs.DeleteAll();
		
		// for (float w = 0; w < 40; w += 0.1f)
		// {
		// 	var til = Instantiate(tile, new Vector3(transform.position.x + w, transform.position.y, transform.position.z-3.5f), Quaternion.identity);
		
		// 		til.transform.parent = groupObs.transform;
			
			// s1Button.transform.SetParent(ChoiceButtonHolder.transform);
		// }
	}

	void Update() {
		// RandRet = Random.Range(0,6);
		// print(AvSpaces[RandRet]);	
		
		// RandTileIndex = Random.Range(0,tiles.Count);
		// print("RandTileIndex"+AvSpaces[RandRet]);

		if(GameManager.Instance.IsPlay())
		{
			int PlusBirthtime = Random.Range(2, 6);

			if(Time.time >= spawnwoodtime){
				SpawnObj();
				spawnwoodtime = Time.time + PlusBirthtime;
			}	

		 	//GameScore
			GameScore.text = PlayerPrefs.GetInt("GameScorePrefs").ToString();

			//Bestscore
			if(countNum > PlayerPrefs.GetInt("BestScore", 0))
            {
				PlayerPrefs.SetInt("BestScore", countNum);
				bestScore.text = countNum.ToString();
			}
		}
	}

	void SpawnObj()
	{
		for (float w = 0; w < 4f; w += 0.1f)
		{
			RoadsCont.GetComponent<RoadsGenerator>().cloneRoad = true;

			if (RoadsCont.GetComponent<RoadsGenerator>().cloneRoad == true)
			{
				var til = Instantiate(tile, new Vector3(transform.position.x + w, 
				transform.position.y, 
				transform.position.z), Quaternion.identity);
				
				til.transform.parent = groupObs.transform;
			}
		
				
			// s1Button.transform.SetParent(ChoiceButtonHolder.transform);
		}
	}


	//GameScore 
	IEnumerator GameScoreFunction()
	{
		for(int i = 0; i < 100*100; i++){
			yield return new WaitForSeconds(0.5f);

			if(GameManager.Instance.IsPlay()) {

				countNum = countNum + 1;

				PlayerPrefs.SetInt("GameScorePrefs", countNum);
			}

			yield return new WaitForSeconds(1);
		}
	}


}

