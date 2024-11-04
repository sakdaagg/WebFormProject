using WebFromProject.Entities.Entities;

namespace WebFormProject.DAL.Abstract;

public interface IFormRepository
{
    Task<IEnumerable<Form>> GetAllFormsAsync(string search);
    Task<Form> GetFormByIdAsync(int Id);
    Task AddFormAsync(Form newForm);
}
