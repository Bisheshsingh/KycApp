using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KycApp.Interfaces;
using KycApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KycApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomer([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _customerService.AddCustomer(user);
            return Ok("Customer registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginCustomer([FromBody] Credentials credentials)
        {
            try
            {
                await _customerService.VerifyCredentials(credentials);
                return Ok("Login successful.");
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Invalid credentials.");
            }
        }

        [HttpPost("add-request")]
        public async Task<IActionResult> CreateKycRequest([FromBody] KycRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _customerService.AddKycRequest(request);
            return Ok("KYC request created successfully.");
        }

        [HttpGet("get-all-request")]
        public async Task<IActionResult> GetAllKycRequests(int userId)
        {
            var requests = await _customerService.FetchAllKycRequests(userId);
            return Ok(requests);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditProfile(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedUser = await _customerService.UpdateProfile(id, user);
                return Ok(updatedUser);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("User not found.");
            }
        }
    }
}
