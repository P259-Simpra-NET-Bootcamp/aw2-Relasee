using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using SimpraOdev.UnitOfWork;
using SimpraOdev.Models;
using SimpraOdev.Validators;

namespace SimpraOdev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var staffList = _unitOfWork.StaffRepository.GetAll();
            return Ok(staffList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var staff = _unitOfWork.StaffRepository.GetById(id);
            if (staff == null)
                return NotFound();

            return Ok(staff);
        }

        [HttpPost]
        public IActionResult Create(Staff staff)
        {
            // Model validation using FluentValidation
            var validator = new StaffValidator();
            var validationResult = validator.Validate(staff);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            // Check if email is unique
            var existingStaff = _unitOfWork.StaffRepository.GetByEmail(staff.Email);
            if (existingStaff != null)
                return Conflict("Email already exists");

            staff.CreatedAt = DateTime.Now;
            _unitOfWork.StaffRepository.Add(staff);
            _unitOfWork.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = staff.Id }, staff);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Staff staff)
        {
            // Model validation using FluentValidation
            var validator = new StaffValidator();
            var validationResult = validator.Validate(staff);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var existingStaff = _unitOfWork.StaffRepository.GetById(id);
            if (existingStaff == null)
                return NotFound();

            // Check if email is unique
            if (existingStaff.Email != staff.Email)
            {
                var duplicateStaff = _unitOfWork.StaffRepository.GetByEmail(staff.Email);
                if (duplicateStaff != null)
                    return Conflict("Email already exists");
            }

            existingStaff.FirstName = staff.FirstName;
            existingStaff.LastName = staff.LastName;
            existingStaff.Email = staff.Email;
            existingStaff.Phone = staff.Phone;
            existingStaff.DateOfBirth = staff.DateOfBirth;
            existingStaff.AddressLine1 = staff.AddressLine1;
            existingStaff.City = staff.City;
            existingStaff.Country = staff.Country;
            existingStaff.Province = staff.Province;

            _unitOfWork.StaffRepository.Update(existingStaff);
            _unitOfWork.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingStaff = _unitOfWork.StaffRepository.GetById(id);
            if (existingStaff == null)
                return NotFound();

            _unitOfWork.StaffRepository.Remove(existingStaff);
            _unitOfWork.SaveChanges();

            return NoContent();
        }

        [HttpGet("filter")]
        public IActionResult FilterByQueryParameters(string city, string country)
        {
            var query = _unitOfWork.StaffRepository.GetAll();

            if (!string.IsNullOrEmpty(city))
                query = query.Where(s => s.City == city);

            if (!string.IsNullOrEmpty(country))
                query = query.Where(s => s.Country == country);

            var filteredStaff = query.ToList();
            return Ok(filteredStaff);
        }
    }
}