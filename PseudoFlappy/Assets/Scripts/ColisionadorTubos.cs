using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionadorTubos : MonoBehaviour{
	
	private GameObject[] grupotubos;
	private float distancia = 3.0f;
	private float ultimaXTubo;
	private float yminTubo = -2.0f;
	private float ymaxTubo = 2.0f;
	
	void Awake(){
		grupotubos = GameObject.FindGameObjectsWithTag("tuboGrupo");
		for(int i=0; i < grupotubos.Length; i++){
			Vector3 temp = grupotubos[i].transform.position;
			temp.y = Random.Range(yminTubo,ymaxTubo);
			grupotubos[i].transform.position = temp;
		}
		
		ultimaXTubo = grupotubos[0].transform.position.x;
		
		for(int i = 1; i < grupotubos.Length; i++){
			if(ultimaXTubo < grupotubos[i].transform.position.x){
				ultimaXTubo = grupotubos[i].transform.position.x;
			}			
		}
	}
	
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D(Collider2D obj)
	{
		if(obj.tag == "tuboGrupo"){
			Vector3 temp = obj.transform.position;
			temp.x = ultimaXTubo + distancia;
			temp.y = Random.Range(yminTubo, ymaxTubo);
			obj.transform.position = temp;
			ultimaXTubo = temp.x;
		}
	}
}