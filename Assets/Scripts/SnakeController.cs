using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script contiene la declaracion del objeto controlador de la serpiente en el juego
//por tanto definira unos atributos y metodos particulares.
public class SnakeController : MonoBehaviour {

	//Atributos de la serpiente en el juego
	//*Velocidad de movimiento x y y
	float x_speed = 6.0f;
	float y_speed = 6.0f;
	bool end = false;

	Vector3 velocidad;
	//Referencia al componente transform del objeto
	Transform snake_trans;

	//Referencia a la clase ScoreCtr
	ScoreCtr scoreCtr;

	//Referenecia a la clase SceneSoundCtr
	SceneSoundCtr soundCtr;

	//Referencia a la clase UICtr
	UICtr userInterCtr;
	void Start () {
		
		snake_trans = GetComponent<Transform> ();
		snake_trans.position = new Vector3 (0.0f, 0.0f, 0.0f);
		scoreCtr = GameObject.Find ("/Canvas/ScoreValue").GetComponent<ScoreCtr> ();
		userInterCtr = GameObject.Find ("/Canvas/UIController").GetComponent<UICtr> ();
		soundCtr = GameObject.Find ("/Scene/Sound").GetComponent<SceneSoundCtr> ();

	}

	
	// Update is called once per frame
	void Update () {
		//Este metodo es preferiblemente usado para acciones diferentes al movimiento del jugador
		keyPressed();
		//print (Position ().position);
	}

	void FixedUpdate(){
		//Este metodo si es usado para la actualizacion del jugador en cuanto a su movimiento
		if (!end){
			snake_trans.position += velocidad * Time.fixedDeltaTime;
		}


	}



	public void keyPressed(){
		if (Input.GetKey ("left")) {
			velocidad = new Vector3(-this.x_speed,0.0f,0.0f);
		} else if (Input.GetKey ("right")) {
			velocidad = new Vector3(this.x_speed,0.0f,0.0f);
		} else if (Input.GetKey ("up")) {
			velocidad = new Vector3(0.0f,this.y_speed,0.0f);
		} else if (Input.GetKey ("down")) {
			velocidad = new Vector3(0.0f,-this.y_speed,0.0f);
		}
		
	}

//	void OnTriggerEnter(Collider other){
//		Debug.Log("Enter is called..");
//	}
			

	private void OnTriggerEnter2D(Collider2D other){
		Debug.Log("FIN DEL JUEGO");
		scoreCtr.SaveScore ();
		userInterCtr.StateTable (true);
		soundCtr.MenuSound ();
		restartPos ();
		end = true;
	}

	public void restartPos(){

		snake_trans.position = new Vector3 (0.0f, 0.0f, 0.0f);
		velocidad = new Vector3(0.0f,0.0f,0.0f);
		end = false;

	}


}
