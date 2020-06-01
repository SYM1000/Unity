using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path{
    
    //Metodo de ruta busqueda a lo profundo

    public static List<Nodo> Profundo(Nodo inicio, Nodo fin){

        // 2 estructuras utilizadas por el algoritmo
        List<Nodo> visitados = new List<Nodo>();
        Stack<Nodo> trabajo = new Stack<Nodo>();

        // reiniciar historial de nodo raiz
        inicio.historial = new List<Nodo>();
        trabajo.Push(inicio);
        visitados.Add(inicio);

        while (trabajo.Count > 0)
        {

            Nodo actual = trabajo.Pop();

            if (actual == fin)
            {

                // generar lista resultado y regresarla
                List<Nodo> resultado = new List<Nodo>(actual.historial);
                resultado.Add(actual);
                return resultado;
            }
            else
            {

                // si no es el objetivo - agregar vecinos
                for (int i = 0; i < actual.vecinos.Length; i++)
                {

                    Nodo vecinoActual = actual.vecinos[i];

                    if (!visitados.Contains(vecinoActual))
                    {

                        // reiniciar ruta
                        vecinoActual.historial = new List<Nodo>(actual.historial);
                        vecinoActual.historial.Add(actual);

                        // agregar a estructuras
                        trabajo.Push(vecinoActual);
                        visitados.Add(vecinoActual);
                    }
                }
            }
        }

        // no existe una ruta posible
        return null;
    }


}
