using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotizAPI2.Models;
using NotizAPI2.Services;
using NotizAPI2.Repositories;

namespace NotizAPI2.Controllers;

// API-Controller für die Verwaltung von Notizen.
[ApiController]
[Route("api/[controller]")]
public class NotizController : ControllerBase
{
    private readonly INotizService _service;

    // Initialisiert einen neuen NotizController mit dem gegebenen Service.
    public NotizController(INotizService service)
    {
        _service = service;
    }

    // Ruft alle Notizen ab.
    // <returns>Eine Liste aller Notizen.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Notiz>>> GetNotizen()
    {
        var notizen = await _service.GetAllAsync();
        return Ok(notizen);
    }

    // Ruft eine Notiz basierend auf ihrer ID ab.
    // <returns>Die angeforderte Notiz oder ein 404-Fehler.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Notiz>> GetNotizById(int id)
    {
        var notiz = await _service.GetByIdAsync(id);
        if (notiz == null) return NotFound();
        return Ok(notiz);
    }

    // Erstellt eine neue Notiz.
    // <returns>Die erstellte Notiz mit ihrer ID.</returns>
    [HttpPost]
    public async Task<ActionResult<Notiz>> CreateNotiz([FromBody] Notiz notiz)
    {
        var createdNotiz = await _service.CreateAsync(notiz);
        return CreatedAtAction(nameof(GetNotizById), new { id = createdNotiz.Id }, createdNotiz);
    }

    // Aktualisiert eine bestehende Notiz.
    // <returns>Ein Statuscode für die Aktualisierung.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNotiz(int id, [FromBody] Notiz updatedNotiz)
    {
        if (id != updatedNotiz.Id) return BadRequest();
        await _service.UpdateAsync(updatedNotiz);
        return NoContent();
    }

    // Löscht eine Notiz basierend auf ihrer ID.
    // <returns>Ein Statuscode für den Abschluss der Löschung.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNotiz(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }

}