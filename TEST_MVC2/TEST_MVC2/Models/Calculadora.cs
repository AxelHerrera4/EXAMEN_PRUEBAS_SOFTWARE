namespace TEST_MVC2.Models
{
    public class Calculadora
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }  // Cambiado de SecondNumer a SecondNumber
        public int Add()
        {
            return FirstNumber + SecondNumber;  // Cambiado de SecondNumer a SecondNumber
        }
    }
}
