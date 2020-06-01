using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding{
    
    //Pathfinding
    //Que es? Algoritmos de busqueda en grafos para utilizarlos para obtener una uta entre 2 nodos

    //Busqueda a lo ancho
    //Breadthwise search
    public static List<Nodo> Ancho(Nodo inicio, Nodo fin){

        Queue<Nodo> trabajo = new Queue<Nodo>();
        List<Nodo> visitados = new List<Nodo>();

        inicio.historial =new List<Nodo>();

        trabajo.Enqueue(inicio);
        visitados.Add(inicio);

        while(trabajo.Count > 0){

            Nodo actual = trabajo.Dequeue();

            if(actual == fin){
                //Si si fue se regresa el historial del nodo justo con el mismo
                List<Nodo> resultado = new List<Nodo>(actual.historial);
                resultado.Add(actual);
                return resultado;
            
            }else {

                // de no ser asi explorar los hijos/vecinos
                for(int i = 0; i<actual.vecinos.Length; i++){

                    Nodo vecionoActual = actual.vecinos[i];

                    //verificar si no fue visitado
                    if(!visitados.Contains(vecionoActual)){
                        //Si es "nuevo" entonces procesarlo #endregion

                        //Reiniciar historial del vecino
                        vecionoActual.historial = new List<Nodo>(actual.historial);
                        vecionoActual.historial.Add(actual);

                        //Agregar a las 2 estructuras
                        visitados.Add(vecionoActual);
                        trabajo.Enqueue(vecionoActual);
                    }
                }
            }
        }
        return null;
    }

    //Bsuqueda a lo profundo 
    //depthwise
    public List<Nodo> Profundo(Nodo inicio, Nodo fin){
        Stack<Nodo> trabajo = new Stack<Nodo>();
        List<Nodo> visitados = new List<Nodo>();

        inicio.historial =new List<Nodo>();

        trabajo.Push(inicio);
        visitados.Add(inicio);

        while(trabajo.Count > 0){

            Nodo actual = trabajo.Pop();

            if(actual == fin){
                //Si si fue se regresa el historial del nodo justo con el mismo
                List<Nodo> resultado = new List<Nodo>(actual.historial);
                resultado.Add(actual);
                return resultado;
            
            }else {

                // de no ser asi explorar los hijos/vecinos
                for(int i = 0; i<actual.vecinos.Length; i++){

                    Nodo vecionoActual = actual.vecinos[i];

                    //verificar si no fue visitado
                    if(!visitados.Contains(vecionoActual)){
                        //Si es "nuevo" entonces procesarlo #endregion

                        //Reiniciar historial del vecino
                        vecionoActual.historial = new List<Nodo>(actual.historial);
                        vecionoActual.historial.Add(actual);

                        //Agregar a las 2 estructuras
                        visitados.Add(vecionoActual);
                        trabajo.Push(vecionoActual);
                    }
                }
            }
        }
        return null;
    }

    //A estrella
    //A star
    //Es un algoritmo euritico
    public List<Nodo> AEstrella(Nodo inicio, Nodo fin){

        List<Nodo> trabajo = new List<Nodo>();
        List<Nodo> visitados = new List<Nodo>();

        inicio.historial = new List<Nodo>();
        inicio.g = 0;
        inicio.h = Vector3.Distance(inicio.transform.position, fin.transform.position);

        trabajo.Add(inicio);
        visitados.Add(inicio);

        //Caso especial
        if(inicio == fin){
            Debug.Log("Es el incio");
            List<Nodo> resultado = new List<Nodo>();
            resultado.Add(fin);
            return resultado;
        }

        //Para todo lo demás
        while (trabajo.Count > 0){
            //ponemos el mas chico default para poder comparar
            Nodo menor = trabajo[0];

            //Buscar el mas chico
            for(int i = 1; i<trabajo.Count; i++){

                if(trabajo[i].F < menor.F)
                    menor = trabajo[i];
            }

            //Remover de la lista de trabajo
            trabajo.Remove(menor);

            //Recorrer vecinos
            for(int i = 0; i < menor.vecinos.Length; i++){
                Nodo vecionoActual = menor.vecinos[i];

                if(!visitados.Contains(vecionoActual)){

                    //Verificar si vecino es objetivo
                    if(vecionoActual == fin){
                        List<Nodo> resultado = new List<Nodo>(vecionoActual.historial);
                        resultado.Add(vecionoActual);
                        return resultado;
                    }else{
                        //Modificar historial
                        vecionoActual.historial =  new List<Nodo>(menor.historial);
                        vecionoActual.historial.Add(menor);

                        //Calcular g, h
                        vecionoActual.g = menor.g + Vector3.Distance(menor.transform.position, vecionoActual.transform.position);
                        vecionoActual.h = Vector3.Distance(vecionoActual.transform.position, fin.transform.position);

                        //Agregar a estructuras
                        visitados.Add(vecionoActual);
                        trabajo.Add(vecionoActual);
                    }
                }
            }

        }


        return null;
    }


    
}
