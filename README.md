# 📌 API de Gestión de Tareas

Este es un proyecto de API RESTful desarrollado en **.NET 8** que permite a los usuarios gestionar tareas, siguiendo principios de **Arquitectura Limpia** y **SOLID**.  
La API está documentada con **Swagger**, se ejecuta en **Docker**, y almacena datos en **MongoDB**.

## Tabla de Contenidos
- [Requisitos Previos](#requisitos-previos)
- [Instalación](#instalación)
- [Docker](#docker)
- [Test y Swagger](#test-y-swagger)
- [Uso](#uso)
- [Consumo de API Externa](#consumo-de-api-externa)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Principios SOLID Aplicados](#principios-solid-aplicados)
- [Manejo de Repositorios](#manejo-de-repositorios)
- [Desarrollado por](#desarrollado-por)

---

## ✅ **Requisitos Previos**
- **.NET 8.0** instalado
- **Docker** (opcional, si deseas ejecutar la aplicación en contenedores)
- **MongoDB** en ejecución (local o en la nube)

---

## 🚀 **Instalación**
1. **Clonar el repositorio**  
   ```sh
   git clone https://github.com/selwysm/c--proyect-api.git
   
2. **Restaurar dependencias**  
   ```sh
   dotnet restore
   
3. **Configurar variables de entorno**
   Crea un archivo .env con los siguientes valores: 
   ```env
   MONGO_CONNECTION_STRING=valores
   DATABASE_NAME=TaskManagementDB
   AUTH0_DOMAIN=valores
   AUTH0_CLIENT_ID=valores
   AUTH0_CLIENT_SECRET=valores
   AUTH0_AUDIENCE=valores
   
4. **Ejecutar la API**
   ```sh
   dotnet run

## 📦 Docker
   📌 Ejecutar con Docker
   Este comando levanta la API y conecta una base de datos MongoDB.
   ```sh
   docker-compose up --build
   ```

## 📖 Test y Swagger
   La API está documentada con Swagger, que permite visualizar y probar los endpoints sin necesidad de usar Postman.
   Puedes acceder a la interfaz en:
   ```sh
   http://localhost:5120/swagger/index.html
   ```

## 📌 Uso (Endpoints)
## 📌 Endpoints Disponibles

| Método  | Endpoint                 | Descripción                 |
|---------|--------------------------|-----------------------------|
| `GET`    | `/api/task`              | Obtener todas las tareas    |
| `POST`   | `/api/task/add`          | Agregar una nueva tarea     |
| `GET`    | `/api/task/status/{status}` | Obtener tareas por estado   |
| `PUT`    | `/api/task/{id}`         | Actualizar una tarea        |
| `DELETE` | `/api/task/{id}`         | Eliminar una tarea          |

## 📌 Estados Permitidos para `status`

| Código | Estado       |
|--------|-------------|
| 0      | Pendiente   |
| 1      | En Progreso |
| 2      | Completada  |

Para agregar o actualizar tareas, el `status` debe enviarse como un número entre **0 y 2**.

## 🌐 Consumo de API Externa

Este proyecto implementa autenticación a través de Auth0.  
Para obtener un token de autenticación:

```sh
GET /api/auth/token
```
### Respuesta:

```json
{
  "accessToken": "eyJhbGciOiJIUzI1NiIs...",
}
```

## 📁 Estructura del Proyecto

```bash
📦 TaskManagement
├── 📂 TaskManagement.API            # API principal
├── 📂 TaskManagement.Application    # Lógica de negocio
├── 📂 TaskManagement.Domain         # Entidades y modelos
├── 📂 TaskManagement.Infrastructure # Persistencia y repositorios
└── 📄 TaskManagement.sln            # Solución de .NET
```

## 🔥 Principios SOLID Aplicados

- **S:** Single Responsibility *(Cada clase tiene una única responsabilidad)*
- **O:** Open/Closed *(El código es extensible sin modificar la base)*
- **L:** Liskov Substitution *(Se usan interfaces y polimorfismo correctamente)*
- **I:** Interface Segregation *(Interfaces específicas para cada funcionalidad)*
- **D:** Dependency Inversion *(Uso de inyección de dependencias)*


## 🚀 Manejo de Repositorios

- `main` → Rama estable para producción.
- `dev` → Desarrollo de nuevas funcionalidades.
- `feature/nueva-funcionalidad` → Ramas específicas para cada cambio.

### Ejemplo:

```sh
git checkout -b feature/agregar-autenticacion
git commit -m "Agregada autenticación con Auth0"
git push origin feature/agregar-autenticacion
```

## 👨‍💻 Desarrollado por

**Selwys Mendoza**

https://www.linkedin.com/in/selwys-mendoza-115b68251/
