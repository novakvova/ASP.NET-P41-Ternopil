using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebQRCode.Data.Entities.Identity;

namespace WebQRCode.Data.Entities;

public class QrCodeEntity
{
    public int Id { get; set; }

    // Власник QR-коду
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserEntity User { get; set; } = null!;

    // Назва QR-коду, яку бачить користувач
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    // Унікальний ідентифікатор динамічного QR
    [Required]
    [StringLength(100)]
    public string Code { get; set; } = null!;

    // Куди QR перенаправляє користувача
    [Required]
    [StringLength(2048)]
    public string TargetUrl { get; set; } = null!;

    // Чи активний QR-код
    public bool IsActive { get; set; } = true;

    // Дата створення
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Дата останньої зміни
    public DateTime? UpdatedAt { get; set; }

    // Кількість сканувань
    public int ScanCount { get; set; }
}