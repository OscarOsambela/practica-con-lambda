using System;
using System.Collections.Generic;

//una expresion lambda es una funcion anonima que se puede usar para crear delegados o tipos de arbol de expresion
//Al usar expresiones lambda puedes escribir funciones locales que pueden pasarse como argumentos o devolverse como el valor de las llamadas
//a funciones
//las expresiones lambda son particularmente utiles para escribir expresiones de consulta a LINQ  

//1. se crea delegado
public delegate int Calculos(int i);
public delegate int Calculos2(int f, int g);
public delegate bool Comparacion(int y, Numero n);

class MainClass {
  public static void Main (string[] args) {
      HacerAlgo();
    }
  

  public static void HacerAlgo(){
    //ejm 1
    Calculos mate = new Calculos(Cuadrado);
    Console.WriteLine(mate(8));
    //ejm 2
    Calculos mate1 = new Calculos(PorDiez);
    Console.WriteLine(mate1(8));
    //ejm 3
    Calculos2 suma = new Calculos2(Sumar);
    Console.WriteLine(suma(2,5));
    //ejm 4
    Console.WriteLine("=========================");
    Console.WriteLine("Obtener números pares de la lista: 1,2,3,4,5,6,7,8");
    List<int> lista = new List<int>{1,2,3,4,5,6,7,8};
    List<int> numerosPares = lista.FindAll(delegate(int i){
      return (i % 2 == 0);
    });

    foreach(int par in numerosPares){
      Console.WriteLine(par);
    }
    //ejm 5 con uso metodo lambda
    Console.WriteLine("=========================");
    Console.WriteLine("Obtener números impares de la lista: 1,2,3,4,5,6,7,8");
    List<int> numerosImpares = lista.FindAll(i => i % 2 == 1);//metodo lambda.- i es parametro y valor de retorno
    numerosImpares.ForEach(i => Console.WriteLine(i));//{Console.WriteLine();Console.WriteLine();}.-agrega a la expresion lambda
    //ejm 6 con uso metodo lambda
    Console.WriteLine("=========================");
    mate = new Calculos(x => x * x * x);
    Console.WriteLine(mate(8));
    //ejm 7 con uso metodo lambda
    Console.WriteLine("=========================");
    Comparacion comp = (a, Numero) => a == Numero.n;
    Console.WriteLine(comp(5, new Numero{n = 5}));  
  }
  //metodos 
  public static int Sumar(int a, int b){
    return a + b;
  }
  public static int Cuadrado(int c){
    return c * c;
  }
  public static int PorDiez(int d){
    return d * 10;
  }
}

public class Numero{
  public int n{get;set;}
}

