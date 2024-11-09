using byterisk_odontoprev_cs.Domain.Entities;
using byterisk_odontoprev_cs.Domain.Interfaces;
using byterisk_odontoprev_cs.Infrastructure.Data.AppData;

namespace byterisk_odontoprev_cs.Infrastructure.Data.Repository;

public class PlanoRepository : IPlanoRepository
{
    private readonly ApplicationContext _context;

        public PlanoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public PlanoEntity? DeletarDados(int id)
        {
            try
            {
                var plano = _context.Planos.Find(id);

                if (plano is not null)
                {
                    _context.Planos.Remove(plano);
                    _context.SaveChanges();
                    return plano;
                }

                throw new Exception("Não foi possível localizar o plano");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public PlanoEntity? EditarDados(PlanoEntity entity)
        {
            try
            {
                var plano = _context.Planos.Find(entity.Id);

                if (plano is not null)
                {
                    plano.NomePlano = entity.NomePlano;
                    plano.TipoPlano = entity.TipoPlano;
                    plano.ValorMensal = entity.ValorMensal;

                    _context.Update(plano);
                    _context.SaveChanges();

                    return plano;
                }

                throw new Exception("Não foi possível localizar o plano");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public PlanoEntity? ObterPorId(int id)
        {
            return _context.Planos.Find(id);
        }

        public IEnumerable<PlanoEntity>? ObterTodos()
        {
            var planos = _context.Planos.ToList();

            if (planos.Any())
                return planos;

            return null;
        }

        public PlanoEntity? SalvarDados(PlanoEntity entity)
        {
            try
            {
                _context.Planos.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar o plano");
            }
        }
}
