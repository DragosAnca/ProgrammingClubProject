using ProgrammingClubProject.Models;
using ProgrammingClubProject.Models.DBObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClubProject.Repositories
{
    public class CodeSnippetRepository
    {

        private ClubMembershipModelsDataContext dbContext;

        public CodeSnippetRepository()
        {
            this.dbContext = new ClubMembershipModelsDataContext();
        }

        public CodeSnippetRepository(ClubMembershipModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void InsertCodeSnippet(CodeSnippetModel codeSnippetModel)
        {
            codeSnippetModel.IDCodeSnippet = Guid.NewGuid();
            dbContext.CodeSnippets.InsertOnSubmit(MapModelToDbObject(codeSnippetModel));
            dbContext.SubmitChanges();
        }

        public List<CodeSnippetModel> GetAllCodeSnippets()
        {
            List<CodeSnippetModel> codeSnippetLists = new List<CodeSnippetModel>();
            foreach (var dbCodeSnippet in dbContext.CodeSnippets)
            {
                codeSnippetLists.Add(MapDbObjectToModel(dbCodeSnippet));
            }
            return codeSnippetLists;
        }

        public void UpdateCodeSnippet(CodeSnippetModel codeSnippetModel)
        {
            CodeSnippet existingCodeSnippet = dbContext.CodeSnippets.FirstOrDefault(x => x.IDCodeSnippet == codeSnippetModel.IDCodeSnippet);
            if (existingCodeSnippet != null)
            {
                existingCodeSnippet.IDCodeSnippet = codeSnippetModel.IDCodeSnippet;
                existingCodeSnippet.Title = codeSnippetModel.Title;
                existingCodeSnippet.IDMember = codeSnippetModel.IDMember;
                existingCodeSnippet.ContentCode = codeSnippetModel.ContentCode;
                existingCodeSnippet.Revision = codeSnippetModel.Revision;
                dbContext.SubmitChanges();

            }
        }

        public CodeSnippetModel GetCodeSnippetById(Guid id)
        {
            return MapDbObjectToModel(dbContext.CodeSnippets.FirstOrDefault(x => x.IDCodeSnippet == id));
        }

        public void DeleteCodeSnippet(Guid id)
        {
            CodeSnippet codeSnippetToBeDeleted = dbContext.CodeSnippets.FirstOrDefault(x => x.IDCodeSnippet == id);
            if (codeSnippetToBeDeleted != null)
            {
                dbContext.CodeSnippets.DeleteOnSubmit(codeSnippetToBeDeleted);
                dbContext.SubmitChanges();
            }
        }
        private CodeSnippetModel MapDbObjectToModel(CodeSnippet codeSnippet)
        {
            CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
            if (codeSnippet != null)
            {
                codeSnippetModel.IDCodeSnippet = codeSnippet.IDCodeSnippet;
                codeSnippetModel.Title = codeSnippet.Title;
                codeSnippetModel.IDMember = codeSnippet.IDMember;
                codeSnippetModel.ContentCode = codeSnippet.ContentCode;
                codeSnippetModel.Revision = codeSnippet.Revision;
                return codeSnippetModel;


            }
            return null;
        }
        private CodeSnippet MapModelToDbObject(CodeSnippetModel codeSnippetModel)
        {
            CodeSnippet dbCodeSnippet = new CodeSnippet();
            if (codeSnippetModel != null)
            {
                dbCodeSnippet.IDCodeSnippet = codeSnippetModel.IDCodeSnippet;
                dbCodeSnippet.Title = codeSnippetModel.Title;
                dbCodeSnippet.IDMember = codeSnippetModel.IDMember;
                dbCodeSnippet.ContentCode = codeSnippetModel.ContentCode;
                dbCodeSnippet.Revision = codeSnippetModel.Revision;
                return dbCodeSnippet;


            }
            return null;
        }

    }
}