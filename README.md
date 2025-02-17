Nombre : JUAN PABLO CANTURRIANO UPIA


Proyecto de Gestión de Tokens y Permisos
Este proyecto es una aplicación ASP.NET Core que permite la gestión de tokens y permisos para la autenticación y autorización de usuarios. La aplicación utiliza una base de datos MySQL para almacenar los datos de usuarios, roles, permisos y tokens.

Requisitos Previos
Antes de ejecutar la aplicación en otra máquina, asegúrate de tener los siguientes requisitos previos instalados:

.NET SDK 6.0

MySQL Server

MySQL Workbench (opcional, para administración de base de datos)

Visual Studio Code o Visual Studio 2022 (opcional, para desarrollo)

Configuración de la Base de Datos
Crea una base de datos en MySQL para la aplicación:

sql
CREATE DATABASE ABRIR EL .SQL de Nombre RecreationalClub.sql;
Configura las credenciales de acceso a la base de datos en el archivo appsettings.json:

json
{
  "JwtConfiguration": {
    "JwtSecret": "TuClaveSecretaAquí",
    "Issuer": "TuIssuerAquí",
    "Audience": "TuAudienceAquí"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=tu-servidor;Database=TokenManagementDB;User=tu-usuario;Password=tu-contraseña;"
  }
}
Configuración del Proyecto
Clona el repositorio del proyecto en tu máquina local:

bash
git clone https://github.com/jcanturrino/RecreationalClubApp.git
Navega al directorio del proyecto:

bash
cd tu-proyecto
Restaura las dependencias del proyecto:

bash
dotnet restore
Aplica las migraciones de la base de datos para crear las tablas necesarias:

bash
dotnet ef database update
Ejecución de la Aplicación
Ejecuta la aplicación:

bash
dotnet run
La aplicación estará disponible en https://localhost:5001 (o http://localhost:5000).

Uso de Swagger
La aplicación utiliza Swagger para documentar y probar los endpoints de la API. Puedes acceder a Swagger en https://localhost:5001/swagger.

Consideraciones Importantes
Asegúrate de que la sección JwtConfiguration en appsettings.json esté configurada correctamente con una clave secreta (JwtSecret), un emisor (Issuer) y una audiencia (Audience).

Asegúrate de que la cadena de conexión en appsettings.json (DefaultConnection) esté configurada con las credenciales correctas para acceder a la base de datos MySQL.

Verifica que todas las dependencias estén instaladas y configuradas correctamente.
