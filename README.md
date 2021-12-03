# proyectoDAM
## SEWESER
### Creación del repositorio

# 04/10/2021
### He estado buscando información acerca de ASP.NET ya que era algo completamente nuevo.
#### He anotado lo más interesante, que sería lo siguiente:
##### Lo primero es que es un entorno completamente enfocado a aplicaciones web.
##### Tiene 3 modelos de programación distintos, de los cuales ASP.NET Web Pages es un modelo más simple y rápido de aprender pero completamente funcional.
##### En Visual Studio puedo meter bastantes dependencias de servicio de forma fácil.
##### En Visual Studio asp.net cuenta con varias plantillas para facilitar la creación de las aplicaciones.
##### Tiene diversas extensiones, por ejemplo, ASP.NET Web API (API HTTP para servicios rest) me será útil.
##### 2 tipos de ejecución: Aplicación cliente/servidor o que usen el navegador, en mi caso será algo más cliente/servidor.
### He visto también algunos tutoriales en youtube que me servirán de guía. (No sé si debería indicarlos aquí también).



# miércoles 10/11/2021 hasta el domingo 15/11/2021
#### Esto es un resumen a lo relativo a estos días pasados que no he anotado.
#### He visualizado gran cantidad de videos referentes no solo a ASP.NET si no a otras tecnologías como Microsoft SQL Server Management. 
#### Esto se ha debido a que he tenido que crear una base de datos para almacenar registros para poder realizar pruebas. 
#### De los vídeos que he visto el más útil y el que me ha servido para instalar todo y crear la base de datos en cuestión es este https://www.youtube.com/watch?v=SqZQffksa0w.
#### Más vídeos que he visto, por ejemplo este donde explicaban muy bien el concepto de API y su funcionalidad (Lo vi en fechas anteriores pero lo anoté debido a que explicaba muy bien): https://www.youtube.com/watch?v=u2Ms34GE14U.
#### Este video, más técnico, también explica que es un Api Rest con un ejemplo práctico https://www.youtube.com/watch?v=TKE2Rr9alf0.
### De este canal he visto bastantes videos la verdad, son los que más me están ayudando: https://www.youtube.com/c/jestradabe/featured. 
#### Habré visto casi todos los relacionados con ASP.NET porque también estuve viendo si debía usar MVC o lo estaba haciendo bien como estaba.
### Para hacer pruebas con la API tuve que instalar la aplicación Postman y ver como funcionaba aunque era bastante intuitiva.



# 16/11/2021
### Hoy estuve completando el funcionamiento de la API y probando todos los métodos así como haciendo pruebas unitarias para verificar que no haya fallos.
### También he incorporado el paquete Nuget de Swagger para poder poner comentarios en la vista web de la API.
### He cambiado el branch default a probando que es donde estoy actualizando todo



# 17/11/2021
### Esto juraría que lo había dejado escrito ayer.
### Estuve documentando toda la Api así como implementando Swagger para poder realizar peticiones HTTP desde la propia ejecución de la API.
### Esto resulta muy práctico ya que no se necesita la utilización de terceros programas.

# 18/11/2021 
### Hoy he encontrado un fallo con la id de la reserva que me llevo un buen rato solucionar, tuve que añadir un nuevo campo a la tabla de la base de datos.
### Esto es debido a que cuando realizo un post en la base de datos al ser autoincremento no podía seleccionar yo mismo el id de reserva.
### Esto lo solucioné al crear un campo idReservaOnline que a la hora de realizar el post coja el valor de idReserva y se actualice.


# 01/12/2021
### Llevaba un par de días viendo videos para aclararme con la programación asíncrona y entender bien como funciona ya que tenía ciertos problemillas con los métodos rest de la Api, también para entender mejor aún como funciona exactamente todo. 
### El problema del día 18 se fue arrastrando varios días más relacionado con todo el tema de la programación asincrona hasta que logré entender bien como funciona y saber arreglarlo completamente y probar que no fallase.
### Ya lo tengo todo bastante claro y lo que es la API ya estaría terminada. 
### Estuve también mirando videos y haciendo un usuario en SQL server para la conexión con la base de datos para que sea lo más simple posible a la hora de probar la aplicación (ya que yo estuve probando en local).


# 02/12/2021
### Hice algunos cambios en los métodos de algunas cosas que no me gustaban (optimización).
### Publiqué la API en el servidor IIS de windows 
### Me faltaría hacer el consumo de la API


# 03/12/2021
### Cambié un par de cosas en la base de datos después de crear un par de usuarios para poder conectar desde la página web en local publicada por el IIS de windows.
### En cuanto al IIS republiqué la API después realizar algunos cambios y estuve probando hasta conseguir conectarme. 
### Al estar publicada la API en iis puedo acceder a ella desde cualquier dispositivo que comparta mi red poniendo en un explorador mi ip... "ip"+/ReservaApi.
### Haciendo todo esto consigo alojar la API en el servidor de windows y puedo realizar todos los métodos HTTP de la API, actualizando también en la base de datos en caso de hacer POST, PUT y DELETE.
### Tuve que dar varios permisos al usuario de SQL server que se conectaba desde el iis así como crear una regla en el firewall de windows.
### Estuve también intentando adaptar este procedimiento pero en vez de que funcionara en una red local que se pudiera conectar desde un ordenador ajeno a mi red, pero aparte de no encontrar forma de hacerlo actualmente, esto no me convence a la hora de implementarlo por temas de seguridad.
