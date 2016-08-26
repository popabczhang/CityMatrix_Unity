﻿/// URBAN LENS Software 2014-2015
/// 
/// Created By CARSON SMUTS 2014 - MIT MediaLab
/// 
/// Displays specific information regarding buildings in center of cameras line of sight. 
/// Total values are also calculated and displayed through this code.
/// 
/// 
/// WARNING!!!!
/// DO NOT EDIT THIS FILE. It is a dependancy for other scripts and if this code breaks, so will everything else relying on it.
/// If you need to eidt this file contact the creator or person in charge of the central file.
/// 
/// 

using UnityEngine;
using System.Collections;
using System.Reflection;

public class RZCamFocus : MonoBehaviour {

	/*

	public GameObject cameraMain;
	public GameObject focusObject;
	public GameObject textObject;

	public GameObject textName;
	public GameObject textID;
	public GameObject textFloors;
	public GameObject textHeight;

	public GameObject textPrograms;
	public GameObject textOccupants;


	//Totals
	public GameObject textTotalResid;
	public GameObject textTotalRetail;
	public GameObject textTotalOffice;
	public GameObject textTotalRestaurant;
	public GameObject textTotalCafe;
	public GameObject textTotalSchool;
	public GameObject textTotalHospital;
	public GameObject textTotalPublicSpace;
	
	public GameObject textTotalParking;


	RaycastHit oldHit ;

	GameObject oldObject;

	int gamePieces = 0;

	public bool focusOn = true;
	// Use this for initialization

	CSStructures.CS_Structure foundStructure;
	CSStructures.CS_Piece foundPiece;
	public bool newFocus = false;
	string oldPiece = "";

	void Start () {

		foundPiece = new CSStructures.CS_Piece ();
		foundStructure = new CSStructures.CS_Structure();

		gamePieces = (int)GameObject.Find("CSGrid").GetComponent<CSGrid>().structures.numberOfStructures;
	
	}


	public CSStructures.CS_Structure getFocusStructure(){

		return foundStructure;
	}

	public CSStructures.CS_Piece getFocusPiece(){
		
		return foundPiece;
	}


	public void toggleFocus() {
		//print("We've got " + "some" + " cameras");

		if (focusOn) {
			focusOn = false;
			//cameraMain.GetComponent("DepthOfFieldScatter");
		
			//GameObject.Find("Your object name").GetComponent().enabled = false;
			Component dofs = cameraMain.GetComponent ("CSJavaToggle");
			dofs.SendMessage("Disable");
			//FieldInfo fi = dofs.GetType().GetField("focalLength");
			//	fi.SetValue(dofs, 99.0f);
			//dofs.SendMessage

		} else {
			focusOn = true;
			Component dofs = cameraMain.GetComponent ("CSJavaToggle");
			dofs.SendMessage("Enable");
		}
	}

	// Update is called once per frame
	bool oldFound = false;
	void Update () {

		////////////////////////////////////////////////////////////
		///////////////Calc and Update all Total Values/////////////
		////////////////////////////////////////////////////////////

		CSStructures gridStructures = (CSStructures)GameObject.Find("CSGrid").GetComponent<CSStructures>();


		if (gridStructures.newInfoAvailable) {

			//print ("Updating Total Values");

			float totalRes 		= 0;
			float totalRetail 	= 0;
			float totalOffice 	= 0;
			float totalRestaurant 	= 0;
			float totalCafe 	= 0;
			float totalSchool 	= 0;
			float totalHospital 	= 0;
			float totalPublicSpace 	= 0;



			float totalParking 	= 0;

			for (int i = 0; i < gridStructures.loadedPieces.Count; i++) {

				if(gridStructures.loadedPieces[i].strID> -1 && gridStructures.loadedPieces[i].strID< gamePieces){

				CSStructures.CS_Structure tempStructure = gridStructures.structures [gridStructures.loadedPieces[i].strID];

				for (int k = 0; k < tempStructure.levels.Count ; k++) {

				CSStructures.CS_StructureLevel structureLevel = tempStructure.levels [k];

				for (int j = 0; j < structureLevel.ProgramsType.Count; j++) {

				string progName = structureLevel.ProgramsType 	[j];


						if(progName.Equals("Residental")){
						totalRes += float.Parse (structureLevel.ProgramsVal [j]);
					//print (progName);
					//print (totalRes);
				}

				if(progName.Equals("Retail")){
							totalRetail += float.Parse (structureLevel.ProgramsVal [j]);
				}
				if(progName.Equals("Office")){
							totalOffice += float.Parse (structureLevel.ProgramsVal [j]);
				}
						if(progName.Equals("Restaurant")){
							totalRestaurant += float.Parse (structureLevel.ProgramsVal [j]);
						}
						if(progName.Equals("Café")){
							totalCafe += float.Parse (structureLevel.ProgramsVal [j]);
						}
						if(progName.Equals("School")){
							totalSchool += float.Parse (structureLevel.ProgramsVal [j]);
						}
						if(progName.Equals("Hospital")){
							totalHospital += float.Parse (structureLevel.ProgramsVal [j]);
						}
						if(progName.Equals("PublicSpace")){
							totalPublicSpace += float.Parse (structureLevel.ProgramsVal [j]);
						}
				}//end for J
					totalParking += structureLevel.parking;
				}//end for K

				//string occName = structureLevel.OccupantType 	[0];
				//string occValue = structureLevel.OccupantVal 	[0];

				}//end for if ID is -1
			}// end for I

			textTotalResid.GetComponent<UnityEngine.UI.Text>().text 		= "Residential: " + totalRes;
			textTotalRetail.GetComponent<UnityEngine.UI.Text>().text 		= "Retail: " + totalRetail;
			textTotalOffice.GetComponent<UnityEngine.UI.Text>().text 		= "Office: " + totalOffice;
			textTotalRestaurant.GetComponent<UnityEngine.UI.Text>().text 	= "Restaurant: " + totalRestaurant;
			textTotalCafe.GetComponent<UnityEngine.UI.Text>().text 			= "Café: " + totalCafe;
			textTotalSchool.GetComponent<UnityEngine.UI.Text>().text 		= "School: " + totalSchool;
			textTotalHospital.GetComponent<UnityEngine.UI.Text>().text 		= "Hospital: " + totalHospital;
			textTotalPublicSpace.GetComponent<UnityEngine.UI.Text>().text 	= "PublicSpace: " + totalPublicSpace;

			textTotalParking.GetComponent<UnityEngine.UI.Text>().text 		= "Parking: " + totalParking;


			gridStructures.newInfoAvailable = false;
		}
		////////////////////////////////////////////////////////////
		////////////////END CALCULATE TOTAL VALUES//////////////////
		////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////

		if (oldFound) {
			oldHit.collider.gameObject.GetComponent<Renderer> ().material.shader = Shader.Find ("Diffuse");
		}

		Transform cam= cameraMain.transform;
		Ray ray = new Ray(cam.position, cam.forward);
		RaycastHit hit ;

		if (Physics.Raycast (ray, out hit, 10000)) {

		//	print ("hit something: " + hit.collider.gameObject.name);
			//focusObject.gameObject.transform.position =  hit.point;


			Bounds bounds2 = new Bounds(hit.collider.transform.position,Vector3.zero);
			
			if(hit.collider.transform.childCount >1){
				foreach (Transform child in hit.collider.transform)
				{
					//bounds.encapsulate(child.gameObject.renderer.bounds);
					bounds2.Encapsulate(child.gameObject.GetComponent<Renderer>().bounds);
				}
			}else{
				bounds2 = hit.collider.gameObject.GetComponent<Renderer>().bounds;
			}

			focusObject.gameObject.transform.position = new Vector3(hit.point.x ,bounds2.max.y , hit.point.z);


			if(hit.collider.tag == "clickable"){

				//int index = int.Parse(hit.collider.gameObject.name);
				foundStructure = gridStructures.structures[int.Parse (hit.collider.gameObject.name)];
				foundPiece.theStructure = hit.collider.gameObject;
				foundPiece.structure = gridStructures.structures[int.Parse (hit.collider.gameObject.name)];
				//foundPiece.focused01 = true; //YZ

				if(hit.collider.gameObject != oldObject){
					oldObject = hit.collider.gameObject;
					newFocus = true;
				}else{
					newFocus = false;
				}

				textObject.GetComponent<UnityEngine.UI.Text>().text = "Module: " + foundStructure.id + " - Type:" + foundStructure.name;


				textName.GetComponent<UnityEngine.UI.Text>().text 	= "Name: " + hit.collider.gameObject.name + " : " + foundStructure.name;
				textID.GetComponent<UnityEngine.UI.Text>().text 	= "ID: " + foundStructure.id;
				textFloors.GetComponent<UnityEngine.UI.Text>().text = "Floors: " +foundStructure.levelCount;
				textHeight.GetComponent<UnityEngine.UI.Text>().text = "Height: " + foundStructure.height;
				
				//Get level 0 information

				if (foundStructure.levels.Count>0){
				CSStructures.CS_StructureLevel moduleLevel = foundStructure.levels[0];
				string programsName = moduleLevel.ProgramsType[0];
				string programsValue = moduleLevel.ProgramsVal[0];
				string occupantName = moduleLevel.OccupantType[0];
				string occupantValue = moduleLevel.OccupantVal[0];
				}

			}else{

			textName.GetComponent<UnityEngine.UI.Text>().text = "Name: ";
			textID.GetComponent<UnityEngine.UI.Text>().text = "ID: ";
			textFloors.GetComponent<UnityEngine.UI.Text>().text = "Floors: ";
			textHeight.GetComponent<UnityEngine.UI.Text>().text = "Height: ";
			}

		}
	
	}

	*/
}
