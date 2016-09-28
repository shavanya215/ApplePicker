﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Basket : MonoBehaviour {
    public Text scoreGT;

	// Use this for initialization
	void Start () {
        //Find a reference to the ScoreCounter GameObject 
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Get the Text Component of that Game Object
        scoreGT = scoreGO.GetComponent<Text>();
        //Set the Starting number of the points to 0
        scoreGT.text = "0";

	
	}
	
	// Update is called once per frame
	void Update () {
        // Get the current screen position of the mouse from Input 
        Vector3 mousePos2D = Input.mousePosition;
        //The Camera's z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;
        //Convet the point from 2D screen space into 3D game world space 
        Vector3 mousepos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        //Move the postition of this Basket to the x postion of the Mouse 
        Vector3 pos = this.transform.position;
        pos.x = mousepos3D.x;
        this.transform.position = pos;

    }

    void OnCollisionEnter (Collision coll)  {
        //Find out what hit this Basket 
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple" ) {
            Destroy(collidedWith);
            // convert the score back to a string and display it 
            scoreGT.text = scoreGT.ToString();
        }

        //parse the text of the scoreGT into an int
        int score = int.Parse(scoreGT.text);
        //Add points for catching the apple
        score += 100;
        //Convert the score back to a string and display it 
        scoreGT.text = score.ToString();


    }
}
