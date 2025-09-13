# 📌 API de Gestión de Propiedades

Este es un proyecto de API RESTful desarrollado en **.NET 8** que permite a los usuarios gestionar propiedades inmobiliarias, siguiendo principios de **Arquitectura Limpia** y **SOLID**.
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

   ```

2. **Restaurar dependencias**

   ```sh
   dotnet restore

   ```

3. **Configurar variables de entorno**
   Crea un archivo .env con los siguientes valores:

   ```env
   MONGO_CONNECTION_STRING=valores
   DATABASE_NAME=PropertiesBD
   AUTH0_DOMAIN=valores
   AUTH0_CLIENT_ID=valores
   AUTH0_CLIENT_SECRET=valores
   AUTH0_AUDIENCE=valores

   ```

4. **Ejecutar la API**
   ```sh
   dotnet run
   ```

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

### 🏠 Propiedades

| Método | Endpoint             | Descripción                      |
| ------ | -------------------- | -------------------------------- |
| `GET`  | `/api/property`      | Buscar propiedades (con filtros) |
| `GET`  | `/api/property/{id}` | Obtener detalle de propiedad     |
| `POST` | `/api/property`      | Crear nueva propiedad            |

### 🔐 Autenticación

| Método | Endpoint          | Descripción             |
| ------ | ----------------- | ----------------------- |
| `GET`  | `/api/auth/token` | Obtener token de acceso |

## 📌 Filtros de Búsqueda de Propiedades

Puedes filtrar las propiedades usando los siguientes parámetros de query:

- `name` - Nombre de la propiedad
- `address` - Dirección
- `minPrice` - Precio mínimo
- `maxPrice` - Precio máximo

Ejemplo: `/api/property?name=casa&minPrice=100000&maxPrice=500000`

## 🌐 Consumo de API Externa

Este proyecto implementa autenticación a través de Auth0.
Para obtener un token de autenticación:

```sh
GET /api/auth/token
```

### Respuesta:

```json
{
  "accessToken": "eyJhbGciOiJIUzI1NiIs..."
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

- **S:** Single Responsibility _(Cada clase tiene una única responsabilidad)_
- **O:** Open/Closed _(El código es extensible sin modificar la base)_
- **L:** Liskov Substitution _(Se usan interfaces y polimorfismo correctamente)_
- **I:** Interface Segregation _(Interfaces específicas para cada funcionalidad)_
- **D:** Dependency Inversion _(Uso de inyección de dependencias)_

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

**Ismael Parra**

https://www.linkedin.com/in/ismaelparra
