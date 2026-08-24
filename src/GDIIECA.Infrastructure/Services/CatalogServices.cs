using GDIIECA.Application.DTOs;
using GDIIECA.Application.Interfaces;
using GDIIECA.Domain.Entities;
using GDIIECA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GDIIECA.Infrastructure.Services;

public sealed class AreaService(ApplicationDbContext db, IAuditService audit) : IAreaService
{
    public async Task<IReadOnlyList<AreaDto>> ListAsync(CancellationToken ct = default) => await db.Areas.AsNoTracking().OrderBy(x => x.Name).Select(x => new AreaDto(x.Id, x.Name, x.Description, x.IsActive)).ToListAsync(ct);
    public async Task<Guid> SaveAsync(AreaDto dto, string userId, CancellationToken ct = default)
    {
        var item = dto.Id == Guid.Empty ? new Area { CreatedById = userId } : await db.Areas.SingleAsync(x => x.Id == dto.Id, ct);
        if (dto.Id == Guid.Empty) db.Areas.Add(item); else { item.ModifiedAtUtc = DateTime.UtcNow; item.ModifiedById = userId; }
        item.Name = dto.Name.Trim(); item.Description = dto.Description?.Trim(); item.IsActive = dto.IsActive;
        await db.SaveChangesAsync(ct); await audit.RecordAsync(dto.Id == Guid.Empty ? "AREA_CREADA" : "AREA_MODIFICADA", nameof(Area), item.Id.ToString(), item.Name, userId, newValues: dto, ct: ct); return item.Id;
    }
}

public sealed class ProcessService(ApplicationDbContext db, IAuditService audit) : IProcessService
{
    public async Task<IReadOnlyList<ProcessDto>> ListAsync(CancellationToken ct = default) => await db.Processes.AsNoTracking().OrderBy(x => x.Code).Select(x => new ProcessDto(x.Id, x.Code, x.Name, x.Description, x.AreaId, x.Area == null ? null : x.Area.Name, x.IsActive)).ToListAsync(ct);
    public async Task<Guid> SaveAsync(ProcessDto dto, string userId, CancellationToken ct = default)
    {
        var item = dto.Id == Guid.Empty ? new Process { CreatedById = userId } : await db.Processes.SingleAsync(x => x.Id == dto.Id, ct);
        if (dto.Id == Guid.Empty) db.Processes.Add(item); else { item.ModifiedAtUtc = DateTime.UtcNow; item.ModifiedById = userId; }
        item.Code = dto.Code.Trim().ToUpperInvariant(); item.Name = dto.Name.Trim(); item.Description = dto.Description?.Trim(); item.AreaId = dto.AreaId; item.IsActive = dto.IsActive;
        await db.SaveChangesAsync(ct); await audit.RecordAsync(dto.Id == Guid.Empty ? "PROCESO_CREADO" : "PROCESO_MODIFICADO", nameof(Process), item.Id.ToString(), $"{item.Code} - {item.Name}", userId, newValues: dto, ct: ct); return item.Id;
    }
}
