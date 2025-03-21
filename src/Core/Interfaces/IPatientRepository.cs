using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendClinAgenda.src.Application.DTOs.Patient;

namespace BackendClinAgenda.src.Core.Interfaces
{
    public interface IPatientRepository
    {
        Task<PatientDTO> GetByIdAsync(int id);
    }
}