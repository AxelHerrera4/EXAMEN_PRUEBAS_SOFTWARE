using System;
using Reqnroll;
using TEST_MVC2.Data;
using TEST_MVC2.Models;
using Xunit;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class DeleteStepDefinitions
    {
        private readonly ClienteDataAccessLayer _clienteDAL = new ClienteDataAccessLayer();

        [Given("Un cliente con cédula {string} existe en la base de datos")]
        public void GivenUnClienteConCedulaExisteEnLaBaseDeDatos(string cedula)
        {
            var cliente = _clienteDAL.GetClienteByCedula(cedula);
            Assert.NotNull(cliente); // Si no existe, lanzamos una excepción
        }

        [When("Elimino el cliente con cédula {string} de la base de datos")]
        public void WhenEliminoElClienteConCedulaDeLaBaseDeDatos(string cedula)
        {
            _clienteDAL.DeleteClienteByCedula(cedula);
        }

        [Then("El cliente con cédula {string} ya no debe existir en la base de datos")]
        public void ThenElClienteConCedulaYaNoDebeExistirEnLaBaseDeDatos(string cedula)
        {
            var cliente = _clienteDAL.GetClienteByCedula(cedula);
            Assert.Null(cliente); 
        }
    }
}
