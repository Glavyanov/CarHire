namespace CarHire.Infrastructure.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    [Comment("Car for rent")]
    public class Vehicle
    {
        [Key]
        [Comment("Primary key")]
        public Guid Id { get; set; }
    }
}
