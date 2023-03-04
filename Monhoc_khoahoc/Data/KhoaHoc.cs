using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Monhoc_khoahoc.Data;

[Table("KhoaHoc")]
public partial class KhoaHoc
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("tenmon")]
    [StringLength(200)]
    public string? Tenmon { get; set; }

    [InverseProperty("IdkhoahocNavigation")]
    public virtual ICollection<MonHoc> MonHocs { get; } = new List<MonHoc>();
}
