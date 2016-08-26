using UnityEngine;
using System.Collections;

public class RZCloseLook : MonoBehaviour {
    /*
	public float closeLookDistance; //100f
	public bool pieceSelected = false;
	public int selectedPieceID;
	private RZMainScript RZMainScript;
	public GameObject testPosViz;

	// Use this for initialization
	void Start () {

		RZMainScript = GameObject.Find ("RZMainScript").GetComponent<RZMainScript> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (pieceSelected) {
			Vector3 camPos = transform.position;
			BoxCollider _bc = RZMainScript.YZPieces[selectedPieceID].emptyGameObjectForCollider.GetComponent<BoxCollider>();
			Vector3 closestPoint = _bc.ClosestPointOnBounds(camPos);
			float distance = Vector3.Distance(closestPoint, camPos);
			if (distance < closeLookDistance) {
				//Instantiate (testPosViz, closestPoint, Quaternion.identity);
				RZMainScript.YZPieces[selectedPieceID].modelPlain.SetActive (false);
				RZMainScript.YZPieces[selectedPieceID].modelDiagrammatic.SetActive (false);
				RZMainScript.YZPieces[selectedPieceID].modelClose.SetActive (true);
			} else {
				RZMainScript.YZPieces[selectedPieceID].modelPlain.SetActive (false);
				RZMainScript.YZPieces[selectedPieceID].modelDiagrammatic.SetActive (true);
				RZMainScript.YZPieces[selectedPieceID].modelClose.SetActive (false);
			}
		}

	}
    */
}
