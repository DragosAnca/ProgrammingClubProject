using ProgrammingClubProject.Models;
using ProgrammingClubProject.Models.ViewModels;
using ProgrammingClubProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammingClubProject.Controllers
{
    public class MemberController : Controller
    {
        private MemberRepository memberRepository = new MemberRepository();

        // GET: Member
        public ActionResult Index()
        {
            List<MemberModel> members = memberRepository.GetAllMember();

            return View("Index", members);
        }

        // GET: Member/Details/5
        public ActionResult Details(Guid id)
        {           
            MemberCodeSnippetsViewModel viewModel = memberRepository.GetMemberCodeSnippets(id);
            return View("Details",viewModel);
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View("CreateMember");
        }
 
        // POST: Member/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                MemberModel memberModel = new MemberModel();
                UpdateModel(memberModel);
                memberRepository.InsertMember(memberModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateMember");
            }
        }

        // GET: Member/Edit/5
        public ActionResult Edit(Guid id)
        {
            MemberModel memberModel = memberRepository.GetMemberById(id);
            return View("EditMember", memberModel);
        }

        // POST: Member/Edit/5
        [Authorize (Roles = "Admin, User")]
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                MemberModel memberModel = new MemberModel();
                UpdateModel(memberModel);
                memberRepository.UpdateMember(memberModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditMember");
            }
        }

        // GET: Member/Delete/5
        public ActionResult Delete(Guid id)
        {
            MemberModel memberModel = memberRepository.GetMemberById(id);
            return View("Delete", memberModel);
        }

        // POST: Member/Delete/5
        [Authorize (Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                memberRepository.DeletMember(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
