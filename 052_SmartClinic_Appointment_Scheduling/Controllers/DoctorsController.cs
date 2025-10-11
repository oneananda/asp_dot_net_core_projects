using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartClinic.DTOs;
using SmartClinic.Models;
using SmartClinic.Services;

namespace SmartClinic.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorsController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet]
    [AllowAnonymous]
    public ActionResult<IEnumerable<Doctor>> GetAll() => Ok(_doctorService.GetAll());

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public ActionResult<Doctor> GetById(Guid id)
    {
        var doctor = _doctorService.GetById(id);
        return doctor is not null ? Ok(doctor) : NotFound();
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public ActionResult<Doctor> Create([FromBody] CreateDoctorRequest request)
    {
        var result = _doctorService.Create(request);
        if (!result.Success)
        {
            return BadRequest(result.ErrorMessage);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Value!.Id }, result.Value);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Administrator")]
    public ActionResult<Doctor> Update(Guid id, [FromBody] UpdateDoctorRequest request)
    {
        var result = _doctorService.Update(id, request);
        if (!result.Success)
        {
            return result.ErrorMessage == "Doctor not found." ? NotFound(result.ErrorMessage) : BadRequest(result.ErrorMessage);
        }

        return Ok(result.Value);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Administrator")]
    public IActionResult Delete(Guid id)
    {
        return _doctorService.Delete(id) ? NoContent() : NotFound();
    }
}
