Microservicios

Este es un peque�o ejemplo de microservicios en .NET con base de datos SQLSERVER,

Estos microservicios se comunican entre ellos via Rest Api y por el protocolo AMQP con ayuda de RabbitMQ
Configuraci�n


Instalaci�n

$ docker-compose up -d build

Este proceso tardara un poco, por que bajara las imagenes que talvez no las tenga e instalar� las dependencias de cada microservicio.

Una vez terminado el proceso, ingrese en su navegador a http://localhost:80/swagger vera una lista de Apis con los que se comunica con el cliente.
Nota

