using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PaymentAdvisoryPortalParentAPI.Dtos.BillDtos;
using PaymentAdvisoryPortalParentAPI.Utility;

namespace PaymentAdvisoryPortalParentAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly APIRequest _request;
    private readonly string _baseurl;
    public InvoiceController(IConfiguration config)
    {
        _request = new APIRequest(config);
        _baseurl = config["API:BaseURL"]!;
    }

    [HttpGet("LoadFilters")]
    public async Task<IActionResult> LoadFilters()
    {
        string url = _baseurl+"/Invoice/LoadFilters";
        
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallGetEndpointWithTokenAndJsonResult<FiltersForBillsDto>(url, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        return Ok(response.Data);
    }

    [HttpGet("GetBills")]
    public async Task<IActionResult> GetBills(
        [FromQuery] string? bank = null,
        [FromQuery] string? invoiceYear = null,
        [FromQuery] string? invoiceMonth = null,
        [FromQuery] string? state = null,
        [FromQuery] string? lho = null,
        [FromQuery] string? serviceType = null,
        [FromQuery] string? glCode = null)
    {
        // Constructing the URL
        var uriBuilder = new UriBuilder(_baseurl + "/Invoice/GetBills");
        var query = new QueryBuilder();

        // Append query parameters
        if (!string.IsNullOrEmpty(bank))
            query.Add("bank", bank);
        if (!string.IsNullOrEmpty(invoiceYear))
            query.Add("invoiceYear", invoiceYear);
        if (!string.IsNullOrEmpty(invoiceMonth))
            query.Add("invoiceMonth", invoiceMonth);
        if (!string.IsNullOrEmpty(state))
            query.Add("state", state);
        if (!string.IsNullOrEmpty(lho))
            query.Add("lho", lho);
        if (!string.IsNullOrEmpty(serviceType))
            query.Add("serviceType", serviceType);
        if (!string.IsNullOrEmpty(glCode))
            query.Add("glCode", glCode);

        uriBuilder.Query = query.ToQueryString().ToString();

        string url = uriBuilder.ToString();

        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallGetEndpointWithTokenAndJsonResult<DashboardBillsResponseDto>(url, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        return Ok(response.Data);
    }

    [HttpGet("GetReports")]
    public async Task<IActionResult> GetReports()
    {
        string url = _baseurl + "/Invoice/GetReports";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallGetEndpointWithTokenAndResult<BillsForReportDto>(url, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        return Ok(response.Data);
    }

    [HttpGet("GetInvoiceDetails/{billId}")]
    public async Task<IActionResult> GetInvoiceDetails(int billId)
    {
        string url = _baseurl + $"/Invoice/GetInvoiceDetails/{billId}";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallGetEndpointWithTokenAndJsonResult<InvoiceDetailsDto>(url, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        return Ok(response.Data);
    }

    [HttpPost("UpdateDateOfSubmission")]
    public async Task<IActionResult> UpdateDateOfSubmission([FromBody]  InvoiceDateOfSubmissionDto invoice)
    {
        string url = _baseurl + "/Invoice/UpdateDateOfSubmission";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallPostEndpointWithToken(url, invoice, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        return Ok(response.Data);
    }

    [HttpPost("UpdateInvoiceDetails")]
    public async Task<IActionResult> UpdateInvoiceDetails([FromBody] InvoiceDetailsToUpdateDto invoice)
    {
        string url = _baseurl + "/Invoice/UpdateInvoiceDetails";
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallPostEndpointWithToken(url, invoice, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        return Ok(response.Data);
    }
    
    [HttpGet("GetInvoicePdf")]
    public async Task<IActionResult> GetInvoicePdf([FromQuery] string? invoiceNo = null) {
        string _baseurl = "http://127.0.0.1:5000";

        var uriBuilder = new UriBuilder(_baseurl + "/get_invoice_pdf");
        var query = new QueryBuilder();

        // Append query parameters
        if (!string.IsNullOrEmpty(invoiceNo))
            query.Add("InvoiceNo", invoiceNo);

        uriBuilder.Query = query.ToQueryString().ToString();

        string url = uriBuilder.ToString();
        var headers = new Dictionary<string, string>();
        if (Request.Headers.ContainsKey("Authorization"))
        {
            headers.Add("Authorization", Request.Headers["Authorization"].ToString());
        }

        var response = await _request.CallGetEndpointWithTokenAndJsonResult<InvoiceBase64Dto>(url, headers);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message);
        }

        return Ok(response.Data);
    }
}
