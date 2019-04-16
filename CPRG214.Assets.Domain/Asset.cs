using System;
using System.ComponentModel.DataAnnotations;

namespace CPRG214.Assets.Domain {
    public class Asset {
        public int Id { get; set; }
        [Required]
        public string TagNumber { get; set; }
        public int AssetTypeId { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SerialNumber { get; set; }

        // Navigation property
        public AssetType AssetType { get; set; }
    }
}
