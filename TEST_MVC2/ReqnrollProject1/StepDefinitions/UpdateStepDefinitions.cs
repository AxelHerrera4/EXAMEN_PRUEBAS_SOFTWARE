using System;
using Reqnroll;
using TEST_MVC2.Data;
using TEST_MVC2.Models;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class UpdateStepDefinitions
    {
        private readonly ClienteDataAccessLayer _clienteDAL = new ClienteDataAccessLayer();

        [Given("Verificar si los datos existen")]
        public void GivenLlenarLosCamposDelFormularioConLosDatosOriginales(DataTable dataTable)
        {
            var clientes = dataTable.CreateSet<Cliente>().ToList();
            foreach (var item in clientes)
            {
                // Verifica que el cliente exista en la base de datos
                var clienteExistente = _clienteDAL.GetClienteByCedula(item.Cedula);

                Assert.NotNull(clienteExistente); // Lanza una excepción si el cliente no existe

                // Compara los datos para asegurarse que no haya inconsistencias
                Assert.Equal(item.Apellidos, clienteExistente.Apellidos);
                Assert.Equal(item.Nombres, clienteExistente.Nombres);
                Assert.Equal(item.FechaNacimiento, clienteExistente.FechaNacimiento);
                Assert.Equal(item.Mail, clienteExistente.Mail);
                Assert.Equal(item.Telefono, clienteExistente.Telefono);
                Assert.Equal(item.Direccion, clienteExistente.Direccion);
                Assert.Equal(item.Estado, clienteExistente.Estado);
            }
        }


        [When("Actualizo los datos del usuario en la BDD")]
        public void WhenActualizoLosDatosDelUsuarioEnLaBDD(DataTable dataTable)
        {
            var clientesActualizados = dataTable.CreateSet<Cliente>().ToList();
            foreach (var item in clientesActualizados)
            {
                var clienteExistente = _clienteDAL.GetClienteByCedula(item.Cedula);

                Assert.NotNull(clienteExistente); // Lanza una excepción si el cliente no existe

                // Actualiza siempre los datos sin comprobar cambios
                clienteExistente.Apellidos = item.Apellidos;
                clienteExistente.Nombres = item.Nombres;
                clienteExistente.FechaNacimiento = item.FechaNacimiento;
                clienteExistente.Mail = item.Mail;
                clienteExistente.Telefono = item.Telefono;
                clienteExistente.Direccion = item.Direccion;
                clienteExistente.Estado = item.Estado;

                _clienteDAL.UpdateCliente(clienteExistente); // Guarda los cambios en la base de datos
            }
        }


        [Then("El resultado de la actualización en la BDD es correcto")]
        public void ThenElResultadoDeLaActualizacionEnLaBDDEsCorrecto(DataTable dataTable)
        {
            var clienteEsperado = dataTable.CreateInstance<Cliente>();
            var clienteActualizado = _clienteDAL.GetClienteByCedula(clienteEsperado.Cedula);

            Assert.NotNull(clienteActualizado); // Verifica que el cliente existe
            Assert.Equal(clienteEsperado.Cedula, clienteActualizado.Cedula);
            Assert.Equal(clienteEsperado.Apellidos, clienteActualizado.Apellidos);
            Assert.Equal(clienteEsperado.Nombres, clienteActualizado.Nombres);
            Assert.Equal(clienteEsperado.FechaNacimiento, clienteActualizado.FechaNacimiento);
            Assert.Equal(clienteEsperado.Mail, clienteActualizado.Mail);
            Assert.Equal(clienteEsperado.Telefono, clienteActualizado.Telefono);
            Assert.Equal(clienteEsperado.Direccion, clienteActualizado.Direccion);
            Assert.Equal(clienteEsperado.Estado, clienteActualizado.Estado);
        }

    }
}
