using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICtr : MonoBehaviour {

	//Declaracion de algunos objetos que deben ser pasados mediante el inspecto de unity
	public Button btn1, btn2;	//Botones restart y salir
	public GameObject score;	//GameObjecto de la tabla de puntuaciones
	public Text[] all_txt= new Text[4];  //Text donde se expondran las ultimas 4 mejores puntuaciones

	//Referencia a la clase SnakeController
	SnakeController snkCtr;
	//Referencia a la clase ScoreCtr
	ScoreCtr scoreCtr;
	//Referenecia a la clase SceneSoundCtr
	SceneSoundCtr soundCtr;
	//Referenecia a la clase SceneCtr
	SceneCtr sceneCtr;
	// Use this for initialization
	void Start () {
		Button btnRestart = btn1.GetComponent<Button> ();
		Button btnExit = btn2.GetComponent<Button> ();
		snkCtr = GameObject.Find ("/Player/Snake").GetComponent<SnakeController> ();
		scoreCtr =  GameObject.Find ("/Canvas/ScoreValue").GetComponent<ScoreCtr> ();
		soundCtr = GameObject.Find ("/Scene/Sound").GetComponent<SceneSoundCtr> ();
		sceneCtr = GameObject.Find ("/Scene/SceneController").GetComponent<SceneCtr> ();

		btnRestart.onClick.AddListener (RestartTask);
		btnExit.onClick.AddListener (ExitTask);

		Debug.Log(score.name);
		score.SetActive (false);


	}

	void RestartTask(){
		Debug.Log ("Restart button was clicked");
		score.SetActive (false);
		snkCtr.restartPos ();
		soundCtr.OnplaySound ();
		sceneCtr.playing = true;
	}

	void ExitTask(){
		Application.Quit ();
	}

	public void StateTable(bool estado){
		//Funcion que permite mostrar u ocultar la tabla de puntajes
		if (estado){
			int[] scores = scoreCtr.getScores ();
			for (int i = 0; i < all_txt.Length; i++) {
				all_txt [i].text = scores [i].ToString ();
			}

			score.SetActive (true);
		}
			
		else
			score.SetActive (false);
		
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
