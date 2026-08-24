# Gestor Documental Institucional IECA (GDI-IECA)

Aplicación institucional en .NET 8 para organizar carpetas, documentos y versiones con Identity, SQL Server, permisos heredables, auditoría y almacenamiento privado.

## Arquitectura

- `GDIIECA.Domain`: entidades y reglas del dominio sin dependencias de EF/Blazor.
- `GDIIECA.Application`: DTO, validaciones y contratos de casos de uso.
- `GDIIECA.Infrastructure`: EF Core SQL Server, Identity, servicios y almacenamiento local.
- `GDIIECA.Web`: Blazor Web App con Interactive Server y endpoints autorizados.
- `GDIIECA.Tests`: pruebas unitarias de reglas críticas.

El flujo principal es Blazor → servicio de aplicación → EF Core/almacenamiento. Los archivos se guardan fuera de `wwwroot`, con nombres generados, extensión permitida, límite configurable y hash SHA-256.

## Configuración y ejecución

Requisitos: SDK .NET 8 y SQL Server/LocalDB. Ajuste `ConnectionStrings:DefaultConnection` y `FileStorage` en configuración. No guarde credenciales en `appsettings.json`.

```powershell
$env:DOTNET_CLI_HOME="$PWD\.dotnet"
dotnet tool restore
dotnet restore
dotnet tool run dotnet-ef database update --project src/GDIIECA.Infrastructure --startup-project src/GDIIECA.Web
dotnet run --project src/GDIIECA.Web
```

Para crear el administrador inicial use User Secrets:

```powershell
dotnet user-secrets set "InitialAdmin:SeedOnStartup" "true" --project src/GDIIECA.Web
dotnet user-secrets set "InitialAdmin:Email" "admin@ieca.edu.mx" --project src/GDIIECA.Web
dotnet user-secrets set "InitialAdmin:Password" "UNA-CONTRASEÑA-TEMPORAL-SEGURA" --project src/GDIIECA.Web
dotnet user-secrets set "InitialAdmin:FirstName" "Administrador" --project src/GDIIECA.Web
dotnet user-secrets set "InitialAdmin:LastName" "IECA" --project src/GDIIECA.Web
```

Tras el primer arranque, desactive `SeedOnStartup`. No existe autorregistro público. Los correos creados por administración se validan exactamente contra `guanajuato.gob.mx` e `ieca.edu.mx`.

## Funcionalidad

Implementado: login/logout de Identity, roles iniciales, administrador configurable, usuarios institucionales, áreas, procesos, carpetas jerárquicas y prevención de ciclos, explorador y breadcrumbs, búsqueda básica, carga privada, descarga autorizada, hash, versiones inmutables, eliminación lógica/restauración a nivel de servicios, auditoría de operaciones y permisos Allow/Deny heredables. PDF e imágenes se sirven con su MIME y rangos desde un endpoint autenticado, por lo que el navegador puede previsualizarlos.

Las fechas se persisten en UTC y la UI las convierte a hora local. Documento y Carpeta usan `rowversion`. La eliminación de carpeta marca su subárbol; restaurar recupera el mismo subárbol. El borrado físico definitivo no se incluye en esta iteración.

Pendiente: UI completa de permisos, auditoría y papelera; edición/desactivación desde CRUD; comprobación de permisos finos en cada servicio (actualmente las operaciones de UI administrativa usan rol); filtros avanzados y dashboard limitado por permisos; pruebas de integración de EF/FileStorage; captura automática de cambios mediante interceptor. Consulte `CODEX_PROGRESS.md`.
