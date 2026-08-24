using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GDIIECA.Infrastructure.Data.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20260812090000_SeedDocumentFolderTree")]
public partial class SeedDocumentFolderTree : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("4d0a5693-6403-4729-8e52-d09447f73ee8"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"AREA", null });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("a0457622-19dd-4566-a344-0e4aadfba877"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Administración", new Guid("4d0a5693-6403-4729-8e52-d09447f73ee8") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("5277e416-7575-45c1-b35b-6876fa3186ef"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Coordinación de Analisis y Proyectos Financieros", new Guid("a0457622-19dd-4566-a344-0e4aadfba877") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("6c58b1fb-8805-44cd-bff2-9fa1cb59fff0"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Compras", new Guid("5277e416-7575-45c1-b35b-6876fa3186ef") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("b75e127c-41ce-4c01-9e48-475dff931288"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Formatos", new Guid("5277e416-7575-45c1-b35b-6876fa3186ef") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("ffd8855c-3e50-40e3-9312-2e24b784ed4f"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Coordinación de Recursos Humanos", new Guid("a0457622-19dd-4566-a344-0e4aadfba877") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("5fdc4aa1-3894-4d68-8c2d-76262ef77868"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Coordinación de Recursos Materiales", new Guid("a0457622-19dd-4566-a344-0e4aadfba877") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("a2984d20-feb3-4f0f-899a-1e62ff3ef275"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Control Escolar", new Guid("4d0a5693-6403-4729-8e52-d09447f73ee8") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("4ee71e9c-5fb0-429d-9d36-495487ebea4c"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Coordinación de Asuntos Jurídicos", new Guid("4d0a5693-6403-4729-8e52-d09447f73ee8") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("91d672e7-c284-4c67-9f31-89b01b96040b"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Dirección General", new Guid("4d0a5693-6403-4729-8e52-d09447f73ee8") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("f721e803-344f-4ad8-b235-f608446a4be6"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Formato para Planes Anuales de Trabajo (Comites y Äreas)", new Guid("4d0a5693-6403-4729-8e52-d09447f73ee8") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("25108399-fb16-4749-a5fe-5dde7997fa66"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Formatos para Junta Directiva", new Guid("4d0a5693-6403-4729-8e52-d09447f73ee8") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("d6b1c9b6-3c6d-406c-8548-3fbae6088bc6"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Informática", new Guid("4d0a5693-6403-4729-8e52-d09447f73ee8") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("837b86ff-6e50-42ad-9e17-96a74cb4f1c2"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Operaciones", new Guid("4d0a5693-6403-4729-8e52-d09447f73ee8") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("2e15489e-6fd5-44ee-ac4c-131384fc5ee0"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Reuniones Regionales", new Guid("837b86ff-6e50-42ad-9e17-96a74cb4f1c2") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("6751688d-95e9-4116-af10-440a25d77673"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Documentos Estandarizados SGC IECA", null });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("c2893f36-3dbb-4aff-9029-16766f4ea8b5"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"CAJ Formatos Estandarizados SGC", new Guid("6751688d-95e9-4116-af10-440a25d77673") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("2ebe6686-7af2-4af5-b61a-e52db4465265"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PCAJ002 Elaboración de Instrumentos Jurídicos", new Guid("c2893f36-3dbb-4aff-9029-16766f4ea8b5") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("589e90f7-19c9-4d15-962f-eac65ea0f5ec"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PCDAJ001 Asistencía Jurídica", new Guid("c2893f36-3dbb-4aff-9029-16766f4ea8b5") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("3f1c0884-6ce7-4aab-a58f-41aa33195cd6"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"CDO Formatos Estandarizados SGC", new Guid("6751688d-95e9-4116-af10-440a25d77673") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("394d9432-01ef-4eac-b160-5fb9552c3dfd"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Optativos en Adoptar CDO", new Guid("3f1c0884-6ce7-4aab-a58f-41aa33195cd6") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("d714c041-0d30-4abf-821a-d7eb7e7aa6a5"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDTA001 Autorización de Cursos de Capacitación Registrados en SIIIECA", new Guid("394d9432-01ef-4eac-b160-5fb9552c3dfd") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("57a7b28a-8cc8-4afe-9581-9659b7ff9266"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDTA002 Administración de Cursos y Programas de Capacitación", new Guid("394d9432-01ef-4eac-b160-5fb9552c3dfd") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("8fcea138-d82d-4166-819f-6b4e21189f71"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PCDO001_Coordinaccion_de_la_Operacion_de_las_unidades_de_capacitacion_existentes_en_Estado", new Guid("3f1c0884-6ce7-4aab-a58f-41aa33195cd6") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("3a512d45-341f-4fbd-86bd-dc943dbaa628"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PCDO002_Sistema_de_Administración_del_Instituto_Estatal_de_Capacitación_(SASIECA)", new Guid("3f1c0884-6ce7-4aab-a58f-41aa33195cd6") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("9da0cc3a-3ef2-4d9b-9c75-63b26c4a6e7e"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PUCA001_Colocacion_del_servicio_de_capacitacion", new Guid("3f1c0884-6ce7-4aab-a58f-41aa33195cd6") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("ac0233e2-df19-43b8-905b-6e16eec3fbcc"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FUCA001_Formato_Aceptacion_de_Servicio_1", new Guid("9da0cc3a-3ef2-4d9b-9c75-63b26c4a6e7e") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("56e64439-aa6c-4f1c-9e4e-d100d7840ba5"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PUCA002_Imparticion_de_curso_de_capacitacion", new Guid("3f1c0884-6ce7-4aab-a58f-41aa33195cd6") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("b1092a2c-5ac7-497f-bf1c-ccbd0686f63d"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PUCA003_Gestión_de_Tramites_Administrativos", new Guid("3f1c0884-6ce7-4aab-a58f-41aa33195cd6") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("2e4f1208-ce18-4a66-99ce-bd31d8f76a6c"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"CIT  Formatos Estandarizados SGC", new Guid("6751688d-95e9-4116-af10-440a25d77673") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("ce3c2062-64c8-4881-b127-132e90e95ee2"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"DAF Formatos Estandarizados SGC", new Guid("6751688d-95e9-4116-af10-440a25d77673") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("11450acc-791f-4dae-9ff0-00348768c3fa"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDAF001 Gestión de Pagos y contrataciones", new Guid("ce3c2062-64c8-4881-b127-132e90e95ee2") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("6b53e5f4-8560-42ea-ae99-3a2f631abc43"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDAF002 Gestión de Control Patrimonial", new Guid("ce3c2062-64c8-4881-b127-132e90e95ee2") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("c4f67db9-c88a-4a56-a718-b99b57c53e57"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Fuera por el momento FDAF009", new Guid("6b53e5f4-8560-42ea-ae99-3a2f631abc43") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("038acb62-8613-4e87-9b18-d9cc60f0a6b5"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDAF003 Gestión de Pagos", new Guid("ce3c2062-64c8-4881-b127-132e90e95ee2") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("2c2dc4a3-58b3-43a9-b30a-e2be26449175"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Fuera por el momento FDAF010", new Guid("038acb62-8613-4e87-9b18-d9cc60f0a6b5") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("9cb3560a-6a6d-4142-a52c-215039f3b294"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDAF004 Gestión de Ingresos", new Guid("ce3c2062-64c8-4881-b127-132e90e95ee2") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("b1fbc4df-7e3a-4bd1-85f5-c768200ecf50"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDAF006 Desarrollo del Recurso Humano", new Guid("ce3c2062-64c8-4881-b127-132e90e95ee2") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("146d19d4-fb98-4ff1-8cdc-54d8c50d5402"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDAF008 Gestión de Tramites y Apoyos de Trabajadores(a) del IECA", new Guid("ce3c2062-64c8-4881-b127-132e90e95ee2") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("caed0e00-41ad-4331-a55d-31260f80ae94"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDAF011 Gestión de Registro del Control Patrimonial (inventario)", new Guid("ce3c2062-64c8-4881-b127-132e90e95ee2") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("f291343f-623a-4ff9-beaa-01c70fa8bcef"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"DGE Formatos Estandarizados SGC", new Guid("6751688d-95e9-4116-af10-440a25d77673") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("c5ef4c9b-5c5f-4c61-b381-acc2b7355fa7"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDGE001", new Guid("f291343f-623a-4ff9-beaa-01c70fa8bcef") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("d5bebd0e-4f7c-46ca-be07-d1269ec0de3a"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDGE006_OFICIO_DE_COMISIÓN_3.0", new Guid("c5ef4c9b-5c5f-4c61-b381-acc2b7355fa7") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("a9f196fa-2636-4f28-9c66-2a8b390d3b06"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"DPyE Formatos Estandarizados SGC", new Guid("6751688d-95e9-4116-af10-440a25d77673") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("f6341aad-8020-4c56-a767-a075a4a361fa"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Documento Optativos para subir al Portal y queden en nuestra Jurisdicción", new Guid("a9f196fa-2636-4f28-9c66-2a8b390d3b06") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("240b43a4-f679-4740-9191-5ef415446c91"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDPE001 Seguimiento a la Planeación, Programación y Evaluación del Instituto", new Guid("a9f196fa-2636-4f28-9c66-2a8b390d3b06") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("4ff3c961-b9e6-41df-9fef-c7233a730c71"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDPE002 Actualización de la Información de Control Escolar", new Guid("a9f196fa-2636-4f28-9c66-2a8b390d3b06") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("e51eef81-1de9-4ce4-b117-23a25e9a26df"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDPE012 Formato de Inscripción", new Guid("4ff3c961-b9e6-41df-9fef-c7233a730c71") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("20f4885e-2a61-4120-b02f-fc57ff943f89"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDPE003 Solicitud de Becas", new Guid("a9f196fa-2636-4f28-9c66-2a8b390d3b06") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("bc525d36-3d55-4213-93e2-9f30e0919851"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDPE001 Formato de Solicitud de Eca F80101-01", new Guid("20f4885e-2a61-4120-b02f-fc57ff943f89") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("6c7ae2ea-53f2-4645-a918-5b7526e50ad8"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDPE002 Formato Reporte de Becas", new Guid("20f4885e-2a61-4120-b02f-fc57ff943f89") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("4b64ce75-0192-4028-8ca2-a0d1508a2f2d"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDPE014 Solicitud de Becas Grupales con Instructor de Honorarios", new Guid("20f4885e-2a61-4120-b02f-fc57ff943f89") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("27e1fa61-c439-4be4-8d13-96bad19cbff6"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDPE015 Solicitud de BEcas para Personal del IECA", new Guid("20f4885e-2a61-4120-b02f-fc57ff943f89") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("c53ffa07-b607-41fe-aa1c-5443e3b6bd71"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDPE016 Solicitud de Beca Individual con Instructor de Honorarios", new Guid("20f4885e-2a61-4120-b02f-fc57ff943f89") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("92b99ed3-1eb2-4702-ac2a-30bed1f9e1e8"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDPE017 Informe de Actividades y Supervisión", new Guid("20f4885e-2a61-4120-b02f-fc57ff943f89") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("55ace263-3642-45c2-ad8a-94c40c5e6956"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDPE012 Desarrollar las Sesiones de Junta Directiva", new Guid("a9f196fa-2636-4f28-9c66-2a8b390d3b06") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("3d6d569d-3399-40e6-a8c3-cbb0b245c6a0"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Planeación Institucional", new Guid("a9f196fa-2636-4f28-9c66-2a8b390d3b06") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("413a9722-54b6-4627-b550-8b8ab10d5ff7"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"DTA Formatos Estandarizados SGC", new Guid("6751688d-95e9-4116-af10-440a25d77673") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("f6265536-15c2-4187-b47d-2042e2b196f5"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDTA001", new Guid("413a9722-54b6-4627-b550-8b8ab10d5ff7") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("96e18a67-3645-44d9-bec7-f898f22d069d"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDTA001 Formato Solicitud de Apertura de Curso", new Guid("f6265536-15c2-4187-b47d-2042e2b196f5") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("f79d94ee-34c8-4add-8c3f-58150c115886"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDTA002 Formato Materiales Regulares y Semiperecederos", new Guid("f6265536-15c2-4187-b47d-2042e2b196f5") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("a5f736f7-905f-4e15-b52e-4cc7a155e2cb"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDTA003 Formatos Compra de Perecederos", new Guid("f6265536-15c2-4187-b47d-2042e2b196f5") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("5c76a074-9f4b-485f-910c-e3d3e11a0c44"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDTA004 Formato Contenido Temático del Curso", new Guid("f6265536-15c2-4187-b47d-2042e2b196f5") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("9a135231-24d3-408e-8154-8133dd674f16"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDTA002", new Guid("413a9722-54b6-4627-b550-8b8ab10d5ff7") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("f498d74b-6acd-4815-bf4a-5781ef2dc999"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDTA007 Formato Evaluación Curso Instructor", new Guid("9a135231-24d3-408e-8154-8133dd674f16") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("f3d9ace7-346d-4556-a2e8-2365cf0aab8c"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDTA010 Formato Carta de Retención ISR", new Guid("9a135231-24d3-408e-8154-8133dd674f16") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("233ce9c7-f35c-49ba-a490-9c996fff8479"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDTA011 Formato Oficio de Instrucción", new Guid("9a135231-24d3-408e-8154-8133dd674f16") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("7395fa1e-1ecd-46b8-9380-feaa0170ca5b"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDTA024 Requerimiento de Diseño de Contenido Temático", new Guid("9a135231-24d3-408e-8154-8133dd674f16") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("e9cbbd68-6ad6-4581-8261-4a7d31124ea7"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDTA004", new Guid("413a9722-54b6-4627-b550-8b8ab10d5ff7") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("5403e470-34b5-47bb-81cf-9a47b72b6f5a"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"DVC Formatos Estandarizados SGC", new Guid("6751688d-95e9-4116-af10-440a25d77673") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("1faadb25-7984-4d2b-aa43-928fe1d06794"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDCV006 Vincular los Servicios de Capacitación del IECA", new Guid("5403e470-34b5-47bb-81cf-9a47b72b6f5a") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("a8d66ece-e8fd-4079-a487-7bffca732263"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDVC001 Medición del Nivel de Satisfacción del Usuario", new Guid("5403e470-34b5-47bb-81cf-9a47b72b6f5a") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("d8864365-d3a3-432d-ba83-b5d65279a991"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDVC001 Encuestas Seguimiento a Egresados", new Guid("a8d66ece-e8fd-4079-a487-7bffca732263") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("1a9cc64d-cdeb-4428-b505-03a7cd25981b"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDVC002 Encuestas Satisfacción al Usuario", new Guid("a8d66ece-e8fd-4079-a487-7bffca732263") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("d58563e2-a93e-4b42-864d-68735bec3983"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDVC003 Encuestas Satisfacción al Cliente", new Guid("a8d66ece-e8fd-4079-a487-7bffca732263") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("959a9003-7322-4aad-9e37-033dd36f1ced"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDVC004 Formato Plan de Acción Egresados", new Guid("a8d66ece-e8fd-4079-a487-7bffca732263") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("6be50c05-1eaa-4d4e-a7f9-313f78660e9e"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDVC002 Implementación del Programa de Promoción e Imagen Institucional", new Guid("5403e470-34b5-47bb-81cf-9a47b72b6f5a") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("821728c2-1247-4f41-a394-c5c6a71487d3"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"PDVC003 Generación de Vínculos para la Prestación de Servicios", new Guid("5403e470-34b5-47bb-81cf-9a47b72b6f5a") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("0ad757e5-431f-423e-ac1d-2d06b8056456"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDVC006 Formato Cotización", new Guid("821728c2-1247-4f41-a394-c5c6a71487d3") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("7e763ee6-41e4-4157-a47a-80f30a21b13a"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"FDVC008 Reporte Comparativo de Ventas", new Guid("821728c2-1247-4f41-a394-c5c6a71487d3") });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("212c10d0-a253-4bab-afee-516363387726"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Planeación Institucional", null });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("294aa246-a7b4-45a9-89ee-cc62c815d0be"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"POLITICAS", null });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("3d2e96b4-c0f3-4d18-8531-4bdfd5968f7f"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Políticas", null });
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "ParentFolderId" },
            columnTypes: new[] { "uniqueidentifier", "datetime2", "nvarchar(max)", "bit", "nvarchar(150)", "uniqueidentifier" },
            values: new object?[] { new Guid("9d03f69f-ff47-4164-beb2-21e6694275ec"), new DateTime(2026, 8, 12, 15, 0, 0, DateTimeKind.Utc), "system", false, @"Subcomité de Tecnologías de la Información y Telecomunicaciones", null });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("9d03f69f-ff47-4164-beb2-21e6694275ec"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("3d2e96b4-c0f3-4d18-8531-4bdfd5968f7f"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("294aa246-a7b4-45a9-89ee-cc62c815d0be"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("212c10d0-a253-4bab-afee-516363387726"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("7e763ee6-41e4-4157-a47a-80f30a21b13a"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("0ad757e5-431f-423e-ac1d-2d06b8056456"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("821728c2-1247-4f41-a394-c5c6a71487d3"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("6be50c05-1eaa-4d4e-a7f9-313f78660e9e"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("959a9003-7322-4aad-9e37-033dd36f1ced"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("d58563e2-a93e-4b42-864d-68735bec3983"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("1a9cc64d-cdeb-4428-b505-03a7cd25981b"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("d8864365-d3a3-432d-ba83-b5d65279a991"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("a8d66ece-e8fd-4079-a487-7bffca732263"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("1faadb25-7984-4d2b-aa43-928fe1d06794"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("5403e470-34b5-47bb-81cf-9a47b72b6f5a"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("e9cbbd68-6ad6-4581-8261-4a7d31124ea7"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("7395fa1e-1ecd-46b8-9380-feaa0170ca5b"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("233ce9c7-f35c-49ba-a490-9c996fff8479"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("f3d9ace7-346d-4556-a2e8-2365cf0aab8c"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("f498d74b-6acd-4815-bf4a-5781ef2dc999"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("9a135231-24d3-408e-8154-8133dd674f16"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("5c76a074-9f4b-485f-910c-e3d3e11a0c44"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("a5f736f7-905f-4e15-b52e-4cc7a155e2cb"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("f79d94ee-34c8-4add-8c3f-58150c115886"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("96e18a67-3645-44d9-bec7-f898f22d069d"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("f6265536-15c2-4187-b47d-2042e2b196f5"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("413a9722-54b6-4627-b550-8b8ab10d5ff7"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("3d6d569d-3399-40e6-a8c3-cbb0b245c6a0"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("55ace263-3642-45c2-ad8a-94c40c5e6956"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("92b99ed3-1eb2-4702-ac2a-30bed1f9e1e8"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("c53ffa07-b607-41fe-aa1c-5443e3b6bd71"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("27e1fa61-c439-4be4-8d13-96bad19cbff6"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("4b64ce75-0192-4028-8ca2-a0d1508a2f2d"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("6c7ae2ea-53f2-4645-a918-5b7526e50ad8"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("bc525d36-3d55-4213-93e2-9f30e0919851"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("20f4885e-2a61-4120-b02f-fc57ff943f89"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("e51eef81-1de9-4ce4-b117-23a25e9a26df"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("4ff3c961-b9e6-41df-9fef-c7233a730c71"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("240b43a4-f679-4740-9191-5ef415446c91"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("f6341aad-8020-4c56-a767-a075a4a361fa"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("a9f196fa-2636-4f28-9c66-2a8b390d3b06"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("d5bebd0e-4f7c-46ca-be07-d1269ec0de3a"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("c5ef4c9b-5c5f-4c61-b381-acc2b7355fa7"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("f291343f-623a-4ff9-beaa-01c70fa8bcef"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("caed0e00-41ad-4331-a55d-31260f80ae94"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("146d19d4-fb98-4ff1-8cdc-54d8c50d5402"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("b1fbc4df-7e3a-4bd1-85f5-c768200ecf50"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("9cb3560a-6a6d-4142-a52c-215039f3b294"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("2c2dc4a3-58b3-43a9-b30a-e2be26449175"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("038acb62-8613-4e87-9b18-d9cc60f0a6b5"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("c4f67db9-c88a-4a56-a718-b99b57c53e57"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("6b53e5f4-8560-42ea-ae99-3a2f631abc43"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("11450acc-791f-4dae-9ff0-00348768c3fa"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("ce3c2062-64c8-4881-b127-132e90e95ee2"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("2e4f1208-ce18-4a66-99ce-bd31d8f76a6c"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("b1092a2c-5ac7-497f-bf1c-ccbd0686f63d"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("56e64439-aa6c-4f1c-9e4e-d100d7840ba5"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("ac0233e2-df19-43b8-905b-6e16eec3fbcc"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("9da0cc3a-3ef2-4d9b-9c75-63b26c4a6e7e"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("3a512d45-341f-4fbd-86bd-dc943dbaa628"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("8fcea138-d82d-4166-819f-6b4e21189f71"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("57a7b28a-8cc8-4afe-9581-9659b7ff9266"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("d714c041-0d30-4abf-821a-d7eb7e7aa6a5"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("394d9432-01ef-4eac-b160-5fb9552c3dfd"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("3f1c0884-6ce7-4aab-a58f-41aa33195cd6"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("589e90f7-19c9-4d15-962f-eac65ea0f5ec"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("2ebe6686-7af2-4af5-b61a-e52db4465265"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("c2893f36-3dbb-4aff-9029-16766f4ea8b5"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("6751688d-95e9-4116-af10-440a25d77673"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("2e15489e-6fd5-44ee-ac4c-131384fc5ee0"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("837b86ff-6e50-42ad-9e17-96a74cb4f1c2"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("d6b1c9b6-3c6d-406c-8548-3fbae6088bc6"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("25108399-fb16-4749-a5fe-5dde7997fa66"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("f721e803-344f-4ad8-b235-f608446a4be6"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("91d672e7-c284-4c67-9f31-89b01b96040b"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("4ee71e9c-5fb0-429d-9d36-495487ebea4c"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("a2984d20-feb3-4f0f-899a-1e62ff3ef275"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("5fdc4aa1-3894-4d68-8c2d-76262ef77868"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("ffd8855c-3e50-40e3-9312-2e24b784ed4f"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("b75e127c-41ce-4c01-9e48-475dff931288"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("6c58b1fb-8805-44cd-bff2-9fa1cb59fff0"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("5277e416-7575-45c1-b35b-6876fa3186ef"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("a0457622-19dd-4566-a344-0e4aadfba877"));
        migrationBuilder.DeleteData(table: "Folders", keyColumn: "Id", keyValue: new Guid("4d0a5693-6403-4729-8e52-d09447f73ee8"));
    }
}



