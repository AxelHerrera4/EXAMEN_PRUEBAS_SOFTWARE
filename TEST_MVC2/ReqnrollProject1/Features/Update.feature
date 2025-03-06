Feature: Update

Proceso de realizar Unit testing en Update 

@tag2
Scenario: Update Data
    Given Verificar si los datos existen
        | Cedula     | Apellidos | Nombres | FechaNacimiento | Mail            | Telefono   | Direccion | Estado |
        | 1726791642 | Muñoz     | Jose    | 01/01/2025      | mjose@gmail.com | 0988334398 | Guayas    | 1      | 
    When Actualizo los datos del usuario en la BDD
        | Cedula     | Apellidos  | Nombres   | FechaNacimiento | Mail               | Telefono   | Direccion  | Estado |
        | 1726791642 | Muñoz Lema | José Luis | 01/02/2025      | jose.l@outlook.com | 0999887766 | Quito      | 2      | 
    Then El resultado de la actualización en la BDD es correcto
        | Cedula     | Apellidos  | Nombres   | FechaNacimiento | Mail               | Telefono   | Direccion  | Estado |
        | 1726791642 | Muñoz Lema | José Luis | 01/02/2025      | jose.l@outlook.com | 0999887766 | Quito      | 2      | 
