# La Nacion Challenge
## Descripción
Este repositorio contiene una API desarrollada en ASP.NET Core 6.0 que proporciona servicios para gestionar contactos. La API sigue una arquitectura en capas para separar la lógica de presentación, lógica de negocios y acceso a datos, lo que facilita el mantenimiento y escalabilidad del sistema.

## Estructura del Proyecto
La solución está organizada en las siguientes capas:

- LaNacionChallenge.Presentation: Capa de presentación que contiene los controladores de la API y la configuración de inicio.
- LaNacionChallenge.Business: Capa de lógica de negocios que contiene los servicios de negocio e interfaces correspondientes.
- LaNacionChallenge.Data: Capa de acceso a datos utilizando Entity Framework Core. Incluye modelos de datos y repositorios.
- LaNacionChallenge.Tests: Proyecto de pruebas unitarias para los controladores y servicios.

## Cómo Levantar el Proyecto Localmente
Clona este repositorio: git clone https://github.com/luchoZuccolo96/LaNacionChallenge.git
Ejecuta la aplicación usando el comando: dotnet run --project LaNacionChallenge.Presentation
La API se ejecutará localmente en http://localhost:5000.

## Uso de Swagger
La API está documentada utilizando Swagger, lo que te permite explorar y probar los endpoints de manera interactiva.

Ingresar a: http://localhost:5000/swagger
## Endpoints de la API
A continuación los endpoints disponibles en la API:

GET /api/contact/all
Este endpoint devuelve todos los contactos disponibles.

GET /api/contact/{id}
Obtiene los detalles de un contacto por ID.

POST /api/contact/create
Crea un nuevo contacto.

PUT /api/contact/{id}
Actualiza los detalles de un contacto.

DELETE /api/contact/{id}
Elimina un contacto por ID.

GET /api/contact/find-by-email-or-phone?searchValue={valor}
Busca registros por correo electrónico o número de teléfono.

GET /api/contact/find-by-state-or-city?searchValue={valor}
Busca registros por estado o ciudad.
