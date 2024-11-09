using byterisk_odontoprev_cs.Domain.Entities;
using byterisk_odontoprev_cs.Infrastructure.Data.AppData;
using byterisk_odontoprev_cs.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace byterisk_odontoprev_cs.Presentation.Controllers;

public class DashboardController : Controller
{
    private readonly ApplicationContext _context;

    public DashboardController(ApplicationContext context)
    {
        _context = context;
    }

    // Exibe a página principal da dashboard com dados agregados
    public async Task<IActionResult> Index()
    {
        var dashboardData = new DashboardViewModel
        {
            TotalPreventions = await _context.Beneficiarios.CountAsync(),
            TotalInterventions = await _context.Sinistros.CountAsync(),
            TotalSinisterReduction = await _context.Sinistros.SumAsync(s => s.ValorSinistro),
            RecentMessages = GetRecentMessages() // Simulação de mensagens recentes
        };
        return View(dashboardData);
    }

    // Método para simular a obtenção de mensagens recentes
    private List<MessageViewModel> GetRecentMessages()
    {
        return new List<MessageViewModel>
        {
            new MessageViewModel { SenderName = "João", TimeElapsed = "2 horas atrás", Subject = "Atualização de plano" },
            new MessageViewModel { SenderName = "Maria", TimeElapsed = "1 dia atrás", Subject = "Consulta agendada" }
        };
    }

    // Listagem de todos os beneficiários (Read)
    public async Task<IActionResult> GetAllBeneficiarios()
    {
        var beneficiarios = await _context.Beneficiarios.ToListAsync();
        return View(beneficiarios);
    }

    // Exibe o formulário para criação de beneficiário (Create)
    public IActionResult CreateBeneficiarioForm()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateBeneficiario(BeneficiarioEntity beneficiario)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Beneficiarios.Add(beneficiario);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Beneficiário criado com sucesso!";
                return RedirectToAction(nameof(GetAllBeneficiarios));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Erro ao criar beneficiário: " + ex.Message);
            }
        }
        return View("CreateBeneficiarioForm", beneficiario);
    }

    // Exibe o formulário de edição de beneficiário (Update)
    public async Task<IActionResult> EditBeneficiarioForm(int? id)
    {
        if (id == null) return NotFound();

        var beneficiario = await _context.Beneficiarios.FindAsync(id);
        if (beneficiario == null) return NotFound();

        return View(beneficiario);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditBeneficiario(int id, BeneficiarioEntity beneficiario)
    {
        if (id != beneficiario.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(beneficiario);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Beneficiário atualizado com sucesso!";
                return RedirectToAction(nameof(GetAllBeneficiarios));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Beneficiarios.Any(e => e.Id == id))
                    return NotFound();
                throw;
            }
        }
        return View("EditBeneficiarioForm", beneficiario);
    }

    // Exibe o formulário de exclusão de beneficiário (Delete)
    public async Task<IActionResult> DeleteBeneficiarioForm(int? id)
    {
        if (id == null) return NotFound();

        var beneficiario = await _context.Beneficiarios.FirstOrDefaultAsync(m => m.Id == id);
        if (beneficiario == null) return NotFound();

        return View(beneficiario);
    }

    [HttpPost, ActionName("DeleteBeneficiario")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var beneficiario = await _context.Beneficiarios.FindAsync(id);
        if (beneficiario != null)
        {
            _context.Beneficiarios.Remove(beneficiario);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Beneficiário excluído com sucesso!";
        }
        else
        {
            TempData["ErrorMessage"] = "Erro ao excluir beneficiário.";
        }
        return RedirectToAction(nameof(GetAllBeneficiarios));
    }
}
