namespace WebApplication2.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class Earthquake
{
    [Key]
    public int Id { get; set; }

    [Required]
    public double Magnitude { get; set; }

    [Required]
    public string Coordinates { get; set; } // Формат "latitude,longitude"

    [Required]
    public DateTime Date { get; set; }
}
