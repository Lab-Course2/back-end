﻿using MindMuse.Application.Contracts.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MindMuse.Application.Contracts.Models.Requests;

namespace MindMuse.AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentSlotController : ControllerBase
    {
        private readonly IAppointmentSlotService _appointmentSlotService;
        private readonly IValidator<AppointmentSlotRequest> _appointmentValidator;
        public AppointmentSlotController(IAppointmentSlotService appointmentSlotService, IValidator<AppointmentSlotRequest> appointmentValidator)
        {
            _appointmentSlotService = appointmentSlotService;
            _appointmentValidator = appointmentValidator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointmentSlot([FromBody] AppointmentSlotRequest appointmentSlotRequest)
        {
            _appointmentValidator.ValidateAndThrow(appointmentSlotRequest);

            var result = await _appointmentSlotService.CreateAppointmentSlot(appointmentSlotRequest);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAppointmentSlots()
        {
            var appointmentSlots = await _appointmentSlotService.GetAllAppointmentSlots();
            return Ok(appointmentSlots);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentSlotById(string id)
        {
            var appointmentSlot = await _appointmentSlotService.GetAppointmentById(id);
            return Ok(appointmentSlot);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointmentSlot(string id, [FromBody] AppointmentSlotRequest appointmentSlotRequest)
        {
            _appointmentValidator.ValidateAndThrow(appointmentSlotRequest);
            var result = await _appointmentSlotService.UpdateAppointmentSlot(id, appointmentSlotRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentSlot(string id)
        {
            var result = await _appointmentSlotService.DeleteAsync(id);
            return Ok(result);
        }
    }
}