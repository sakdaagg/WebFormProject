using WebFormProject.DAL.Abstract;
using WebFormProject.Services.Abstract;
using WebFromProject.Entities.Entities;

namespace WebFormProject.Services.Concrete;

public class FormService : IFormService
{
    private readonly IFormRepository _formRepository;

    public FormService(IFormRepository formRepository)
    {
        _formRepository = formRepository;
    }

    public async Task CreateFormAsync(Form newForm)
    {
        await _formRepository.AddFormAsync(newForm);
    }

    public async Task<IEnumerable<Form>> GetAllFormsAsync(string search)
    {
        return await _formRepository.GetAllFormsAsync(search);
    }

    public async Task<Form> GetFormByIdAsync(int Id)
    {
        return await _formRepository.GetFormByIdAsync(Id);
    }
}
