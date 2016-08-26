using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System; //This allows the IComparable Interface


public class RZMainScript : MonoBehaviour {


    #region Public Variables

    public GameObject[] structurePrefabsCityMatrix; //RZ    linked to building height
    
	public List<RZPiece> RZPieces;

	public int totalStructureNum = 0; //21
	public int gridNumX = 0; //19
	public int gridNumY = 0; //19
	public float gridSize = 0.0f; //32.6f

	public bool readPiecesFromFile = true;
	public string colortizerFilePath;
	public string colortizerTextResult = "";

    #endregion


    #region MonoBehaviour Massages
    
    // Use this for initialization
    void Start () {
        
		RZPieces = new List<RZPiece> ();

		// read pieces from colortizerFilePath & create RZPieces list
		if (readPiecesFromFile) {

			try {
				colortizerTextResult = System.IO.File.ReadAllText (colortizerFilePath);
			} catch (Exception ex) {
				print ("Error in load Colorizer data");
			}

			int delimeter = 10;
			// 9  ==> \t 
			// 10 ==> \n
			// 13 ==> \r
			char _delimeter = Convert.ToChar (delimeter);
			string[] rows = colortizerTextResult.Split (_delimeter);
			//print ("colorizer data rows [0]: " + rows [0]);

			int delimeterT = 9;
			char _delimeterT = Convert.ToChar (delimeterT);

			
			int pieceCount = 0;
			for (int i =0; i<rows.Length; i++) {
				float getValue = -1.0f;
				try {
					string[] rowValues = rows [i].Split (_delimeterT);
					getValue = float.Parse (rowValues [0]);
					if (rowValues.Length > 2) {
							
							RZPiece tmpPiece = new RZPiece ();
							tmpPiece.id = pieceCount;
							tmpPiece.fullString = rows [i];

							if (int.Parse(rowValues[0]) > -1) {
								//print ("NEW piece found!!!!!");
								//Debug.Log ("Piece ID:" + rows [i]);
								tmpPiece.id = int.Parse(rowValues [0]);
							}else{
								//print ("Empty(-1) piece found!!!!!");
								//Debug.Log ("Piece ID:" + rows [i]);
								tmpPiece.id = 16;
							}

							tmpPiece.xStep = int.Parse (rowValues [1]);
							tmpPiece.yStep = int.Parse (rowValues [2]);
							tmpPiece.rotation = int.Parse (rowValues [3]);
							/*
							Vector3 tmpVector3 = new Vector3 (tmpPiece.xStep * gridSize, 0f, tmpPiece.yStep * gridSize);
							int tmpStructureID = tmpPiece.structureID;

							//instantiate
							tmpPiece.modelPlain = (GameObject)Instantiate (structurePrefabsCityMatrix[tmpStructureID], tmpVector3, Quaternion.identity);
							tmpPiece.modelDiagrammatic = (GameObject)Instantiate (structurePrefabsCityMatrix[tmpStructureID], tmpVector3, Quaternion.identity);
							tmpPiece.modelClose = (GameObject)Instantiate (structurePrefabsCityMatrix[tmpStructureID], tmpVector3, Quaternion.identity);
							tmpPiece.emptyGameObjectForCollider = new GameObject ("emptyGameObjectForCollider");
							tmpPiece.emptyGameObjectForCollider.transform.position = tmpVector3;

							//rotate
							tmpPiece.modelPlain.transform.RotateAround (tmpVector3, Vector3.up, tmpPiece.rotation+180); //add 180 to correct
							tmpPiece.modelDiagrammatic.transform.RotateAround (tmpVector3, Vector3.up, tmpPiece.rotation+180); //add 180 to correct
							tmpPiece.modelClose.transform.RotateAround (tmpVector3, Vector3.up, tmpPiece.rotation+180); //add 180 to correct
							tmpPiece.emptyGameObjectForCollider.transform.RotateAround (tmpVector3, Vector3.up, tmpPiece.rotation+180); //add 180 to correct

							//structure
							tmpPiece.structure = YZStructures [tmpStructureID];
                            */
							RZPieces.Add (tmpPiece);
							pieceCount ++;
					}
				} catch (Exception ex) {
					print("Error in parsing Colorizer data");
				}
			}
		}

        // create RZPieces list - random
        /*
        if (!readPiecesFromFile) {

			int pieceCount = 0;
			for (int i=0; i<=gridNumX-1; i++) {

				for (int j=0; j<=gridNumX-1; j++) {

					RZPiece tmpPiece = new RZPiece ();
					tmpPiece.id = pieceCount;
					Vector3 tmpVector3 = new Vector3 (i * gridSize, 0f, j * gridSize);
					int tmpStructureID = UnityEngine.Random.Range (0, totalStructureNum - 1);

					tmpPiece.modelPlain = (GameObject)Instantiate (structurePrefabsCityMatrix[tmpStructureID], tmpVector3, Quaternion.identity);
                    
					tmpPiece.structure = YZStructures [tmpStructureID];

					RZPieces.Add (tmpPiece);
					pieceCount ++;

				}
			
			}

		}
        */

	}//end Start()
    
	// Update is called once per frame
	void Update () {
        
	}//end Update()

    #endregion


    #region Public Classes

	public class RZPiece {

        // Properties:
        public int id;
        public int idPrefab;
        public GameObject model;

		public string fullString;
		public int xStep;
		public int yStep;
		public int rotation;
		
		// Instance Constructor. 
		public RZPiece() {

			id = 0;
            idPrefab = 9;
            fullString = "";
			xStep = 0;
			yStep = 0;
			rotation = 0;
			
		}
		
	}//end of class RZPiece

    #endregion

    
}
