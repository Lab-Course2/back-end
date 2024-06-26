﻿using MindMuse.Application.Contracts.Models.Operations;
using MindMuse.Application.Contracts.Models.Requests;

namespace MindMuse.Application.Contracts.Interfaces
{
    public interface IPatientService
    {
        Task<PatientRequest> GetPatient(string patientId);
        Task<IEnumerable<PatientRequest>> GetAllPatients();
        Task<OperationResult> CreatePatientAsync(PatientRequest personDto);
        Task<OperationResult> UpdatePatient(string personId, PatientRequest personDto);
        Task<OperationResult> DeletePatient(string personId);
        Task<OperationResult> ConfirmEmail(string token, string email);
    }
}