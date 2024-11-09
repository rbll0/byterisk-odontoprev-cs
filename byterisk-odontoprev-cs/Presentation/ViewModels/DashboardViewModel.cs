using byterisk_odontoprev_cs.Domain.Entities;

namespace byterisk_odontoprev_cs.Presentation.ViewModels;

public class DashboardViewModel
{
    public int TotalPreventions { get; set; }
    public int TotalInterventions { get; set; }
    public decimal TotalSinisterReduction { get; set; }
    public List<MessageViewModel> RecentMessages { get; set; } = new List<MessageViewModel>();
    
    public List<BeneficiarioEntity> Beneficiarios { get; set; } = new List<BeneficiarioEntity>();

}
