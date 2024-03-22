namespace CSIMedia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SortData")]
    public partial class SortData
    {
        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(50)]
        public string UserInput { get; set; }

        [StringLength(50)]
        public string SortedNumbers { get; set; }

        [StringLength(15)]
        public string SortDirection { get; set; }

        public DateTime? SortTime { get; set; }
    }
}
