# 🧠 Documentación Técnica – Proyecto ManageVM

Este documento describe la arquitectura de la aplicación ManageVM, su estructura de carpetas y los módulos principales tanto del Backend (API .NET) como del Frontend (Angular).

---

## 🏛️ Arquitectura General

La aplicación ManageVM está dividida en dos grandes módulos:

1. **Backend (API RESTful con .NET Core)** – expone endpoints para la gestión de máquinas virtuales y usuarios con autenticación basada en JWT.
2. **Frontend (Angular SPA)** – aplicación cliente con formularios protegidos por autenticación y control de roles.

---

## 🔧 Backend - ASP.NET Core (.NET 7)

### 📁 Estructura de Carpetas

ManageVM/ 
├── Backend/ 
│ └── ManageVM.Api/ 
│ ├── Controllers/ 
│ ├── Data/ 
│ ├── DTOs/ 
│ ├── Enums/ 
│ ├── Interfaces/ 
│ ├── Models/ 
│ ├── Services/ 
│ └── Program.cs


### 🧱 Arquitectura limpia

Se sigue una estructura tipo Clean Architecture:

- **Controllers**: puntos de entrada HTTP (REST)
- **Services**: lógica de negocio (inyectados como dependencias)
- **Interfaces**: contratos para los servicios (Inversión de dependencias)
- **Models**: entidades que representan la BD
- **DTOs**: objetos que encapsulan datos para comunicación API
- **Enums**: definición de roles u otros valores constantes
- **Data**: `ApplicationDbContext`, configuraciones EF Core


### 🔐 Autenticación y Autorización

- JWT con middleware (`AddAuthentication`, `AddJwtBearer`)
- Claims de roles: `Admin` y `User`

### 🗄️ Persistencia con EF Core

- Se usa Code First con `DbContext` (`ApplicationDbContext`)
- Migraciones automáticas en producción con `db.Database.Migrate();`


## 🖼️ Frontend - Angular

### 📁 Estructura

Frontend/ 
├── src/ 
│ ├── app/ 
│ │ ├── components/ // vms.component.ts, login.component.ts 
│ │ ├── services/ // auth.service.ts, vm.service.ts 
│ │ ├── guards/ // auth.guard.ts 
│ │ ├── models/ // vm.model.ts, user.model.ts 
│ │ ├── app-routing.module.ts 
│ │ └── app.module.ts



### 🔐 Autenticación en frontend

- Manejo de token JWT con `AuthService`
- Guardas de ruta (`AuthGuard`) para proteger módulos según roles

### 💻 Componentes clave

- `LoginComponent`: formulario para autenticarse
- `VmsComponent`: CRUD de máquinas virtuales


### 📡 Servicios

- `VmService`: comunica con `/api/vm`
- `AuthService`: login, logout, token y rol
