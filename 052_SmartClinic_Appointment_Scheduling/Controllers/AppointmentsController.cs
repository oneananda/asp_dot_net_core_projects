using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartClinic.DTOs;
using SmartClinic.Models;
using SmartClinic.Services;

namespace SmartClinic.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public ActionResult<IEnumerable<Appointment>> GetAll() => Ok(_appointmentService.GetAll());

    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Administrator,Doctor,Patient")]
    public ActionResult<Appointment> GetById(Guid id)
    {
        var appointment = _appointmentService.GetById(id);
        return appointment is not null ? Ok(appointment) : NotFound();
    }

    [HttpGet("doctor/{doctorId:guid}")]
    [Authorize(Roles = "Administrator,Doctor")]
    public ActionResult<IEnumerable<Appointment>> GetForDoctor(Guid doctorId) => Ok(_appointmentService.GetForDoctor(doctorId));

    [HttpGet("patient/{patientId:guid}")]
    [Authorize(Roles = "Administrator,Doctor,Patient")]
    public ActionResult<IEnumerable<Appointment>> GetForPatient(Guid patientId) => Ok(_appointmentService.GetForPatient(patientId));

    [HttpPost]
    [Authorize(Roles = "Administrator,Doctor,Patient")]
    public ActionResult<Appointment> Schedule([FromBody] ScheduleAppointmentRequest request)
    {
        var result = _appointmentService.Schedule(request);
        if (!result.Success)
        {
            return BadRequest(result.ErrorMessage);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Value!.Id }, result.Value);
    }

    [HttpPut("{id:guid}/status")]
    [Authorize(Roles = "Administrator,Doctor")]
    public ActionResult<Appointment> UpdateStatus(Guid id, [FromBody] UpdateAppointmentStatusRequest request)
    {
        var result = _appointmentService.UpdateStatus(id, request);
        if (!result.Success)
        {
            return result.ErrorMessage == "Appointment not found." ? NotFound(result.ErrorMessage) : BadRequest(result.ErrorMessage);
        }

        return Ok(result.Value);
    }

    [HttpPost("{id:guid}/cancel")]
    [Authorize(Roles = "Administrator,Doctor,Patient")]
    public ActionResult<Appointment> Cancel(Guid id, [FromQuery] string? reason)
    {
        var result = _appointmentService.Cancel(id, reason);
        if (!result.Success)
        {
            return result.ErrorMessage == "Appointment not found." ? NotFound(result.ErrorMessage) : BadRequest(result.ErrorMessage);
        }

        return Ok(result.Value);
    }
}
