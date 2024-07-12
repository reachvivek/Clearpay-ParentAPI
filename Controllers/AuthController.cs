using Microsoft.AspNetCore.Mvc;
using PaymentAdvisoryPortalParentAPI.Dtos.ForgotPasswordDtos;
using PaymentAdvisoryPortalParentAPI.Dtos.LoginDtos;
using PaymentAdvisoryPortalParentAPI.Utility;

namespace PaymentAdvisoryPortalParentAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly APIRequest _request;
    private readonly string _baseurl;
    public AuthController(IConfiguration config) 
    {
        _request = new APIRequest(config);
        _baseurl = config["API:BaseURL"]!;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto login)
    {
        string url = _baseurl + "/Auth/Login";
        var response = await _request.CallPostEndpoint(url, login);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }
        return Ok(response.Data);
    }

    [HttpPost("SendLoginOTP")]
    public async Task<IActionResult> SendLoginOTP(LoginOtpDto credentials) { 
        string url = _baseurl + "/Auth/SendLoginOTP";
        var response = await _request.CallPostEndpoint(url, credentials);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }
        return Ok(response.Data);
    }

    [HttpPost("SendForgotPasswordOTP")]
    public async Task<IActionResult> SendForgotPasswordOTP(ForgotPasswordOtpDto credentials)
    {
        string url = _baseurl + "/Auth/SendForgotPasswordOTP";
        var response = await _request.CallPostEndpoint(url, credentials);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }
        return Ok(response.Data);
    }

    [HttpPost("VerifyForgotPasswordOTP")]
    public async Task<IActionResult> VerifyForgotPasswordOTP(ForgotPasswordDto forgotPasswordRequest)
    {
        string url = _baseurl + "/Auth/VerifyForgotPasswordOTP";
        var response = await _request.CallPostEndpoint(url, forgotPasswordRequest);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }
        return Ok(response.Data);
    }

    [HttpGet("RefreshToken")]
    public async Task<IActionResult> RefreshToken()
    {
        string url = _baseurl + "/Auth/RefreshToken";
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
        return Ok(response.Data);
    }

    [HttpPost("SetNewPassword")]
    public async Task<IActionResult> SetNewPassword(NewPasswordDto credentials)
    {
        string url = _baseurl + "/Auth/SetNewPassword";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallPostEndpointWithToken(url, credentials, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }
        return Ok(response.Data);
    }


}
