# Sistema de gestion de permisos

## 🔨 Tecnologias

- `Arquitectura`: Clean Architecture
- `Patrones de diseño`: Repository, CQRS, Mediator, UnitOfWork, Dependency Injection
- `Lenguaje programación`: C#
- `Frameworks`: .NET 8 , Entity Framework Core 8

## 📁 Acceso al proyecto

Se debe clonar el repositorio desde GitHub **https://github.com/FelipeChara/PermissionManagement.git**

## 🛠️ Abre, configura y ejecuta el proyecto

- Se requiere base de datos creada en SQL Server para la persistencia de datos.
- Configurar ConnetionString **"DdConnection"** en **appsettings.json** para conexion con base de datos.
- Compilar Solucion
- Establecer **PermissionManagement.API** como proyecto de Inicio.
- Abrir la Consola de Administrador de Paquetes y seleccionar el proyecto **PermissionManagement.Infraestructure**, ejecutar los siguientes comandos:
  - Ejecutar **Add-Migration Initial**
  - Ejecutar **Update-Database**

## ✔️ Funcionalidades

- `Solicitar permiso`
- `Editar Permiso`
- `Obtener lista permisos por empleado`
- `Obtener permiso por id`
