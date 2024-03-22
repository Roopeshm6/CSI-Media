namespace CSIMedia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sortdata1
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string SortedNumbers { get; set; }

        [StringLength(50)]
        public string SortDirection { get; set; }

        public DateTime? SortTime { get; set; }
    }
}
