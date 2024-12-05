using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using OE.Module.SigZag.Repository;
using Oqtane.Controllers;
using System.Net;
using System.Threading.Tasks;
using System;

namespace OE.Module.SigZag.Controllers;

[Route(ControllerRoutes.ApiRoute)]
public class SigZagController : ModuleControllerBase
{
    private readonly SigZagRepository _SigZagRepository;

    public SigZagController(SigZagRepository SigZagRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
    {
        _SigZagRepository = SigZagRepository;
    }

    // GET: api/<controller>?moduleid=x
    [HttpGet]
    [Authorize(Roles = RoleNames.Registered)]
    public async Task<ActionResult<IEnumerable<Models.SigZag>>> Get(){
        try{
            var data = _SigZagRepository.GetSigZags();
            return Ok(data);
        }
        catch(Exception ex){
            var errorMessage = $"Repository Error Get Attempt SigZag";
            _logger.Log(LogLevel.Error, this, LogFunction.Read, errorMessage);
            return StatusCode(500);
        }
    }

    // GET api/<controller>/5
    [HttpGet("{id}")]
    [Authorize(Roles = RoleNames.Registered)]
    public async Task<ActionResult<Models.SigZag>> Get(int id)
    {
        try {
            var data = _SigZagRepository.GetSigZag(id);
            return Ok(data);
        }
        catch (Exception ex)       { 
            _logger.Log(LogLevel.Error, this, LogFunction.Read, "Failed SigZag Get Attempt {id}", id);
            return StatusCode(500);
        }
    }

    // POST api/<controller>
    [HttpPost]
    [Authorize(Roles = RoleNames.Registered)]
    public async Task<ActionResult<Models.SigZag>> Post([FromBody] Models.SigZag SigZag)
    {
        if (ModelState.IsValid)
        {
            try{
                SigZag = _SigZagRepository.AddSigZag(SigZag);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "SigZag Added {SigZag}", SigZag);
            }
            catch (Exception ex) {
                _logger.Log(LogLevel.Error, this, LogFunction.Read, "Failed SigZag Add Attempt {SigZag} Message {Message} ", SigZag,ex.Message);
                return StatusCode(500);
            }
        }
        else
        {
            _logger.Log(LogLevel.Error, this, LogFunction.Create, "Invaid SigZag Post Attempt {SigZag}", SigZag);
            return BadRequest();
        }
        return Ok(SigZag);
    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    [Authorize(Roles = RoleNames.Registered)]
    public async Task<ActionResult<Models.SigZag>> Put(int id, [FromBody] Models.SigZag SigZag)
    {
        if (ModelState.IsValid && _SigZagRepository.GetSigZag(SigZag.SigZagId, false) != null)
        {
            SigZag = _SigZagRepository.UpdateSigZag(SigZag);
            _logger.Log(LogLevel.Information, this, LogFunction.Update, "SigZag Updated {SigZag}", SigZag);
            return Ok(SigZag);
        }
        else
        {
            _logger.Log(LogLevel.Error, this, LogFunction.Update, "Unauthorized SigZag Put Attempt {SigZag}", SigZag);
            return BadRequest();
        }
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    [Authorize(Roles = RoleNames.Registered)]
    public async Task<ActionResult> Delete(int id)
    {
        var data = _SigZagRepository.GetSigZag(id);
        if (data is null)
        {
            _logger.Log(LogLevel.Error, this, LogFunction.Delete, "Failed SigZag Delete Attempt {SigZagId}", id);
            return NotFound();
        }

        _SigZagRepository.DeleteSigZag(id);
        _logger.Log(LogLevel.Information, this, LogFunction.Delete, "SigZag Deleted {SigZagId}", id);
        return Ok();
    
    }
}