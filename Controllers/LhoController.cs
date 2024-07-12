using Microsoft.AspNetCore.Mvc;
using PaymentAdvisoryPortalParentAPI.Dtos.LhoDtos;
using PaymentAdvisoryPortalParentAPI.Models;
using PaymentAdvisoryPortalParentAPI.Utility;

namespace PaymentAdvisoryPortalParentAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LhoController : ControllerBase
{
    private readonly APIRequest _request;
    private readonly string _baseurl;
    public LhoController(IConfiguration config)
    {
        _request = new APIRequest(config);
        _baseurl = config["API:BaseURL"]!;
    }

    [HttpGet("GetLhos")]
    public async Task<IActionResult> GetLhos()
    {
        string url = _baseurl + "/Lho/GetLhos";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallGetEndpointWithTokenAndResult<LhoToGetDto>(url, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        return Ok(response.Data);
    }

    [HttpGet("GetStates")]
    public async Task<IActionResult> GetStates()
    {
        string url = _baseurl + "/Lho/GetStates";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallGetEndpointWithTokenAndResult<State>(url, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        return Ok(response.Data);
    }

    [HttpPost("CreateLho")]
    public async Task<IActionResult> CreateLho([FromBody] LhoToAddDto lho)
    {
        string url = _baseurl + "/Lho/CreateLho";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallPostEndpointWithToken(url, lho, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        return Ok(response.Data);
    }

    [HttpPut("UpdateLho")]
    public async Task<IActionResult> UpdateLho([FromBody] Lho lho)
    {
        string url = _baseurl + $"/Lho/UpdateLho";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallPutEndpointWithToken(url, lho, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        return Ok(response.Data);
    }

    [HttpDelete("DeleteLho/{LhoID}")]
    public async Task<IActionResult> DeleteLho(int LhoID)
    { 
        string url = _baseurl + $"/Lho/DeleteLho/{LhoID}";
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