using Nyous.noSql.Domains;
using System.Collections.Generic;

namespace Nyous.noSql.Interfaces.Repositories {
    public interface IEventoRepository{
        List<EventoDomain> Listar();
        EventoDomain BuscarPorId(string id);
        void Adicionar(EventoDomain evento);
        void Atualizar(string id, EventoDomain evento);
        void Remover(string id);
    }
}
