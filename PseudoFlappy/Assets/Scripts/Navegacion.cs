using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegacion : MonoBehaviour
{
	public GameObject menuPrincipal;
	public GameObject menuOpciones;
	
	
	private bool muestraMenu;
	public GameObject goMenu;
	
	public void ContinuaJuego() {
		SceneManager.LoadScene("Main");
	}
	
	public void Salir() {
		Application.Quit();
		Debug.Log("El jugador ha salido del juego");
	}
	
	public void MenuPrincipal(){
		Time.timeScale = 1;
		SceneManager.LoadScene("Titulo 1");
	}
	
	public void OpenOptionsPanel(){
		menuPrincipal.SetActive(false);
		menuOpciones.SetActive(true);
	}
	
	public void OpenMainMenuPanel(){
		menuPrincipal.SetActive(true);
		menuOpciones.SetActive(false);
	}
	
	public void StatusMenu(){
		if(muestraMenu){
			muestraMenu = false;
			goMenu.SetActive(false);
			Time.timeScale = 1;
		} else{
			muestraMenu = true;
			goMenu.SetActive(true);
			Time.timeScale = 0;
		}
	}
	
}
