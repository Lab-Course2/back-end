﻿using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MindMuse.Application.Contracts.Interfaces;
using MindMuse.Application.Contracts.Models.Requests;

namespace MindMuse.AspNetCore.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IValidator<PatientRequest> _patientValidator;
        public PatientController(IPatientService patientService, IValidator<PatientRequest> patientValidator, IUserService userService)
        {
            _patientService = patientService;
            _patientValidator = patientValidator;
        }

        [HttpPost("CreatePatient")]
        public async Task<IActionResult> CreatePatient([FromBody] PatientRequest patientRequest)
        {
            _patientValidator.ValidateAndThrow(patientRequest);

            var result = await _patientService.CreatePatientAsync(patientRequest);
            return Ok(result);
        }



        [HttpPut("UpdatePatient/{personId}")]
        public async Task<IActionResult> UpdatePatient(string personId, [FromBody] PatientRequest patientRequest)
        {
            _patientValidator.ValidateAndThrow(patientRequest);

            var result = await _patientService.UpdatePatient(personId, patientRequest);

            return Ok(result);
        }

        [HttpGet("GetPatientById")]
        public async Task<IActionResult> GetPatientById(string patientId)
        {
            var result = await _patientService.GetPatient(patientId);
            return Ok(result);
        }

        [HttpGet("GetAllPatients")]
        public async Task<ActionResult<IEnumerable<PatientRequest>>> GetAllPatients()
        {
            var result = await _patientService.GetAllPatients();

            return Ok(result);
        }

        [HttpDelete("DeletePatient")]
        public async Task<IActionResult> DeletePatient(string patientId)
        {
            var result = await _patientService.DeletePatient(patientId);
            return Ok(result);
        }
    }
}