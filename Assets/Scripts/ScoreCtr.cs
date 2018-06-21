using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCtr : MonoBehaviour {

	//
	Text txt;

	//Variables
	int total_score; //Variables que guarda el puntaje acumulado
	int[] recorded_sco = new int[]{0,0,0,0};  //Array que mantiene un registro de los mejores puntajes

	void Start () {
		txt = GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		txt.text = total_score.ToString ();

	}

	public void AddScore(){
		total_score += 1;

		//txt.text = total_score.ToString ();
	}

	public void SaveScore(){

		for (int i = 0; i < recorded_sco.Length; i++) {
			if (total_score >= recorded_sco [i]) {
				recorded_sco [i] = total_score;
				total_score = 0;
			}
		}
	}

	public int[] getScores(){

		return recorded_sco;
	}
}
