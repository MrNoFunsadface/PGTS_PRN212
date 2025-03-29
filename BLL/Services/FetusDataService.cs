﻿using DAL.Entities;
using DAL.Repos.Interfaces;

namespace BLL.Services
{
    public class FetusDataService
    {
        private readonly IFetusDataRepo _fetusDataRepo;

        public FetusDataService(IFetusDataRepo fetusDataRepo)
        {
            _fetusDataRepo = fetusDataRepo;
        }

        public IEnumerable<FetusData> GetAll() => _fetusDataRepo.GetAll();
        public FetusData GetById(int id) => _fetusDataRepo.GetById(id);
        public void Add(FetusData fetusData) => _fetusDataRepo.Add(fetusData);
        public void Update(FetusData fetusData) => _fetusDataRepo.Update(fetusData);
        public void Delete(int id) => _fetusDataRepo.Delete(id);
    }
}
