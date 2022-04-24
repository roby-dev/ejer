using Ejercicios.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ejercicios.Controllers {
    public class PiramideController : Controller {
        // GET: Piramide
        [HttpGet]
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Piramide _piramide) {
            //Inicializamos las variables requeridas
            _piramide.resultado = new List<string>();
            string resultado = "";
            int numero = _piramide.numero, aux = 1, i, j;
            bool disminuir = false;

            //Validamos los datos que ingresa el usuario
            if (numero > 10 || numero == 0) return View(_piramide);

            for (i = 1; i <= numero; i++) {
                disminuir = false;
                for (j = 1; j <= i * 2 - 1; j++) {
                    //Verificamos el numero central de la fila de la piramide
                    int numeroMedio = i * 2 - 1;
                    //Verificamos si es el primer numero de la columna, en caso sea asi, se multiplica por el valor actual del numero de la fila
                    if (j == 1) {
                        aux = j * i;
                        if (aux == 10) {
                            aux = 0;
                        }
                    }
                    //Verificamos que no estemos en la primera fila para imprimir los resultads
                    if (j > 1) {
                        //Verificamos si estamos sumando, y si la columna actual sea diferente a la fila mas 1
                        if (j != i + 1 && !disminuir) {
                            //si llega al maximo que es 9, disminuimos de 1 en 1
                            if (aux == 9) {
                                aux = -1;
                            }
                            //si no llegamos al limite que es 9, sumamos
                            aux++;
                        } else {
                            //En caso que sea igual el numero actual de la columna con el numero de la fila, comenzamos a dismunior
                            disminuir = true;
                        }

                        if (disminuir) {
                            //si estamos disminuyendo, vamos restando el auxiliar
                            if (aux == 0) {
                                aux = 10;
                            }
                            aux--;
                        }
                    }
                    //concatenamos 
                    resultado += aux.ToString() + " ";
                }
                //guardamos el resultado en una lista
                _piramide.resultado.Add(resultado);
                //reiniciamos la fila
                resultado = "";
            }


            return View(_piramide);

        }

    }
}