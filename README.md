# examenTecnico

## Parte1Ejercicios: 
  Contiene:
    Los ejercicios en una proyecto de librerias .Net llamada Ejercicio.Solucion
    La pruebas unitarias de los ejercicios en el proyecto Ejercicio.Test
   
## Parte2AplicacionWeb:
  Contiene:
    La solución de la aplicación web desarrollado con Web Api 2 con el framework ASP.Net Core 2.1  
    
### La nomenclatura del proyecto es la siguiente: 
**"Negocio"."TipoProyecto"."SubTipo?"."Abrev. Funcionalidad"**

Por ejemplo:

**_OrdenPago.lib.bn_**:

            -> El negocio se definió "OrdenPago" por se la entidad que presenta mayor lógica de negocio.
            -> El tipo de proyecto es "lib" porque es un componente de tipo libreria
            -> El subtipo no lo tiene
            -> La funcionalidad "bn" corresponde a bussiness (lógica, validaciones y manejo de transacciones)
    
### La estructura del proyecto es la siguiente:
      Front End (MVC):
            -> OrdenPago.web.api                        --> Proyecto que contiene Interfaces web APi (Controladores)
            -> OrdenPago.web.ape\OpAtributoException.cs --> Clase que maneja las excepciones para enviarlas al cliente
            -> OrdenPago.web.api\wwwroot                --> Contiene las vistas, libreias javascript y estilos (Views)
            -> OrdenPago.lib.vm                         --> Proyecto de librerias que contiene las Entidades (Models); se separó en una                                                               librería ya que estos serán reutilizados en el Back End
      
      Back End (N Layer):
            -> OrdenPago.lib.bn           --> Proyecto que contiene la lógica, validaciones y manejo de transacciones de la aplicación.
            -> OrdenPago.lib.da           --> Realiza la escritura y consulta a la base de datos.
            -> OrdenPago.lib.vm           --> Entidades usadas en el back end
            -> OrdenPago.lib.util         --> Contiene la clase que agrega funcionalidad a las excepciones estándares para que se lean                                                   desde el cliente
            
      -> OrdenPago.Test                   --> Proyecto de pruebas unitarias para los servicios solicitados
      -> OrdenPago.db                     --> Script para la generacion de tablas y procedimientos que utiliza la aplicación
            
            
