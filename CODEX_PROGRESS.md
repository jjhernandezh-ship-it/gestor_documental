# Estado del desarrollo

## Última fase terminada

Primera vertical funcional de fases 1 a 5; bases de fases 6 a 9.

## Funcionalidades implementadas

- Navegación horizontal responsive; los menús internos sólo se renderizan para usuarios autenticados y los catálogos administrativos sólo para el rol Administrador.
- Pantalla de acceso institucional en español, sin enlaces inválidos de autorregistro, y bloqueo tras intentos fallidos habilitado.
- Los usuarios nuevos reciben contraseña temporal y deben reemplazarla obligatoriamente en su primer inicio de sesión antes de acceder al sistema.
- Solución .NET 8 con Clean Architecture ligera y DI.
- SQL Server, EF Core, Identity, roles y administrador inicial configurable.
- Login/logout sin autorregistro público; CRUD inicial de usuarios, áreas y procesos.
- Validación backend estricta de dominios institucionales.
- Carpetas y subcarpetas, breadcrumbs, prevención de ciclos y eliminación lógica de subárbol.
- Documentos privados, upload, descarga autorizada, búsqueda, SHA-256 y versiones inmutables.
- Servicios de permisos Allow/Deny con herencia desde carpetas y auditoría explícita.
- Concurrencia `rowversion`, índices, compensación de archivo si falla la transacción.
- Pruebas de correo y reglas de carpetas.

## Funcionalidades parcialmente implementadas

- Permisos: modelo y evaluación disponibles; falta UI y aplicar el chequeo en cada operación de servicios.
- Auditoría y papelera: persistencia/operaciones listas; faltan pantallas de consulta.
- Usuarios/áreas/procesos: alta y listado; falta edición completa, confirmaciones y paginación UI.
- Preview: entrega privada correcta para PDF/imágenes; falta visor Blazor embebido.

## Pendientes

- Pantallas `/roles-permisos`, `/auditoria`, `/papelera` y filtros avanzados.
- Endurecer autorización recurso por recurso, estadísticas por acceso y auditoría login/logout.
- Pruebas de integración de SQL Server, permisos, versiones, papelera y FileStorage.
- Manejo UI de concurrencia, edición/movimiento y confirmaciones destructivas.

## Decisiones técnicas tomadas

- Archivos fuera de `wwwroot`, ruta generada, lista de extensiones, máximo configurable y SHA-256.
- Documento lógico separado de versiones; una actualización nunca sobrescribe archivos.
- Soft delete de carpeta incluye descendientes y la restauración recupera ese subárbol.
- UTC en persistencia; conversión local sólo para presentación.
- Sin repositorio/UoW genérico, CQRS ni dependencias innecesarias.

## Base de datos

- Migraciones creadas: `InitialCreate` y `AddMustChangePassword` en `src/GDIIECA.Infrastructure/Data/Migrations`.
- Estado: ambas aplicadas en `localhost\SQLEXPRESS`, base `GDIIECA`.

## Build

Último resultado: correcto, 0 warnings, 0 errores.

## Tests

Último resultado: 8 superadas, 0 fallidas, 0 omitidas.

## Próximo paso recomendado

Aplicar `IPermissionService` en cada mutación/lectura y construir primero las pantallas de permisos, auditoría y papelera; luego agregar pruebas de integración.
