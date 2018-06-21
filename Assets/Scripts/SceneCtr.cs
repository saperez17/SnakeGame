using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SceneCtr : MonoBehaviour {
	//SnakeController snake;		//Referencia al controlador de la serpiente 
	public GameObject food;
	public Transform player;
	ScoreCtr scoreCtr;
	SceneSoundCtr soundCtr;	
	Vector3 origen;


	//Variables
	private List<GameObject> activeFood; 	//lista de objetos para llevar seguimiento de la comida generada
	public bool playing = true; //Vraible para ejecutar el sonido durante el tiempo de juego solo una vez,
								//es reiniciada a true cuando se presiona el boton de restart

	public void Start () {
		//snake = GameObject.Find ("/Player/Snake").GetComponent<SnakeController> ();		//Encontrar la ubicacion del objeto que contiene el componente
		activeFood = new List<GameObject>();		//Inicializar la lista de objetos

		//Lo siguiente genera genera una copia del prefab(GameObject) food declarado al inicio, y lo muestra en una posicion aleatoria
		//en la pantalla
		Vector3 RandomSpawn = new Vector3 (Random.Range (-6, 6), Random.Range (-4, 4), 0.0f); //Vector aleatorio x,y,z; Random.range() genera un numero aleatorio entre los dos numeros pasados como parametros
		GameObject fo1;
		fo1=Instantiate(food) as GameObject;
		//Instantiate (fo1, RandomSpawn, Quaternion.identity);
		fo1.transform.SetParent(transform);		//Asigna al componente transform los mismos valores del transform del elemento que lo contiene
		fo1.transform.position = RandomSpawn;	//Los valores del vector3 position perteniciente al transform del objeto se establecen igual al vector aleatorio generado anteriormente
		activeFood.Add (fo1);					//Agrega el objeto generado a la lista de objetos

		origen = new Vector3 (0.0f, 0.0f, 0.0f);

		scoreCtr = GameObject.Find ("/Canvas/ScoreValue").GetComponent<ScoreCtr> ();
		soundCtr = GameObject.Find ("/Scene/Sound").GetComponent<SceneSoundCtr> ();
	}
	
	// Update is called once per frame
	void Update () {

		//print (player.position);


	}

	void FixedUpdate(){
		
		if (FoodEaten (player, activeFood [0].transform)) {
			EliminarComida ();		//Elimina de la pantalla el objeto en la posicion 0 de la lista de objetos y lo remueve de esta.
			GenerarComida ();		//Genera el prefab food en una posicion aleatoria
			scoreCtr.AddScore();
		}

		if (playing && (!Vector3.Equals (player.position, origen))) {
			soundCtr.OnplaySound ();
			playing = false;
		}



	}


	public void GenerarComida(){
		//Funcion que genera una copia del objeto food y lo muestra en una posicion aleatoria
		Vector3 RandomSpawn = new Vector3 (Random.Range (-6, 6), Random.Range (-4, 4), 0.0f);
		GameObject fo1;
		fo1=Instantiate(food) as GameObject;
		fo1.transform.SetParent(transform);
		fo1.transform.position = RandomSpawn;
		activeFood.Add (fo1);
	}

	public void EliminarComida(){
		Destroy(activeFood[0]);
		activeFood.RemoveAt(0);
	}

	public bool FoodEaten(Transform tr1, Transform tr2){
		//Funcion que calcula la distancia entre el jugador (snake) y la comida, si estan lo suficientemente cerca retorna true, contrario false
		Vector3 temporal = tr1.position - tr2.position;
		float d = Vector3.SqrMagnitude (temporal);
		if (Mathf.Abs(d) <= 0.5f)
			return true;
		else
			return false;
	}






}
