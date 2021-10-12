using ProgrammingClubProject.Models;
using ProgrammingClubProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammingClubProject.Controllers
{
    public class CodeSnippetsController : Controller
    {

        private CodeSnippetRepository codeSnippetRepository = new CodeSnippetRepository();
        // GET: CodeSnippets
        public ActionResult Index()
        { 
            List<CodeSnippetModel> codeSnippets = codeSnippetRepository.GetAllCodeSnippets();
            return View("Index", codeSnippets);
        }

        // GET: CodeSnippets/Details/5
        public ActionResult Details(Guid id)
        {
            CodeSnippetModel codeSnippetModel = codeSnippetRepository.GetCodeSnippetById(id);
            return View("Details", codeSnippetModel);
        }

        // GET: CodeSnippets/Create
        public ActionResult Create()
        {
            return View("CreateCodeSnippet");
        }

        // POST: CodeSnippets/Create
        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
                UpdateModel(codeSnippetModel);
                codeSnippetRepository.InsertCodeSnippet(codeSnippetModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateCodeSnippet");
            }
        }

        // GET: CodeSnippets/Edit/5
        public ActionResult Edit(Guid id)
        {
            CodeSnippetModel codeSnippetModel = codeSnippetRepository.GetCodeSnippetById(id);
            return View("EditCodeSnippet", codeSnippetModel);
        }

        // POST: CodeSnippets/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
                UpdateModel(codeSnippetModel);
                codeSnippetRepository.UpdateCodeSnippet(codeSnippetModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditCodeSnippet");
            }
        }

        // GET: CodeSnippets/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            CodeSnippetModel codeSnippetModel = codeSnippetRepository.GetCodeSnippetById(id);
            return View("Delete", codeSnippetModel);
        }

        // POST: CodeSnippets/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                codeSnippetRepository.DeleteCodeSnippet(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
