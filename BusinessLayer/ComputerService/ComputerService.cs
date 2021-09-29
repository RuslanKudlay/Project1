using AutoMapper;
using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.ComputerService
{
    public class ComputerService : IComputerService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly Mapper _autoMapper;
        public ComputerService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            var mapperConfig = new MapperConfiguration(_ =>
            {
                _.CreateMap<ComputerManufactyrer, ComputerManufactyrerDto>()
                .ForMember(_ => _.ComputerModels, _ => _.MapFrom
                (_ => _.ComtuperModels.Select(_ => new ComputerModelDto
                {
                    ModelName = _.ModelName
                })));
            });
            _autoMapper = new Mapper(mapperConfig);
        }
        public string AddManufactyrer(ComputerManufactyrerDto computerManufactyrer)
        {
            var manufactyrer = new ComputerManufactyrer
            {
                ManufactyrerName = computerManufactyrer.ManufactyrerName
            };

            manufactyrer.ComtuperModels = new List<ComtuperModel>();
            foreach(var model in computerManufactyrer.ComputerModels)
            {
                manufactyrer.ComtuperModels.Add(new ComtuperModel
                { 
                    ModelName = model.ModelName 
                });
            }
            _dbContext.ComputerManufactyrers.Add(manufactyrer);
            _dbContext.SaveChanges();

            return manufactyrer.Id;
        }
        public List<ComputerManufactyrerDto> GetComputerManufactyrers()
        {
            var manufactyrers = _dbContext.ComputerManufactyrers.Include(_ => _.ComtuperModels).ToList();
            var resultList = new List<ComputerManufactyrerDto>();

            foreach(var manufactyrer in manufactyrers)
            {
                resultList.Add(new ComputerManufactyrerDto
                {
                    ManufactyrerName = manufactyrer.ManufactyrerName,
                    ComputerModels = manufactyrer?.ComtuperModels?.Select(model => new ComputerModelDto 
                    {ModelName = model.ModelName }).ToList()
                });
            }
            return resultList;
        }

        public bool DeleteManufactyrer(string id)
        {
            var manufactyrer = _dbContext.ComputerManufactyrers.Include(_ => _.ComtuperModels).FirstOrDefault(_ => _.Id == id);
            if(manufactyrer != null)
            {
                _dbContext.ComputerManufactyrers.Remove(manufactyrer);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
