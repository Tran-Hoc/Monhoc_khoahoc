using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Monhoc_khoahoc.Data;

[Table("MonHoc")]
public partial class MonHoc
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("tenmon")]
    [StringLength(200)]
    public string? Tenmon { get; set; }

    [Column("idkhoahoc")]
    public int? Idkhoahoc { get; set; }

    [ForeignKey("Idkhoahoc")]
    [InverseProperty("MonHocs")]
    public virtual KhoaHoc? IdkhoahocNavigation { get; set; }
}
