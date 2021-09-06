using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class ComtuperModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int ComputerManufactyrerId { get; set; }
        public ComputerManufactyrer ComputerManufactyrer { get; set; }
        public ICollection<ComputerModelTag> ComputerModelTag { get; set; }//s-dobavit
    }
}
