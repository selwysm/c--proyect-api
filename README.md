📌 Estructura Inicial del README.md
md
Copiar
Editar
# 📌 API de Gestión de Tareas

Este es un proyecto de API RESTful desarrollado en **.NET 8** que permite a los usuarios gestionar tareas, siguiendo principios de **Arquitectura Limpia** y **SOLID**.  
La API está documentada con **Swagger**, se ejecuta en **Docker**, y almacena datos en **MongoDB**.

## 📑 Tabla de Contenidos
- [Requisitos Previos](#requisitos-previos)
- [Instalación](#instalación)
- [Configuración](#configuración)
- [Uso](#uso)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Principios SOLID Aplicados](#principios-solid-aplicados)
- [Consumo de API Externa](#consumo-de-api-externa)
- [Pruebas Unitarias](#pruebas-unitarias)
- [Docker](#docker)
- [Manejo de Repositorios](#manejo-de-repositorios)
- [Documentación](#documentación)

---

## ✅ **Requisitos Previos**
- **.NET 8.0** instalado
- **Docker** (opcional, si deseas ejecutar la aplicación en contenedores)
- **MongoDB** en ejecución (local o en la nube)

---

## 🚀 **Instalación**
1. **Clonar el repositorio**  
   ```sh
   git clone https://github.com/usuario/taskmanagement-api.git
   cd taskmanagement-api
Restaurar dependencias

sh
Copiar
Editar
dotnet restore
Configurar variables de entorno
Crea un archivo .env con los siguientes valores:

env
Copiar
Editar
MONGO_CONNECTION_STRING=mongodb://localhost:27017
DATABASE_NAME=TaskManagementDB
Ejecutar la API

sh
Copiar
Editar
dotnet run --project TaskManagement.API
🛠 Configuración
La API se configura a través del archivo appsettings.json y variables de entorno.

json
Copiar
Editar
{
  "DatabaseSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "TaskManagementDB"
  }
}
📌 Uso
📌 Endpoints Disponibles
Método	Endpoint	Descripción
GET	/api/task	Obtener todas las tareas
POST	/api/task/add	Agregar una nueva tarea
GET	/api/task/status/{status}	Obtener tareas por estado
PUT	/api/task/{id}	Actualizar una tarea
DELETE	/api/task/{id}	Eliminar una tarea
📌 Estados Permitidos para status
Código	Estado
0	Pendiente
1	En Progreso
2	Completada
Para agregar o actualizar tareas, el status debe enviarse como un número entre 0 y 2.

📂 Estructura del Proyecto
bash
Copiar
Editar
📦 TaskManagement
 ┣ 📂 TaskManagement.API           # API principal
 ┣ 📂 TaskManagement.Application   # Lógica de negocio
 ┣ 📂 TaskManagement.Domain        # Entidades y modelos
 ┣ 📂 TaskManagement.Infrastructure # Persistencia y repositorios
 ┣ 📜 TaskManagement.sln           # Solución de .NET
🔥 Principios SOLID Aplicados
S: Single Responsibility (Cada clase tiene una única responsabilidad)
O: Open/Closed (El código es extensible sin modificar la base)
L: Liskov Substitution (Se usan interfaces y polimorfismo correctamente)
I: Interface Segregation (Interfaces específicas para cada funcionalidad)
D: Dependency Inversion (Uso de inyección de dependencias)
🌐 Consumo de API Externa
Este proyecto implementa autenticación a través de Auth0.
Para obtener un token de autenticación:

sh
Copiar
Editar
GET /api/auth/token
Respuesta:

json
Copiar
Editar
{
  "accessToken": "eyJhbGciOiJIUzI1NiIs...",
  "tokenType": "Bearer"
}
🧪 Pruebas Unitarias
Las pruebas se ejecutan con xUnit.

sh
Copiar
Editar
dotnet test
Casos de prueba implementados:

✅ Validación de creación de tareas.
✅ Verificación de actualización de estado.
✅ Eliminación de tareas inexistentes.
📦 Docker
📌 Ejecutar con Docker
sh
Copiar
Editar
docker-compose up --build
Este comando levanta la API y una base de datos MongoDB en contenedores.

🔀 Manejo de Repositorios
main → Rama estable para producción.
dev → Desarrollo de nuevas funcionalidades.
feature/nueva-funcionalidad → Ramas específicas para cada cambio.
Ejemplo:

sh
Copiar
Editar
git checkout -b feature/agregar-autenticacion
git commit -m "Agregada autenticación con Auth0"
git push origin feature/agregar-autenticacion
📖 Documentación
Swagger está habilitado en:

sh
Copiar
Editar
http://localhost:5000/swagger
📌 Cómo Contribuir
Si deseas contribuir:

Haz un fork del repositorio.
Crea una rama (feature/nueva-funcionalidad).
Realiza cambios y haz un commit.
Crea un pull request.
👨‍💻 Desarrollado por
[Tu Nombre]
[Tu LinkedIn o GitHub]


## Uso
Ejecución en Modo de Desarrollo
```bash
npm run dev
