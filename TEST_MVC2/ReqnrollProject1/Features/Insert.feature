Feature: Insert


Proceso de realizar Unit testing ADD en Insert 

@tag1
Scenario: Insert Data
	Given Llenar los campos del formulario
		| Cedula     | Apellidos | Nombres | FechaNacimiento | Mail            | Telefono   | Direccion | Estado |
		| 1726791642 | Muñoz     | Jose    | 01/01/2025      | mjose@gmail.com | 0988334398 | Guayas    | 1      | 
	When Registro de usuario en la BDD
		| Cedula     | Apellidos | Nombres | FechaNacimiento | Mail            | Telefono   | Direccion | Estado |
		| 1726791642 | Muñoz     | Jose    | 01/01/2025      | mjose@gmail.com | 0988334398 | Guayas    | 1      | 
	Then El resultado del registro en la BDD es correcto
		| Cedula     | Apellidos | Nombres | FechaNacimiento | Mail            | Telefono   | Direccion | Estado |
		| 1726791642 | Muñoz     | Jose    | 01/01/2025      | mjose@gmail.com | 0988334398 | Guayas    | 1      | 
