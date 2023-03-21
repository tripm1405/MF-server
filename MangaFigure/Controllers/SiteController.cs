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
        var authors = await _siteRepository.PostSignInByCustomerAsync(customer);
        return Ok(authors);
    }
    [HttpPost("customer/sign-up")]
    public async Task<IActionResult> PostSignUpByCustomerAsync([FromBody] CustomerDto customer)
    {
        var authors = await _siteRepository.PostSignUpByCustomerAsync(customer);
        return Ok(authors);
    }

    [HttpPost("employee/sign-in")]
    public async Task<IActionResult> PostSignInByEmployeeAsync([FromBody] Employee employee)
    {
        var authors = await _siteRepository.PostSignInByEmployeeAsync(employee);
        return Ok(authors);
    }

    [HttpGet("header/list")]
    public async Task<IActionResult> GetHeader()
    {
        var authors = await _siteRepository.GetHeaderAsync();
        return Ok(authors);
    }
    [HttpPost("header/create")]
    public async Task<IActionResult> AddNewHeaderAsync([FromBody] HeaderDto headerModel)
    {
        var authors = await _siteRepository.AddHeaderAsync(headerModel);
        return Ok(authors);
    }

    [HttpPut("header/update/{id}")]
    public async Task<IActionResult> UpdateHeaderAsync(int id, [FromBody] HeaderDto headerModel)
    {
        var authors = await _siteRepository.UpdateHeaderAsync(id, headerModel);
        return Ok(authors);
    }

    [HttpDelete("header/remove/{id}")]
    public async Task<IActionResult> RemoveHeaderAsync(int id)
    {
        var authors = await _siteRepository.RemoveHeaderAsync(id);
        return Ok(authors);
    }

    [HttpGet("slideShow/list")]
    public async Task<IActionResult> GetSlideShow()
    {
        var authors = await _siteRepository.GetSlideShowAsync();
        return Ok(authors);
    }

    [HttpPost("slideShow/create")]
    public async Task<IActionResult> AddNewSlideShowAsync([FromBody] SlideShowDto slideShowModel)
    {
        var authors = await _siteRepository.AddSlideShowAsync(slideShowModel);
        return Ok(authors);
    }

    [HttpPut("slideShow/update/{id}")]
    public async Task<IActionResult> UpdateSlideShowAsync(int id, [FromBody] SlideShowDto slideShowModel)
    {
        var authors = await _siteRepository.UpdateSlideShowAsync(id, slideShowModel);
        return Ok(authors);
    }

    [HttpDelete("slideShow/remove/{id}")]
    public async Task<IActionResult> RemoveSlideShowAsync(int id)
    {
        var authors = await _siteRepository.RemoveSlideShowAsync(id);
        return Ok(authors);
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
        var authors = await _siteRepository.UpdateCatalogAsync(id, catalogModel);
        return Ok(authors);
    }

    [HttpDelete("catalog/remove/{id}")]
    public async Task<IActionResult> RemoveCatalogAsync(int id)
    {
        var authors = await _siteRepository.RemoveCatalogAsync(id);
        return Ok(authors);
    }

    [HttpGet("footer/list")]
    public async Task<IActionResult> GetFooter()
    {
        var authors = await _siteRepository.GetFooterWithTypeAsync();
        return Ok(authors);
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
        var authors = await _siteRepository.UpdateFooterAsync(id, footerModel);
        return Ok(authors);
    }

    [HttpDelete("footer/remove/{id}")]
    public async Task<IActionResult> RemoveFooterAsync(int id)
    {
        var authors = await _siteRepository.RemoveFooterAsync(id);
        return Ok(authors);
    }
}