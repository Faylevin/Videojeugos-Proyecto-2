using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour{
	
	
	public static float offsetX;


	// Start is called before the first frame update
	void Update()
	{
		if(Player.instancia != null){
			if(Player.instancia.estaVivo){
				MueveCamara();
			}
		}
	}
	
	private void MueveCamara(){
		Vector3 temp = transform.position;
		temp.x = Player.instancia.ObtenPosX() + offsetX;
		transform.position = temp;
	}
}