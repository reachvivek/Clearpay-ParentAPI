using Microsoft.AspNetCore.Mvc;
using PaymentAdvisoryPortalParentAPI.Dtos;
using PaymentAdvisoryPortalParentAPI.Utility;

namespace PaymentAdvisoryPortalParentAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FileUploadController : ControllerBase
{
    private readonly APIRequest _request;
    private readonly string _baseurl;
    public FileUploadController(IConfiguration config)
    {
        _request = new APIRequest(config);
        _baseurl = config["API:BaseURL"]!;
    }

    [HttpPost("UploadFiles")]
    public async Task<IActionResult> UploadFiles([FromForm] FilesToUpload request)
    {
        string url = _baseurl + "/FileUpload/UploadFiles";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }
        var response = await _request.CallPostEndpointWithFiles<dynamic>(url, request, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }
        return Ok(response.Data);
    }

    [HttpPost("DownloadFile")]
    public async Task<IActionResult> DownloadFile([FromBody] FileDownload request)
    {
        string url = _baseurl + "/FileUpload/DownloadFile";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }
        var response = await _request.CallPostEndpointWithToken(url, request, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }
        return Ok(response.Data);
    }
}