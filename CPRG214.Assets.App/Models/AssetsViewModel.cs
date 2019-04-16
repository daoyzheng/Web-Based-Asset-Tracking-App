using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.Assets.App.Models {
    public class AssetsViewModel {
        public int Id { get; set; }
        [Required, DisplayName("Tag Number")]
        public string TagNumber { get; set; }
        [DisplayName("Asset Types")]
        public string AssetTypes { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, DisplayName("Serial Number")]
        public string SerialNumber { get; set; }
    }
}
