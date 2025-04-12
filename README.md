#  ClienteApi2

API RESTful construida en **.NET 9** con **Entity Framework Core**, diseñada para gestionar registros de clientes de forma segura y eficiente.

---

##  Características principales

- CRUD completo para la entidad `Cliente`
- Middleware personalizado para validación de **API Key**
- Conexión a base de datos **SQL Server remoto**
- Validaciones en modelo: nombre con solo letras, email válido, teléfono de 10 dígitos
- Documentación interactiva con **Swagger**
- Preparado para migraciones EF Core (`InitialCreate`)

---

##  Tecnologías utilizadas

- .NET 9 Web API
- Entity Framework Core
- SQL Server
- Swagger (Swashbuckle)
- Data Annotations para validación

---

##  Validaciones

Al crear o actualizar un cliente, se aplican estas reglas:

-  **Nombre**: Solo letras, sin números
-  **Correo electrónico**: Formato válido, debe contener `@`
-  **Teléfono**: Solo números, exactamente 10 dígitos

---

##  Cómo ejecutar el proyecto

1. Clona el repositorio:

   ```bash
   git clone https://github.com/tu-usuario/ClienteApi2.git
   cd ClienteApi2
   ```

2. Restaura las dependencias:

   ```bash
   dotnet restore
   ```

3. Crea la base de datos y aplica la migración inicial:

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. Ejecuta la API:

   ```bash
   dotnet run
   ```

5. Accede a Swagger en:

   ```
   https://localhost:{puerto}/swagger
   ```

---

##  Uso de API Key

La API requiere una API Key enviada en el header:

```
x-api-key: TU_API_KEY
```

(Si no se envía o es incorrecta, se devuelve HTTP 401 Unauthorized)

---

## 🧪 Pruebas desde Postman o Swagger

| Método | Ruta                      | Descripción             |
|--------|---------------------------|-------------------------|
| GET    | `/api/cliente`            | Obtener todos los clientes |
| GET    | `/api/cliente/{id}`       | Obtener un cliente por ID |
| POST   | `/api/cliente`            | Crear un nuevo cliente     |
| PUT    | `/api/cliente/{id}`       | Actualizar un cliente      |
| DELETE | `/api/cliente/{id}`       | Eliminar un cliente        |

---
# clientesApi2
