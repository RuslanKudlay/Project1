using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class ComputerManufactyrer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ManufactyrerName { get; set; }
        public List<ComtuperModel> ComtuperModels { get; set; }
    }
}
