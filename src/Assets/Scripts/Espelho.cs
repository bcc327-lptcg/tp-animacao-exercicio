using UnityEngine;
using System.Collections;
public class Espelho : MonoBehaviour {
 private bool renderizar;
 public Renderer display;
 void OnPostRender(){
 if(renderizar == true){
 Texture2D TexturaAtual = new Texture2D(Screen.width,Screen.height);
 TexturaAtual.ReadPixels (new Rect(0,0,Screen.width,Screen.height),0,0);
 TexturaAtual.Apply();
 display.material.mainTexture = TexturaAtual;
 renderizar = false;
 }
 }
 void Update (){
 renderizar = true;
 }
}