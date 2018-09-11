using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppChamados.Models
{
    public class ChamadosRepository : IRepositoryChamados
    {
        private DataContext DataContext;

        public ChamadosRepository(DataContext pDataContext)
        {
            this.DataContext = pDataContext;
        }

        public void Create(Chamados pChamado)
        {
            this.DataContext.Chamado.Add(pChamado);

            this.DataContext.SaveChanges();
        }

        public void Delete(int pId)
        {
            this.DataContext.Chamado.Remove(this.Get(pId));

            this.DataContext.SaveChanges();
        }

        public List<Chamados> Get()
        {
            return this.DataContext.Chamado.OrderBy(it => it.id).ToList();
        }

        public Chamados Get(int? pId)
        {
            if(pId == null)
                return this.Get().FirstOrDefault();

            return this.DataContext.Chamado.ToList().Find(it => it.id == pId);
        }

        public void Update(Chamados pNewChamado)
        {
            Chamados chamado = this.Get(pNewChamado.id);

            chamado.numero = pNewChamado.numero;

            chamado.data = pNewChamado.data;

            chamado.nome = pNewChamado.nome;

            chamado.telefone = pNewChamado.telefone;

            chamado.email = pNewChamado.email;

            chamado.problema = pNewChamado.problema;

            chamado.dataSolucao = pNewChamado.dataSolucao;

            chamado.horaInicio = pNewChamado.horaInicio;

            chamado.horaFim = pNewChamado.horaFim;

            this.DataContext.SaveChanges();
        }
    }
}