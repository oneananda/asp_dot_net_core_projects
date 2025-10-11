using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartClinic.DTOs;
using SmartClinic.Models;
using SmartClinic.Services;

namespace SmartClinic.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientsController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    [Authorize(Roles = "Administrator,Doctor")]
    public ActionResult<IEnumerable<Patient>> GetAll() => Ok(_patientService.GetAll());

    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Administrator,Doctor,Patient")]
    public ActionResult<Patient> GetById(Guid id)
    {
        var patient = _patientService.GetById(id);
        return patient is not null ? Ok(patient) : NotFound();
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public ActionResult<Patient> Create([FromBody] CreatePatientRequest request)
    {
        var result = _patientService.Create(request);
        if (!result.Success)
        {
            return BadRequest(result.ErrorMessage);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Value!.Id }, result.Value);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Administrator,Patient")]
    public ActionResult<Patient> Update(Guid id, [FromBody] UpdatePatientRequest request)
    {
        var result = _patientService.Update(id, request);
        if (!result.Success)
        {
            return result.ErrorMessage == "Patient not found." ? NotFound(result.ErrorMessage) : BadRequest(result.ErrorMessage);
        }

        return Ok(result.Value);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Administrator")]
    public IActionResult Delete(Guid id)
    {
        return _patientService.Delete(id) ? NoContent() : NotFound();
    }
}
