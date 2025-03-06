Feature: Delete

  # Resumen de la feature
  # Esta feature se encarga de probar la eliminación de un cliente en la base de datos.

  @tag3
  Scenario: Delete Data
    Given Un cliente con cédula "1726791642" existe en la base de datos
    When Elimino el cliente con cédula "1726791642" de la base de datos
    Then El cliente con cédula "1726791642" ya no debe existir en la base de datos
