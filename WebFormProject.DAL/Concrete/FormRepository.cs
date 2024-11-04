using Microsoft.EntityFrameworkCore;
using WebFormProject.DAL.Abstract;
using WebFormProject.DAL.DbContexts;
using WebFromProject.Entities.Entities;

namespace WebFormProject.DAL.Concrete;

public class FormRepository : IFormRepository
{
    private readonly WebFormDbContext _dbContext;

    public FormRepository(WebFormDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddFormAsync(Form newForm)
    {
        await _dbContext.Forms.AddAsync(newForm);
    }

    public async Task<IEnumerable<Form>> GetAllFormsAsync(string search)
    {
        if (string.IsNullOrEmpty(search))
            return await _dbContext.Forms.Include(k => k.Fields).ToListAsync();
        else
            return await _dbContext.Forms.Include(k => k.Fields).Where(k => k.Name.Equals(search)).ToListAsync();
    }

    public async Task<Form> GetFormByIdAsync(int Id)
    {
        if (Id == 0)
            return null;
        else
            return await _dbContext.Forms.Include(k => k.Fields)
                .FirstOrDefaultAsync(k => k.Id == Id);
    }
}
