﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using Entidad;
using System.Data;

namespace Negocio
{
    public class fSucurzal
    {
        public static DataTable Lista(int auto)
        {
            Conexion_Sucurzal Datos = new Conexion_Sucurzal();
            return Datos.Lista(auto);
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Sucurzal Datos = new Conexion_Sucurzal();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                //Datos Basicos
                string sucurzal, string nit, string descripcion, 
                string gerente, string pais, string ciudad, string direccion
            )
        {
            Conexion_Sucurzal Datos = new Conexion_Sucurzal();
            Entidad_Sucurzal Obj = new Entidad_Sucurzal();

            Obj.Sucurzal = sucurzal;
            Obj.Descripcion = descripcion;
            Obj.Nit = nit;
            Obj.Gerente = gerente;
            Obj.Pais = pais;
            Obj.Ciudad = ciudad;
            Obj.Direccion = direccion;

            Obj.Auto = auto;
            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idsucurzal,

                //Datos Basicos
                string sucurzal, string nit, string descripcion,
                string gerente, string pais, string ciudad, string direccion
            )
        {
            Conexion_Sucurzal Datos = new Conexion_Sucurzal();
            Entidad_Sucurzal Obj = new Entidad_Sucurzal();

            Obj.Idsucurzal = idsucurzal;
            Obj.Sucurzal = sucurzal;
            Obj.Descripcion = descripcion;
            Obj.Nit = nit;
            Obj.Gerente = gerente;
            Obj.Pais = pais;
            Obj.Ciudad = ciudad;
            Obj.Direccion = direccion;

            Obj.Auto = auto;
            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Sucurzal Datos = new Conexion_Sucurzal();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}
