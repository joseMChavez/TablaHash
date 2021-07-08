using System;


namespace TablaHash
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehiculo vehiculo1 = new Vehiculo { Codigo = "marTier", Marca = "Honda", Modelo = "Civid", Placa = "RD907843", Serie = "43443-43434-jkd32-2342",Ano=2003 };
            Vehiculo vehiculo2 = new Vehiculo { Codigo = "212343", Marca = "Honda", Modelo = "Civid", Placa = "RD7843", Serie = "43443-43434-jkd32-2342", Ano = 2022 };
            Vehiculo vehiculo3 = new Vehiculo { Codigo = "gr3434", Marca = "Honda", Modelo = "Civid", Placa = "RD9843", Serie = "43443-43434-jkd32-2342", Ano = 2003 };
            TablaH tabla = new TablaH(5);
            tabla.Insertar(vehiculo1);
            tabla.Insertar(vehiculo2);
            tabla.Insertar(vehiculo3);
            tabla.Eliminar("212343");
            tabla.Imprimir();
            Console.WriteLine(tabla.BuscarVehiculoDelAno("gr3434").Serie);

        }
    }
}
