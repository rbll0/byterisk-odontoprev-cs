using byterisk_odontoprev_cs.Domain.Entities;
using byterisk_odontoprev_cs.Domain.Interfaces;
using byterisk_odontoprev_cs.Infrastructure.Data.AppData;

namespace byterisk_odontoprev_cs.Infrastructure.Data.Repository;

public class BeneficiarioRepository : IBeneficiarioRepository
{
    private readonly ApplicationContext _context;

    public BeneficiarioRepository(ApplicationContext context)
    {
        _context = context;
    }

    public BeneficiarioEntity? DeletarDados(int id)
    {
        try
        {
            var beneficiario = _context.Beneficiarios.Find(id);

            if (beneficiario is not null)
            {
                _context.Beneficiarios.Remove(beneficiario);
                _context.SaveChanges();
                return beneficiario;
            }

            // Gera exceção para informar que não foi possível localizar o beneficiário
            throw new Exception("Não foi possível localizar o beneficiário");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public BeneficiarioEntity? EditarDados(BeneficiarioEntity entity)
    {
        try
        {
            var beneficiario = _context.Beneficiarios.Find(entity.Id);

            if (beneficiario is not null)
            {
                beneficiario.Nome = entity.Nome;
                beneficiario.DataNascimento = entity.DataNascimento;
                beneficiario.Cpf = entity.Cpf;
                beneficiario.Telefone = entity.Telefone;
                beneficiario.Email = entity.Email;
                beneficiario.Endereco = entity.Endereco;
                beneficiario.Ranking = entity.Ranking;
                beneficiario.PlanoId = entity.PlanoId;

                _context.Update(beneficiario);
                _context.SaveChanges();

                return beneficiario;
            }

            // Gera exceção para informar que não foi possível localizar o beneficiário
            throw new Exception("Não foi possível localizar o beneficiário");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public BeneficiarioEntity? ObterPorId(int id)
    {
        return _context.Beneficiarios.Find(id);
    }

    public IEnumerable<BeneficiarioEntity>? ObterTodos()
    {
        var beneficiarios = _context.Beneficiarios.ToList();

        if (beneficiarios.Any())
            return beneficiarios;

        return null;
    }

    public BeneficiarioEntity? SalvarDados(BeneficiarioEntity entity)
    {
        try
        {
            _context.Beneficiarios.Add(entity);
            _context.SaveChanges();

            return entity;
        }
        catch (Exception)
        {
            throw new Exception("Não foi possível salvar o beneficiário");
        }
    }
}
