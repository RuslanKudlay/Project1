using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class ComputerManufactyrerDto
    {
        public string Id { get; set; }
        public string ManufactyrerName { get; set; }
        public List<ComputerModelDto> ComputerModels { get; set; }
    }
}
