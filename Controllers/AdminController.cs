using Microsoft.AspNetCore.Mvc;
using PaymentAdvisoryPortalParentAPI.Dtos.AdminDtos;
using PaymentAdvisoryPortalParentAPI.Models;
using PaymentAdvisoryPortalParentAPI.Utility;

namespace PaymentAdvisoryPortalParentAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    private readonly APIRequest _request;
    private readonly string _baseurl;
    public AdminController(IConfiguration config)
    {
        _request = new APIRequest(config);
        _baseurl = config["API:BaseURL"]!;
    }

    [HttpGet("IsAdmin")]
    public async Task<IActionResult> IsAdmin() {
        string url = _baseurl + "/Admin/IsAdmin";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallGetEndpointWithToken(url, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        if (response.Data is bool isAdmin)
        {
            return Ok(isAdmin);
        }
        else
        {
            return StatusCode(500, "Invalid data received from the child API");
        }
    }

    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        string url = _baseurl + "/Admin/GetUsers";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallGetEndpointWithTokenAndResult<User>(url, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        return Ok(response.Data);
    }

    [HttpGet("GetLhoUsers")]
    public async Task<IActionResult> GetLhoUsers()
    {
        string url = _baseurl + "/Admin/GetUsers";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallGetEndpointWithTokenAndResult<User>(url, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        return Ok(response.Data);
    }

    [HttpPut("EditUser/{UserId}")]
    public async Task<IActionResult> EditUser(int UserId, [FromBody] AdminToEditDto user)
    {
        string url = _baseurl + $"/Admin/EditUser/{UserId.ToString()}";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallPutEndpointWithToken(url, user, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        return Ok(response.Data);
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] AdminToAddDto user)
    {
        string url = _baseurl + "/Admin/CreateUser";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallPostEndpointWithToken(url, user, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        return Ok(response.Data);
    }

    [HttpDelete("DeleteUser/{UserId}")]
    public async Task<IActionResult> DeleteUser(int UserId)
    {
        string url = _baseurl + $"/Admin/DeleteUser/{UserId}";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallDeleteEndpointWithToken(url, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        return Ok(response.Data);
    }

}