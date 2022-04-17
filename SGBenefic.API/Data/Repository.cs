using Microsoft.EntityFrameworkCore;
using SGBenefic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGBenefic.API.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)            
                query = query.Include(a => a.AlunoDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaID, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
                query = query.Include(a => a.AlunoDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);


            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(a => a.AlunoDisciplinas.Any(ad => ad.DisciplinaId == disciplinaID));

            return query.ToArray();
        }

        public Aluno GetAllAlunoById(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
                query = query.Include(a => a.AlunoDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);


            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(a => a.Id == alunoId);

            return query.FirstOrDefault();
        }

        public Professor[] GetAllProfessores(bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professors;

            if (includeAlunos)
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(d => d.AlunoDisciplinas)
                             .ThenInclude(ad => ad.Aluno);


            query = query.AsNoTracking()
                         .OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaID, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professors;

            if (includeAlunos)
                query = query.Include(a => a.Disciplinas)
                             .ThenInclude(d => d.AlunoDisciplinas)
                             .ThenInclude(ad => ad.Aluno);


            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(a => a.Disciplinas.Any(
                             d => d.AlunoDisciplinas.Any(ad => ad.DisciplinaId == disciplinaID)
                          ));

            return query.ToArray();
        }

        public Professor GetAllProfessorById(int professorId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professors;

            if (includeAlunos)
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(ad => ad.AlunoDisciplinas)
                             .ThenInclude(d => d.Aluno);

            query = query.AsNoTracking()
                         .OrderBy(p => p.Id)
                         .Where(p => p.Id == professorId);

            return query.FirstOrDefault();
        }
    }
}
