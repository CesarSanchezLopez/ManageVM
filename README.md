
## 📦 Tecnologías

- ⚙️ **Backend**: ASP.NET Core (.NET 7) + Entity Framework Core
- 🌐 **Frontend**: Angular 15+
- 🗃️ **Base de Datos**: SQL Server
- 🔐 **Autenticación**: JWT + Roles (`Admin`, `User`)

## ✅ Requisitos

### Backend (.NET Core API)

- SQL Server instalado o disponible online

### Frontend (Angular)

- Node.js v16+
- Angular CLI:
  npm install -g @angular/cli
  
### Pasos
 
 
### 1. Clona el repositorio

	git clone https://github.com/TU_USUARIO/ManageVM.git
	cd ManageVM

### 2.  Configura la base de datos

Configura la cadena de conexión al archivo:

/Backend/ManageVM.Api/appsettings.Development.json

{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=ManageVMDb;Username=postgres;Password=tuclave"
  }
}

### 3. Ejecuta las migraciones

cd Backend/ManageVM.Api

dotnet ef migrations add InitialCreate
dotnet ef database update


### 4. Corre el Backend

dotnet run --project Backend/ManageVM.Api

### 5. Corre el Frontend Angular

cd Frontend
npm install
ng serve


### 🔐 Usuario de prueba

{
  "username": "UserAdmin",
  "password": "12345"
}
  
  