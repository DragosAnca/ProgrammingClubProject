using ProgrammingClubProject.Models;
using ProgrammingClubProject.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClubProject.Repositories
{
    public class MemberRepository
    {

        private ClubMembershipModelsDataContext dbContext;

        public MemberRepository()
        {
            this.dbContext = new ClubMembershipModelsDataContext();
        }

        public MemberRepository(ClubMembershipModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void InsertMember(MemberModel memberModel)
        {
            memberModel.IDMember = Guid.NewGuid();
            dbContext.Members.InsertOnSubmit(MapModelToDbObject(memberModel));
            dbContext.SubmitChanges();
        }

        public List<MemberModel> GetAllMember()
        {
            List<MemberModel> membersList = new List<MemberModel>();
            foreach( var dbMember in dbContext.Members)
            {
                membersList.Add(MapDbObjectToModel(dbMember));
            }
            return membersList;

        }

        public void UpdateMember(MemberModel memberModel)
        {
            Member existingMember = dbContext.Members
                .FirstOrDefault(x => x.IDMember == memberModel.IDMember);

            if(existingMember != null)
            {
                existingMember.IDMember = memberModel.IDMember ;
                existingMember.Name = memberModel.Name ;
                existingMember.Title = memberModel.Title ;
                existingMember.Position = memberModel.Position ;
                existingMember.Description = memberModel.Description ;
                existingMember.Resume = memberModel.Resume ;
                dbContext.SubmitChanges();
            }
        }

        public MemberModel GetMemberById (Guid id)
        {
            return MapDbObjectToModel(dbContext.Members.FirstOrDefault(mem => mem.IDMember == id));
        }

        public void DeletMember(Guid id)
        {
            Member memberToBeDeleted = dbContext.Members
                .FirstOrDefault(mem => mem.IDMember == id);

            if(memberToBeDeleted != null)
            {
                dbContext.Members.DeleteOnSubmit(memberToBeDeleted);
                dbContext.SubmitChanges();
            }
        }



        private Member MapModelToDbObject (MemberModel memberModel)
        {
            Member dbMember = new Member();
            if(memberModel != null)
            {
                dbMember.IDMember = memberModel.IDMember;
                dbMember.Name = memberModel.Name;
                dbMember.Title = memberModel.Title;
                dbMember.Position = memberModel.Position;
                dbMember.Description = memberModel.Description;
                dbMember.Resume = memberModel.Resume;
                return dbMember;
            }
            return null;
        }

        private MemberModel MapDbObjectToModel(Member member)
        {
            MemberModel memberModel = new MemberModel();
            if(member != null)
            {
                memberModel.IDMember = member.IDMember;
                memberModel.Name = member.Name;
                memberModel.Title = member.Title;
                memberModel.Position = member.Position;
                memberModel.Description = member.Description;
                memberModel.Resume = member.Resume;
                return memberModel;
            }
            return null;
        }

    }
}