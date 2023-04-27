using System.ComponentModel.DataAnnotations;

public class Pet
{

    public uint PetId { get; set; }

    public string Name { get; set; } = "";

    public uint Age { get; set; }

    public string PetType { get; set; } = "";//cat or dog

    public string Gender { get; set; } = "";

    public string Description { get; set; } = "";//extra details such as breed, color, health/behavioral issues if any etc.

    [DataType(DataType.Date)]
    public DateTime Birthday { get; set; } = DateTime.Today;
    public string FileName { get; set; } = ""; //the image file name


}