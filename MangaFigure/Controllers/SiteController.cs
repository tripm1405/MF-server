using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SiteController : ControllerBase
{
    private readonly SiteRepository _siteRepository;

    public SiteController(SiteRepository siteRepository)
    {
        _siteRepository = siteRepository;
    }

    [HttpPost("customer/sign-in")]
    public async Task<IActionResult> PostSignInByCustomerAsync([FromBody] Customer customer)
    {
        var data = await _siteRepository.PostSignInByCustomerAsync(customer);
        return Ok(data);
    }
    [HttpPost("customer/sign-up")]
    public async Task<IActionResult> PostSignUpByCustomerAsync([FromBody] CustomerDto customer)
    {
        var data = await _siteRepository.PostSignUpByCustomerAsync(customer);
        return Ok(data);
    }

    [HttpPost("employee/sign-in")]
    public async Task<IActionResult> PostSignInByEmployeeAsync([FromBody] Employee employee)
    {
        var data = await _siteRepository.PostSignInByEmployeeAsync(employee);
        return Ok(data);
    }

    [HttpGet("header/list")]
    public async Task<IActionResult> GetHeader()
    {
        var data = await _siteRepository.GetHeaderAsync();
        return Ok(data);
    }

    [HttpPost("header")]
    public async Task<IActionResult> GetHeaderWithBodyAsync([FromBody] HeaderDto body)
    {
        var data = await _siteRepository.GetHeaderWithBodyAsync(body);
        return Ok(data);
    }

    [HttpPost("header/create")]
    public async Task<IActionResult> AddNewHeaderAsync([FromBody] HeaderDto headerModel)
    {
        var data = await _siteRepository.AddHeaderAsync(headerModel);
        return Ok(data);
    }

    [HttpPut("header/update/{id}")]
    public async Task<IActionResult> UpdateHeaderAsync(int id, [FromBody] HeaderDto headerModel)
    {
        var data = await _siteRepository.UpdateHeaderAsync(id, headerModel);
        return Ok(data);
    }

    [HttpDelete("header/remove/{id}")]
    public async Task<IActionResult> RemoveHeaderAsync(int id)
    {
        var data = await _siteRepository.RemoveHeaderAsync(id);
        return Ok(data);
    }

    [HttpGet("slideShow/list")]
    public async Task<IActionResult> GetSlideShow()
    {
        var data = await _siteRepository.GetSlideShowAsync();
        return Ok(data);
    }

    [HttpPost("slideShow/create")]
    public async Task<IActionResult> AddNewSlideShowAsync([FromBody] SlideShowDto slideShowModel)
    {
        var data = await _siteRepository.AddSlideShowAsync(slideShowModel);
        return Ok(data);
    }

    [HttpPut("slideShow/update/{id}")]
    public async Task<IActionResult> UpdateSlideShowAsync(int id, [FromBody] SlideShowDto slideShowModel)
    {
        var data = await _siteRepository.UpdateSlideShowAsync(id, slideShowModel);
        return Ok(data);
    }

    [HttpDelete("slideShow/remove/{id}")]
    public async Task<IActionResult> RemoveSlideShowAsync(int id)
    {
        var data = await _siteRepository.RemoveSlideShowAsync(id);
        return Ok(data);
    }

    [HttpGet("catalog/list")]
    public async Task<IActionResult> GetCatalog()
    {
        var catalog = await _siteRepository.GetCatalogAsync();
        return Ok(catalog);
    }

    [HttpPost("catalog/list")]
    public async Task<IActionResult> GetCatalogWithBody([FromBody] CatalogDto body)
    {
        var catalog = await _siteRepository.GetCatalogWithBodyAsync(body);
        return Ok(catalog);
    }

    [HttpPost("catalog/create")]
    public async Task<IActionResult> AddNewCatalogAsync([FromBody] CatalogDto catalogModel)
    {
        var newCatalog = await _siteRepository.AddCatalogAsync(catalogModel);
        return Ok(newCatalog);
    }

    [HttpPut("catalog/update/{id}")]
    public async Task<IActionResult> UpdateCatalogAsync(int id, [FromBody] CatalogDto catalogModel)
    {
        var data = await _siteRepository.UpdateCatalogAsync(id, catalogModel);
        return Ok(data);
    }

    [HttpDelete("catalog/remove/{id}")]
    public async Task<IActionResult> RemoveCatalogAsync(int id)
    {
        var data = await _siteRepository.RemoveCatalogAsync(id);
        return Ok(data);
    }

    [HttpGet("footer/list")]
    public async Task<IActionResult> GetFooter()
    {
        var data = await _siteRepository.GetFooterWithTypeAsync();
        return Ok(data);
    }

    [HttpPost("footer/create")]
    public async Task<IActionResult> AddNewFooterAsync([FromBody] FooterDto footerModel)
    {
        var newFooter = await _siteRepository.AddFooterAsync(footerModel);
        return Ok(newFooter);
    }

    [HttpPut("footer/update/{id}")]
    public async Task<IActionResult> UpdateFooterAsync(int id, [FromBody] FooterDto footerModel)
    {
        var data = await _siteRepository.UpdateFooterAsync(id, footerModel);
        return Ok(data);
    }

    [HttpDelete("footer/remove/{id}")]
    public async Task<IActionResult> RemoveFooterAsync(int id)
    {
        var data = await _siteRepository.RemoveFooterAsync(id);
        return Ok(data);
    }

    [HttpGet("logo")]
    public async Task<IActionResult> GetLogoAsync()
    {
        var data = await _siteRepository.GetLogoAsync();
        return Ok(data);
    }

    [HttpPost("header/description")]
    public async Task<IActionResult> GetLogoAsync([FromBody] Header body)
    {
        var data = await _siteRepository.UpdateHeaderDescription(body);
        return Ok(data);
    }
}