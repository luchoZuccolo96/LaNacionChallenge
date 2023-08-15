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
Ejecuta la aplicación usando el comando: 
```
dotnet run --project ChallengeLaNacion
```
La API se ejecutará localmente en http://localhost:5000.

## Configuración de la Base de Datos
La aplicación utiliza MySQL como motor de base de datos. Para configurar la conexión a la base de datos y realizar cambios locales, sigue estos pasos:

Abre el archivo appsettings.json en la raíz del proyecto.

Ubica la sección ConnectionStrings y ajusta los valores según tu configuración local:

```json
"ConnectionStrings": {
  "MyDbConnection": "Server=localhost;Port=3306;Database=NombreDeTuBaseDeDatos;Uid=TuUsuario;Pwd=TuContraseña;"
}
```

## Uso de Swagger
La API está documentada utilizando Swagger, lo que te permite explorar y probar los endpoints de manera interactiva.

## Postman
Junto a la entrega del repositorio, les voy a compartir una coleccion de Postman creada para poder probar los endpoints, junto con documentacion como los request y bodys necesarios para cada endpoint.

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

### Toda la demas informacion esta en un .doc dentro del repo.
