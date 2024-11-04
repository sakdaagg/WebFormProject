using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebFormProject.Models;
using WebFormProject.Services.Abstract;
using WebFromProject.Entities.Entities;

namespace WebFormProject.Controllers;

[Authorize]
public class FormController : Controller
{
    private readonly IFormService _formService;

    public FormController(IFormService formService)
    {
        _formService = formService;
    }
  
    public async Task<IActionResult> Index(string searchString)
    {
        var forms = await _formService.GetAllFormsAsync(searchString);
        var formViewModels = forms.Select(f => new FormViewModel
        {
            Id = f.Id,
            Name = f.Name,
            Description = f.Description,
            CreatedAt = f.CreatedAt,
            CreatedById = f.CreatedById,
            Fields = f.Fields.Select(k => new FieldViewModel()
            {
                Name = k.Name,
                Required = k.Required,
                DataType = k.DataType
            }).ToList()
        }).ToList();
        return View(formViewModels);
    }

    public async Task<IActionResult> Details(int id)
    {
        var form = await _formService.GetFormByIdAsync(id);
        if (form == null)
        {
            return NotFound();
        }
        var formViewModel = new FormViewModel()
        {
            Id = form.Id,
            Name = form.Name,
            Description = form.Description,
            CreatedAt = form.CreatedAt,
            CreatedById = form.CreatedById,
            Fields = form.Fields.Select(k => new FieldViewModel() 
            {
                Name = k.Name,
                Required = k.Required,
                DataType = k.DataType
            }).ToList()
        };
        return View(formViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(FormViewModel model)
    {
        if (ModelState.IsValid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var form = new Form
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Parse(userId),
                Fields = model.Fields.Select(f => new Field
                {
                    Required = f.Required,
                    Name = f.Name,
                    DataType = f.DataType
                }).ToList()
            };
            await _formService.CreateFormAsync(form);
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
}
