using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace KafkaToPsql.Repository.Model;

public class TestModel
{
    [Column("id")]
    [Key]
    [MaxLength(300)]
    [Required]
    public string Id { get; set; }

    [Column("kafkatestvalue")]
    [MaxLength(100)]
    [Required]
    public string KafkaValue { get; set; }
}
