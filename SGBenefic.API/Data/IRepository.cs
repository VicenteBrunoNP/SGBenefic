using SGBenefic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGBenefic.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T:class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //Alunos
        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Aluno[] GetAllAlunosByDisciplinaId(int disciplinaID, bool includeProfessor = false);
        Aluno GetAllAlunoById(int alunoId, bool includeProfessor = false);


        //Professor
        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaID, bool includeAlunos = false);
        Professor GetAllProfessorById(int professorId, bool includeAlunos = false);



    }
}
