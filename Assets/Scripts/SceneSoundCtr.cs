using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSoundCtr : MonoBehaviour {

	//Administracion de audios dentro del scene
	AudioSource aSource;	//Clase para la reproduccion de audios dentro del scene
	public AudioClip back_ground, on_play, end_game;	//Audios que seran reproduciones de fondo, mientras se ejecuta el juego y cuando acaba




	//Variable para ejecutar una vez la reproduccion del sonido de escena

	// Use this for initialization
	void Start () {
		aSource = GetComponent<AudioSource> ();
		aSource.clip = back_ground;
		aSource.Play ();


	}
	
	// Update is called once per frame
	void Update () {
		

	}

	public void OnplaySound(){
		//Reproduce otro sonido cuando el juego se inicia
		aSource.Stop ();
		aSource.clip = on_play;
		aSource.Play ();
	}


	public void MenuSound(){
		//Reproduce otro sonido cuando el juego se inicia
		aSource.Stop ();
		aSource.clip = back_ground;
		aSource.Play ();
	}


}
