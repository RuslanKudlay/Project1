using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Models;

namespace BusinessLayer.ComputerService
{
    public interface IComputerService
    {
        string AddManufactyrer(ComputerManufactyrerDto computerManufactyrer);
        List<ComputerManufactyrerDto> GetComputerManufactyrers();
        bool DeleteManufactyrer(string id);

    }
}
