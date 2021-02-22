using EscuelaEtapa1.App;
using EscuelaEtapa1.Entidades;
using EscuelaEtapa1.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console; //Permite solo escribir el "WriteLine"

namespace EscuelaEtapa1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA!");
            Printer.Beep();
            Printer.Beep(10000, cantidad: 10);
            //Se utiliza los métodos creados en la clase Printer
            //Printer.DibujarLinea(20);
            //Printer.DibujarLinea();

            //ImprimirCursosEscuela(engine.Escuela);

            //POLIMORFISMO
            //El polimorfismo se refiere a la sobrescritura de los métodos de la clase padre por sus clases hijas esto para que cada clase hija tenga un comportamiento diferente para ese método.
            //El polimorfismo permite que un método de la clase PADRE se herede pero tambi[en que cambie su comportamiento en la clase hija(si así lo desea).

            /*Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.WriteTitle("Pruebas de Polimorfismo");
            //Alumno es de tipo "Alumno" que hereda de "ObjetoEscuelaBase"
            var alumnoTest = new Alumno { Nombre = "Claire Murillo" };
            //Objetos compatibles por el polimorfismo
            ObjetoEscuelaBase ob = alumnoTest;

            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");

            Printer.WriteTitle("ObjetoEscuela");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.UniqueId}");
            WriteLine($"Alumno: {ob.GetType()}");

            var evaluacion = new Evaluacion() { Nombre = "Evaluacion de matematicas", Nota = 4.5f };
            Printer.WriteTitle("Evaluacion");
            WriteLine($"Evaluacion: {evaluacion.Nombre}");
            WriteLine($"Evaluacion: {evaluacion.UniqueId}");
            WriteLine($"Evaluacion: {evaluacion.Nota}");
            WriteLine($"Evaluacion: {evaluacion.GetType()}");

            ob = evaluacion;
            Printer.WriteTitle("ObjetoEscuela");
            WriteLine($"Evaluacion: {ob.Nombre}");
            WriteLine($"Evaluacion: {ob.UniqueId}");
            WriteLine($"Evaluacion: {ob.GetType()}");

            //EVITAR ERRORES EN TIEMPO DE EJECUCIÓN - VALIDACIÓN CON "IS" y "AS"
            //"IS" PARA PREGUNTAR SI UN OBJETO ES DE UN TIPO DETERMINADO
            //
            if(ob is Alumno)
            {
                var alumnoRecuperado = (Alumno)ob;
            }
            //Si obj lo puede tomar como Alumno, devuelve el obj transformado en Alumno. Pero si obj no lo puede transformar en alumno entonces devuelve null.
            //"AS" tome este objeto como si fuera este objeto
            //Mas recomendada
            Alumno alumnoRecuperado2 = ob as Alumno;*/

            //------------------------------------------------------------------------------------------------------------------------

            //Solicitar el metodo GetObjetosEscuela
            //1era implementación
            //var listaObjetos = engine.GetObjetosEscuela(false, false, false, false);
            //2nda implementacion: haciendo un conteo de objetos con contadores. En este caso, listaObjetos es una TUPLA
            //var listaObjetos = engine.GetObjetosEscuela(true, false, false, false);
            //3era implementacion: 
            /*int dummy = 0; // Reemplazar en caso de no querer obtener ese conteo.
            var listaObjetos = engine.GetObjetosEscuela(
                out int conteoEvaluaciones,
                out int conteoCursos,
                out int conteoAsignaturas,
                out int conteoAlumnos);*/
            //Las 3 implementaciones responden AL PROBLEMA DE OBTENER UNA LISTA DE OBJETOS Y PODERLOS CLASIFICAR.
            //Implementación de los métodos con SOBRECARGA
            var listaObjetos = engine.GetObjetosEscuela();


            //Llamar al Limpiar definido en el Interface Ilugar
            engine.Escuela.LimpiarLugar();

            //Desde el punto de vista de la programación orientada a objetos cualquier objeto puede ser visto como una interfaz.
            //Haciendo uso de Linq vamos a seleccionar de nuestra lista de objetos todos los objetos y les haremos casting con ILugar.Si no declaramos que nos retorne sólo los objetos que sean de tipo ILugar, entonces el programa al realizar el casting va a causar errores silenciosos.
            /*var listaIlugar = from obj in listaObjetos
                              where obj is Alumno
                              select (Alumno)obj;*/

            //CREACION DE DICCIONARIO DE DATOS
            /*Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10, "JuanK"); //Llave, Valor
            diccionario.Add(12, "LoremIpsus");
            diccionario[0] = "Nato";

            foreach (var keyValPair in diccionario)
            {
                WriteLine($"Key: {keyValPair.Key}, Valor: {keyValPair.Value}");
            }
            //Otra forma de recorrer un diccionario
            Printer.WriteTitle("Acceso a diccionario");
            WriteLine(diccionario[12]);
            WriteLine(diccionario[0]);
            Printer.WriteTitle("Otro diccionario");
            var dic = new Dictionary<string, string>();
            dic["Luna"] = "Cuerpo Celeste que gira alrededor de la Tierra";
            WriteLine(dic["Luna"]);
            dic["Luna"] = "Protagonista de Soy Luna";
            WriteLine(dic["Luna"]);
            //En el caso de adicionar un campo con la misma llave y otro valor, falla ya que la llave debe ser única.*/

            var dictmp = engine.GetDiccionarioObjetos();
            engine.ImprimirDiccionario(dictmp);

            //MANEJADOR DE EVENTO
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            //Acumulación de DELEGADOS o MULTICAST DELEGATE
            AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(2000, 1000, 1);

            //  REPORTEADOR
            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evalList = reporteador.GetListaEvaluaciones();
            var listaAsig = reporteador.GetListaAsignaturas();
            var listaEvalXAsig = reporteador.GetDicEvaluaXAsig();
            var listaPromedioxAsig = reporteador.GetPromAlumnPorAsignatura();

            Console.ReadKey();
        }

        //Método Generado para el EVENTO
        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIENDO");
            Printer.Beep(3000, 1000, 3);
            Printer.WriteTitle("SALIÓ");
        }


        /*private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de la Escuela");

            if (escuela != null && escuela.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                   Console.WriteLine($"Nombre {curso.Nombre}, Id{curso.UniqueId}");
                }
            }
        }*/


    }
}