﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManager.Application.Domain;

public class Assesment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public int Product_Id { get; set; }
    public int Currency_Id { get; set; }
    [ForeignKey(nameof(Product_Id))]
    public virtual Product Product { get; set; }
    [ForeignKey(nameof(Currency_Id))]
    public virtual Currency Currency { get; set; }
}
