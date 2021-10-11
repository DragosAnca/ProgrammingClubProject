using ProgrammingClubProject.Models;
using ProgrammingClubProject.Models.DBObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClubProject.Repositories
{
    public class MembershipTypeRepository
    {


        private ClubMembershipModelsDataContext dbContext;

        public MembershipTypeRepository()
        {
            this.dbContext = new ClubMembershipModelsDataContext();
        }

        public MembershipTypeRepository(ClubMembershipModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public void InsertMembershipType (MembershipTypeModel membershipTypeModel)
        {
            membershipTypeModel.IDMembershipType = Guid.NewGuid();
            dbContext.MembershipTypes.InsertOnSubmit(MapModelToDbObject(membershipTypeModel));
            dbContext.SubmitChanges();
        }

        public List<MembershipTypeModel> GetAllMembershipType()
        {
            List<MembershipTypeModel> membershipTypesList = new List<MembershipTypeModel>();
            foreach( var dbMembershipType in dbContext.MembershipTypes)
            {
                membershipTypesList.Add(MapDbObjectToModel(dbMembershipType));
            }
            return membershipTypesList;
        }

        public void UpdateMembershipType(MembershipTypeModel membershipTypeModel)
        {
            MembershipType existingMembershipType = dbContext.MembershipTypes
                .FirstOrDefault(x => x.IDMembershipType == membershipTypeModel.IDMembershipType);

            if(existingMembershipType != null)
            {
                existingMembershipType.IDMembershipType = membershipTypeModel.IDMembershipType ;
                existingMembershipType.Name = membershipTypeModel.Name ;
                existingMembershipType.Description = membershipTypeModel.Description ;
                existingMembershipType.SubscriptionLenthInMonths = membershipTypeModel.SubscriptionLenghtInMonths ;
                dbContext.SubmitChanges();
            }
           
        }

        public MembershipTypeModel GetMembershipTypeById (Guid id)
        {
            return MapDbObjectToModel(dbContext.MembershipTypes.FirstOrDefault(memt => memt.IDMembershipType == id));
        }

        public void DeleteMembershipType(Guid id)
        {
            MembershipType membershipTypeToBeDeleted = dbContext.MembershipTypes
                .FirstOrDefault(memt => memt.IDMembershipType == id);

            if(membershipTypeToBeDeleted != null)
            {
                dbContext.MembershipTypes.DeleteOnSubmit(membershipTypeToBeDeleted);
                dbContext.SubmitChanges();
            }
        }



        private MembershipType MapModelToDbObject (MembershipTypeModel membershipTypeModel)
        {
            MembershipType dbMembershipType = new MembershipType();
            if(membershipTypeModel != null)
            {
                dbMembershipType.IDMembershipType = membershipTypeModel.IDMembershipType;
                dbMembershipType.Name = membershipTypeModel.Name;
                dbMembershipType.Description = membershipTypeModel.Description;
                dbMembershipType.SubscriptionLenthInMonths = membershipTypeModel.SubscriptionLenghtInMonths;
                return dbMembershipType;
            }
            return null;
        }

        private MembershipTypeModel MapDbObjectToModel(MembershipType membershipType)
        {
            MembershipTypeModel membershipTypeModel = new MembershipTypeModel();
            if (membershipType != null)
            {
                membershipTypeModel.IDMembershipType = membershipType.IDMembershipType;
                membershipTypeModel.Name = membershipType.Name;
                membershipTypeModel.Description = membershipType.Description;
                membershipTypeModel.SubscriptionLenghtInMonths = membershipType.SubscriptionLenthInMonths;
                return membershipTypeModel;
            }
            return null;
        }

    }
}