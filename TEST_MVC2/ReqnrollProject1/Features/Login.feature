Feature: Login

Login hacia el sistema de automation excercue login

@tag1
Scenario: Usuario ingresa credenciales incorrectas
	Given que el usuario esta en la pagina del login
	When ingresa el correo "testuser@mail.com" y la contraseña "passw123"
	And  hacer click en el boton de inicio de sesion
	Then deberia ver un mensaje de error
