using BusinessLayer.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.ComputerService
{
    public class AdvancedComputerService: IComputerService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public AdvancedComputerService(IApplicationDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public string AddManufactyrer(ComputerManufactyrerDto computerManufactyrer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteManufactyrer(string id)
        {
            throw new NotImplementedException();
        }

        public List<ComputerManufactyrerDto> GetComputerManufactyrers()
        {
            var manufactyrers = _dbContext.ComputerManufactyrers.Include(_ => _.ComtuperModels).ToList();
            var resultList = new List<ComputerManufactyrerDto>();

            foreach (var manufactyrer in manufactyrers)
            {
                resultList.Add(new ComputerManufactyrerDto
                {
                    ManufactyrerName = manufactyrer.ManufactyrerName,
                    ComputerModels = manufactyrer?.ComtuperModels?.Select(model => new ComputerModelDto
                    { ModelName = model.ModelName }).ToList()
                });
            }
            return resultList;
        }
    }
}
