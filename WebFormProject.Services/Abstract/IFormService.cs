using WebFromProject.Entities.Entities;

namespace WebFormProject.Services.Abstract;

public interface IFormService
{
    Task<IEnumerable<Form>> GetAllFormsAsync(string search);
    Task<Form> GetFormByIdAsync(int Id);
    Task CreateFormAsync(Form newForm);
}
