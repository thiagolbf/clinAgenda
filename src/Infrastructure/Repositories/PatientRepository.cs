using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendClinAgenda.src.Application.DTOs.Patient;
using BackendClinAgenda.src.Core.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;

namespace BackendClinAgenda.src.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MySqlConnection _connection;

        public PatientRepository(MySqlConnection connection) 
        {
            _connection = connection;
        }

        public async Task<PatientDTO> GetByIdAsync(int id)
        {
            const string query = @"
                SELECT
                    ID,
                    NAME,
                    PHONENUMBER,
                    DOCUMENTNUMBER,
                    STATUSID,
                    BIRTHDATE,
                WHERE ID = @Id";

            var patient = await _connection.QueryFirstOrDefaultAsync<PatientDTO>(query, new {Id = id});

            return patient;
        }

        
    }
}