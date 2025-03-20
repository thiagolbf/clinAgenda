using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinAgenda.src.Application.DTOs.Specialty;
using ClinAgenda.src.Core.Interfaces;

namespace ClinAgenda.src.Application.UseCases
{
    public class SpecialtyUseCase
    {
        private readonly ISpecialtyRepository _specialtyRepository;

        public SpecialtyUseCase(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        public async Task<object> GetSpecialtyAsync(int itemsPerPage, int page)
        {
            var (total, rawData) = await _specialtyRepository.GetAllAsync(itemsPerPage, page);

            return new
            {
                total,
                items = rawData.ToList()
            };
        }

        public async Task<int> CreateSpecialtyAsync(SpecialtyInsertDTO specialtyDTO)
        {
           
            var newSpecialtyId = await _specialtyRepository.InsertSpecialtyAsync(specialtyDTO);

            return newSpecialtyId;

        }
        public async Task<SpecialtyDTO?> GetSpecialtyByIdAsync(int id)
        {
            return await _specialtyRepository.GetByIdAsync(id);
        }

    }
}