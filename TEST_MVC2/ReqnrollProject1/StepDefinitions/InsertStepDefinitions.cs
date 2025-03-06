using System;
using System.Threading;
using Reqnroll;
using TEST_MVC2.Data;
using TEST_MVC2.Models;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class InsertFeatureStepDefinitions
    {
        private readonly ClienteDataAccessLayer _clienteDAL = new ClienteDataAccessLayer(); 
        
        [Given("Llenar los campos del formulario")]
        public void GivenLlenarLosCamposDelFormulario(DataTable dataTable)
        {
            var resultado = dataTable.Rows.Count();
            Assert.True(resultado > 0);
            
            // Pausa de 2 segundos
            Thread.Sleep(2000);
        }

        [When("Registro de usuario en la BDD")]
        public void WhenRegistroDeUsuarioEnLaBDD(DataTable dataTable)
        {
            var cliente = dataTable.CreateSet<Cliente>().ToList();
            Cliente cls = new Cliente();
            foreach (var item in cliente)
            {
                cls.Cedula = item.Cedula;
                cls.Nombres = item.Nombres;
                cls.Apellidos = item.Apellidos;
                cls.FechaNacimiento = item.FechaNacimiento;
                cls.Mail = item.Mail;
                cls.Telefono = item.Telefono;
                cls.Direccion = item.Direccion;
                cls.Estado = item.Estado;
            }
            _clienteDAL.InsertCliente(cls);

            // Pausa de 2 segundos
            Thread.Sleep(2000);
        }

        [Then("El resultado del registro en la BDD es correcto")]
        public void ThenElResultadoDelRegistroEnLaBDDEsCorrecto(DataTable dataTable)
        {
            var expectedCliente = dataTable.CreateInstance<Cliente>(); // Datos esperados
            var clienteEnBDD = _clienteDAL.GetClienteByCedula(expectedCliente.Cedula);

            // Verificar que se insertó correctamente
            Assert.NotNull(clienteEnBDD); // Asegurar que el registro existe
            Assert.Equal(expectedCliente.Cedula, clienteEnBDD.Cedula);
            Assert.Equal(expectedCliente.Nombres, clienteEnBDD.Nombres);
            Assert.Equal(expectedCliente.Apellidos, clienteEnBDD.Apellidos);
            Assert.Equal(expectedCliente.FechaNacimiento, clienteEnBDD.FechaNacimiento);
            Assert.Equal(expectedCliente.Mail, clienteEnBDD.Mail);
            Assert.Equal(expectedCliente.Telefono, clienteEnBDD.Telefono);
            Assert.Equal(expectedCliente.Direccion, clienteEnBDD.Direccion);
            Assert.Equal(expectedCliente.Estado, clienteEnBDD.Estado);
            
            // Pausa de 2 segundos
            Thread.Sleep(2000);
        }
    }
}
