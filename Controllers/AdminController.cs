using System.Threading.Tasks;
using KycApp.Interfaces;
using KycApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KycApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        
        [HttpDelete("delete-request/{id:int}")]
        public async Task<IActionResult> DeleteKycRequest(int id)
        { 
            await _adminService.DeleteKycRequest(id);
            return Ok();
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(Credentials credentials)
        {
            await _adminService.VerifyCredentials(credentials);
            return Ok();
        }
        
        [HttpPut("edit-kyc-request/{id:int}")]
        public async Task<IActionResult> EditKycRequest(int id, KycRequest kycRequest)
        {
            await _adminService.UpdateKycRequest(id, kycRequest);
            return Ok();
        }
        
        [HttpGet("get-kyc-requests-by-user/{id:int}")]
        public async Task<IActionResult> GetKycRequestsByUserId(int id)
        {
            var result = await _adminService.FetchAllKycRequests(id);
            return Ok(result);
        }
        
        [HttpGet("get-all-kyc-requests")]
        public async Task<IActionResult> GetAllKycRequests()
        {
            var result = await _adminService.FetchAllKycRequests();
            return Ok(result);
        }
        
        [HttpPut("edit-profile/{id:int}")]
        public async Task<IActionResult> EditProfile(int id, User user)
        {
            var result = await _adminService.UpdateProfile(id, user);
            return Ok(result);
        }
    }
}