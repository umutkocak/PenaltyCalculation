namespace PenaltyCalculation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkDay")]
    public partial class WorkDay
    {
        public int Id { get; set; }

        public int? CountryId { get; set; }

        [StringLength(50)]
        public string Day { get; set; }

        public virtual Country Country { get; set; }
    }
}
