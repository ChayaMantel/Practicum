using AutoMapper;
using EmpManage.Core.DTO;
using EmpManage.Core.Entities;
using EmpManage.Core.Services;
using EmpManage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmpManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]   
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        { 
            var list=await _employeeService.GetAllEmployeesAsync();
            var listDTO=_mapper.Map<IEnumerable<EmployeeDTO>>(list);
            return Ok(listDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if(employee == null) {
                return NotFound($"Employee with ID {id} not found.");
            }
            var employeeDTO=_mapper.Map<EmployeeDTO>(employee);
            return Ok(employeeDTO);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Employee>> Post([FromBody] EmployeePostModel employee)
        {
            var EmployeeToAdd=_mapper.Map<Employee>(employee);
            var response= await _employeeService.AddEmployeeAsync(EmployeeToAdd);
            if (response == null)
            {
                return BadRequest("can not add");    
            }
            var employeeDTO=_mapper.Map<EmployeeDTO>(EmployeeToAdd);
            return Ok(employeeDTO); 
            
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Put(int id, [FromBody] EmployeePostModel employee)
        {
            var employeeToUpdate = _mapper.Map<Employee>(employee);
            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(id, employeeToUpdate);

            if (updatedEmployee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            var employeeDTO = _mapper.Map<EmployeeDTO>(updatedEmployee);
            return Ok(employeeDTO);
        }

        [HttpPut("{id}/delete")]
        public async Task<IActionResult> LogicalDelete(int id)
        {
           var employeeDeleted= await _employeeService.LogicalDeleteEmployeeAsync(id);
            if (employeeDeleted==null)
            {
                return NotFound();
            }
           
             return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound($"Employee with ID {id} not found.");
            }
           
        }


    }
}
