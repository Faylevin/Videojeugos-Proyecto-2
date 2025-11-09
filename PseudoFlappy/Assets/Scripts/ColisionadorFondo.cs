using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionadorFondo : MonoBehaviour{

	
	private GameObject[] fondos;
	private GameObject[] pisos;
	
	private float ultimaXFondo;
	private float ultimaXPiso;
	
	void Awake(){
		fondos = GameObject.FindGameObjectsWithTag("fondo");
		
		pisos = GameObject.FindGameObjectsWithTag("piso");
		
		ultimaXFondo = fondos[0].transform.position.x;
		ultimaXPiso = fondos[0].transform.position.x;
		
		for(int i = 0; i < fondos.Length; i++){
			if(ultimaXFondo < fondos[i].transform.position.x){
				ultimaXFondo = fondos[i].transform.position.x;
			}
		}
			
		for(int i = 0; i < pisos.Length; i++){
			if(ultimaXPiso < pisos[i].transform.position.x){
				ultimaXPiso = pisos[i].transform.position.x;
			}
		}
	}
	
	
	private void OnTriggerEnter2D(Collider2D objColisionando){
		
		if(objColisionando.tag == "fondo"){
			Vector3 temp = objColisionando.transform.position;
			float ancho = ((BoxCollider2D)objColisionando).size.x;
			temp.x = ultimaXFondo + ancho;
			
			objColisionando.transform.position = temp;
			ultimaXFondo = temp.x;
		}
		
		if(objColisionando.tag == "piso"){
			Vector3 temp = objColisionando.transform.position;
			float ancho = ((BoxCollider2D)objColisionando).size.x;
			temp.x = ultimaXPiso + ancho;
			
			objColisionando.transform.position = temp;
			ultimaXPiso = temp.x;
		}
		
	}
	
}