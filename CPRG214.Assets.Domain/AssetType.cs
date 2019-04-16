using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CPRG214.Assets.Domain {
    public class AssetType {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // Navigation property
        public ICollection<Asset> Assets { get; set; }
    }
}
