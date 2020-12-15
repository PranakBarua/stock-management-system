using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.BLL
{
    public class CompanyManager
    {
        CompanyGateway companyGateway=new CompanyGateway();

        public string Save(Company company)
        {
            if (companyGateway.IsNameExists(company))
                return "Company name exist";
            int rowAffected = companyGateway.Save(company);
            if (rowAffected > 0)
                return "Company saved successfully";
            return "Company saved failed";
        }

        public List<Company> GetAllCompanies()
        {
            return companyGateway.GetAllCompanies();
        } 
    }
}