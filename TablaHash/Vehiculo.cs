

using System;

namespace TablaHash
{
    public class Vehiculo
    {
        public string Codigo { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
      
    }
    public class TablaH
    {
        private int tamanoTabla;
        protected Vehiculo[] Tabla { get; set; }
        protected double FactorCarga { get; set; }
        protected int NumeroElementos { get;set;}


        public TablaH(int tamano)
        {
            tamanoTabla = tamano;
            Tabla = new Vehiculo[tamano];
            for (int i = 0; i < tamano; i++)
            {
                Tabla[i] = null;
            }
            NumeroElementos = 0;
            FactorCarga = 0.0d;
        }
        /// <summary>
        /// Devuelve la posicion donde se escuentre el vehiculo y si no existe te devuelve una posicion vacia
        /// </summary>
        /// <param name="clave"></param>
        /// <returns></returns>
        public int FuncionHash(string clave)
        {
            int i = 0;
            long p, d;
            d = TransformaCadena(clave);
            p = d % tamanoTabla;
            while (Tabla[p]!= null && !Tabla[p].Codigo.Equals(clave))
            {
                i++;
                p += i * i;
                p %= tamanoTabla;// Considera el array como circular
            }
            return (int)p;

        }
        public void Insertar(Vehiculo vehiculo)
        {
            int pos = FuncionHash(vehiculo.Codigo);
            Tabla[pos] = vehiculo;
            NumeroElementos++;
            FactorCarga = (double)NumeroElementos / tamanoTabla;
            if (FactorCarga>0.7d)
            {
                Console.WriteLine("El Factor de carga supera el 70%");
                Console.WriteLine("\n Aumente el tamaño");
            }
        }
        public Vehiculo BuscarVehiculoDelAno(string clave)
        {
            int pos = FuncionHash(clave);
            Vehiculo v = Tabla[pos];
            if (v != null)
            {
                if (v.Ano>=DateTime.UtcNow.Year)
                {
                    return v;
                }
            }
            return new Vehiculo();
        }
        public Vehiculo Buscar(string clave)
        {
            int pos = FuncionHash(clave);
            return Tabla[pos];

        }

        public void Eliminar(string clave)
        {
            int pos = FuncionHash(clave);
            if (Tabla[pos] != null)
            {
                Tabla[pos]=null;
            }
        }
        private long TransformaCadena(string clave)
        {
            long digitos = 0;
            for (int i = 0; i < clave.Length; i++)
            {
                digitos = digitos * 27 + (int)clave[i];
            }
            return digitos;
        }
        public void Imprimir()
        {
            for (int i = 0; i < tamanoTabla; i++)
            {
                
                if (Tabla[i] != null)
                    Console.WriteLine($"Codigo:{Tabla[i].Codigo}-- Vehiculo: {Tabla[i].Marca} {Tabla[i].Modelo} {Tabla[i].Ano}-- Serie:{Tabla[i].Serie}--Matricula:{Tabla[i].Placa}");
            }
        }
    }
}
