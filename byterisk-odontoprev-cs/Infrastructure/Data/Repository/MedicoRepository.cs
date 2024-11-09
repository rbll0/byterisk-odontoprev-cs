using byterisk_odontoprev_cs.Domain.Entities;
using byterisk_odontoprev_cs.Domain.Interfaces;
using byterisk_odontoprev_cs.Infrastructure.Data.AppData;

namespace byterisk_odontoprev_cs.Infrastructure.Data.Repository;

public class MedicoRepository : IMedicoRepository
{
    private readonly ApplicationContext _context;

        public MedicoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public MedicoEntity? DeletarDados(int id)
        {
            try
            {
                var medico = _context.Medicos.Find(id);

                if (medico is not null)
                {
                    _context.Medicos.Remove(medico);
                    _context.SaveChanges();
                    return medico;
                }

                throw new Exception("Não foi possível localizar o médico");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public MedicoEntity? EditarDados(MedicoEntity entity)
        {
            try
            {
                var medico = _context.Medicos.Find(entity.Id);

                if (medico is not null)
                {
                    medico.Nome = entity.Nome;
                    medico.Especialidade = entity.Especialidade;
                    medico.Crm = entity.Crm;

                    _context.Update(medico);
                    _context.SaveChanges();

                    return medico;
                }

                throw new Exception("Não foi possível localizar o médico");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public MedicoEntity? ObterPorId(int id)
        {
            return _context.Medicos.Find(id);
        }

        public IEnumerable<MedicoEntity>? ObterTodos()
        {
            var medicos = _context.Medicos.ToList();

            if (medicos.Any())
                return medicos;

            return null;
        }

        public MedicoEntity? SalvarDados(MedicoEntity entity)
        {
            try
            {
                _context.Medicos.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar o médico");
            }
        }
}
