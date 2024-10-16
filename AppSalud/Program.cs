using System;
using System.Collections.Generic;


class Bascula
{
    private List<double> pesos { get; set; }
    private List<double> alturas { get; set; }
    private List<DateTime> fechas { get; set; }
    private int anotacion { get; set; }
    public Bascula()
    {
        pesos = new List<double>();
        alturas = new List<double>();
        fechas = new List<DateTime>();
        anotacion = 0;
    }

    public void anotarPeso(double peso, double altura, DateTime? fecha = null)
    {
        fecha = fecha ?? DateTime.Now;
        pesos.Add(peso);
        alturas.Add(altura);
        fechas.Add(fecha.Value);
        anotacion++;
    }
    public int obtenerNumeroAnotaciones()
    {
        return anotacion;
    }
    public double obtenerpesomaximo()
    {
        double pesomax = 0;
        foreach (double peso in pesos)
        {

            if (peso > pesomax)
            {
                pesomax = peso;
            }

        }
        return pesomax;

    }
    public double obtenerpesominimo()
    {
        double pesomin = 0;
        foreach (double peso in pesos)
        {

            if (peso < pesomin)
            {
                pesomin = peso;
            }

        }
        return pesomin;

    }


    public double calcularIMC()
    {
        double pesoult = 0;
        foreach (double peso in pesos)
        {
            pesoult = peso;
        }

        double AlturaUlt = 0;
        foreach (double altura in alturas)
        {
            AlturaUlt = altura;
        }
        double IMC = pesoult / (AlturaUlt * AlturaUlt);

        return IMC;
    }
    public void describirIMC(double IMC){
        if (IMC < 16)
        {
            Console.WriteLine("Infrapeso (delgadez severa).");
        } 
        else if (IMC >= 16 & IMC < 17)
        {
            Console.WriteLine("Infrapeso (delgadez moderada).");
        }
        else if (IMC >= 17 & IMC < 18.5)
        {
            Console.WriteLine("Infrapeso (delgadez aceptable).");
        }
        else if (IMC >= 18.5 & IMC < 25)
        {
            Console.WriteLine("Peso normal.");
        }
        else if (IMC >= 25 & IMC < 30)
        {
            Console.WriteLine("Sobrepeso.");
        }
        else if (IMC >= 30 & IMC < 35)
        {
            Console.WriteLine("Obeso (Tipo I).");
        }
        else if (IMC >= 35 & IMC < 40)
        {
            Console.WriteLine("Obeso (Tipo II).");
        }
        else if (IMC >= 40)
        {
            Console.WriteLine("Obeso (Tipo III).");

        }

    }
}


class Paciente
{
    private string nombre { get; set; }
    private string apellidos { get; set; }
    private DateTime fechaNacimiento { get; set; }
    private Bascula registroBascula { get; set; }
    public Paciente(String nombre, String apellidos, DateTime fechaNacimiento,Bascula registroBascula)
    {
       this.nombre =nombre;
       this.apellidos = apellidos;
       this.fechaNacimiento = fechaNacimiento;
       this.registroBascula = registroBascula;
    }
    public string obtenerNombre()
    {
        return nombre;
    }
    public String Saludar()
    {
        return("Hola soy" + this.nombre + " con el apellido" + this.apellidos);
    }
    public void modificarNombre(string nuevoNombre)
    {
        nombre = nuevoNombre;
    }
    public string obtenerApellido()
    {
        return apellidos;
    }
    public void modificarApellido(string nuevoApellido)
    {
        nombre = nuevoApellido;
    }
    public DateTime obtenerFechaNacimiento()
    {
        return fechaNacimiento;
    }
    public void modificarFechaNacimiento(DateTime nuevaFecha)
    {
        fechaNacimiento = nuevaFecha;
    }
    // Comprueba que el mes y el dia de la fecha de nacimiento es mayor 
    // que el mes y el dia de la fecha actual:
    public int obtenerEdad()
    {
        DateTime fechaActual = DateTime.Today;
        int edad = fechaActual.Year - fechaNacimiento.Year;

        if ((fechaNacimiento.Month > fechaActual.Month) ||
            (fechaNacimiento.Month == fechaActual.Month && fechaNacimiento.Day > fechaActual.Day))
        {
            --edad;
        }
        return edad;
    }
    public Bascula obtenerBascula()
    {
        return registroBascula;
    }
    public void modificarBascula(Bascula nuevaBascula)
    {
        registroBascula = nuevaBascula;
    }
    public double calcularIMC()
    {
        return registroBascula.calcularIMC();
    }

}
class Program
{
    static void Main(string[] args)
    {
        Bascula bascula = new Bascula();
        Paciente paciente = new Paciente("Carla", "Valles", new DateTime(2001, 10, 25), bascula);
        Console.WriteLine(paciente.Saludar());
    }
}




