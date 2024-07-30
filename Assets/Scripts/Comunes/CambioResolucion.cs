using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Dropdown;

public class CambioResolucion : MonoBehaviour{
    
    public Dropdown dropdownResoluciones;

    //Cargo las posibles resoluciones que puede tomar nuestro programa
    void Start(){
        //Cargo las resoluciones
        Resolution [] resoluciones = Screen.resolutions;

        //Guardamos aqui las opciones
        List<OptionData> opciones = new List<OptionData>();

        //Variables auxiliares
        int width = 0;
        int height = 0;
        int seleccionadoActual = 0;
        int i = 0;

        //Las que no son 16:9 no me gustan se van
        foreach(Resolution resolucion in resoluciones){

            //Los que tengan 16:9 me los guardo
            float ratio = (float)resolucion.width / (float)resolucion.height;

            //Aquí he hecho un corte a los digitos del flotante para que el error no haga falsa esta expresion siempre
            if(Math.Round(ratio,3) == Math.Round((float)16/(float)9,3) && width != resolucion.width && resolucion.height != height){
                opciones.Add(new OptionData(resolucion.width.ToString() + " x " + resolucion.height.ToString()));
                if(resolucion.width == Screen.width && resolucion.height == Screen.height){
                    seleccionadoActual = i;
                }else{
                    i++;
                }
            }

            //Si no son repetidos
            width = resolucion.width;
            height = resolucion.height;
        }

        //Se cargan las resoluciones nuevas
        dropdownResoluciones.AddOptions(opciones);
        dropdownResoluciones.value = seleccionadoActual;
        dropdownResoluciones.RefreshShownValue();

    }

    //Cambia a la resolucion seleccionada
    public void CambiarResolucion(){

        //Obtiene la resolucion que esta marcada en el dropdown
        string resolucion = dropdownResoluciones.options[dropdownResoluciones.value].text;

        //Variables auxiliares por aqui
        int width = 0;
        int height = 0;
        bool principio = true;
        int numero = 0;

        //Aqui saco la resolucion de la string
        for(int i = 0; i < resolucion.Length; i++){
            
            //Si se encuentra al principio...
            if(!principio){
                
                //Las matematicas son divertidas gente
                if(int.TryParse(resolucion[i].ToString(), out numero)){
                    height = height * 10 + numero;
                }
                
            }else{

                //La primera parte es el ancho por lo que utilizamos el buen try parse para saber cuando se termina
                if(int.TryParse(resolucion[i].ToString(), out numero)){
                    width = width * 10 + numero;
                }else{
                    numero = 0;
                    principio = false;
                }

            }
        }

        Screen.SetResolution(width, height, Screen.fullScreen);
    }
}
