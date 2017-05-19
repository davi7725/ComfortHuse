﻿using Comforthuse.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Comforthuse.Database
{
    public class DatabaseController : IDbAdmin, IDbEmployee
    {

        private static DatabaseController _instance = null;
        private SqlConnection conn;

        private DatabaseController() { }

        public static DatabaseController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DatabaseController();
                    _instance.conn = new SqlConnection("Server=ealdb1.eal.local;Database=EJL62_DB;User ID=ejl62_usr;Password=Baz1nga62");
                }
                return _instance;
            }
        }



        public List<ICase> GetAllCases()
        {
            List<ICase> list = new List<ICase>();

            return list;
        }

        public int GetNextCaseId()
        {
            return 1;

        }

        public ICase GetCase(int caseId)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveCase(ICase c)
        {
            bool isSuccessful = true;

            try
            {
                conn.Open();
                string customerEmail = InsertCustomer(c.Customer);
                int moneyInstituteId = InsertMoneyInstitute(c.MoneyInstitute);
                string employeeEmail = InsertEmployee(c.Employee);
                int plotId = InsertPlot(c.Plot);
                int imageId = InsertImage(c.Image);
                InsertCase(c, customerEmail, moneyInstituteId, employeeEmail, plotId, imageId);
                //InsertProducts();
                //InsertExtraExpenses();

            }
            catch (SqlException sqlE)
            {
                isSuccessful = false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }


            return isSuccessful;
        }

        public void InsertCase(ICase c, string customerEmail, int moneyInstituteId, string employeeEmail, int plotId, int imageId)
        {
            int caseNumber = c.CaseNumber;
            int caseYear = c.DateOfCreation.Year;
            DateTime constructionStartDate = c.ConstructionStartDate;
            DateTime moveInDate = c.MoveInDate;
            string caseDescription = c.Description;

            SqlCommand command = new SqlCommand("CH_SP_InsertOrEditCase", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ConstructionStartDate", constructionStartDate));
            command.Parameters.Add(new SqlParameter("@MoveInDate", moveInDate));
            command.Parameters.Add(new SqlParameter("@CaseDescription", caseDescription));
            command.Parameters.Add(new SqlParameter("@CustomerEmail", customerEmail));
            command.Parameters.Add(new SqlParameter("@MoneyInstituteId", moneyInstituteId));
            command.Parameters.Add(new SqlParameter("@EmployeeEmail", employeeEmail));
            command.Parameters.Add(new SqlParameter("@PlotId", plotId));
            command.Parameters.Add(new SqlParameter("@ImageId", imageId));

            command.ExecuteNonQuery();

            command.Dispose();
        }

        private int InsertImage(IImage image)
        {
            SqlCommand command = new SqlCommand("CH_SP_InsertOrEditImage", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Imagepath", image.Path));
            command.Parameters.Add(new SqlParameter("@ImageDescription", image.Description));

            SqlParameter returnParameter = command.Parameters.Add("@ImageId", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            command.ExecuteNonQuery();

            command.Dispose();

            return int.Parse(returnParameter.Value.ToString());
        }

        private int InsertPlot(IPlot plot)
        {
            SqlCommand command = new SqlCommand("CH_SP_InsertOrEditPlot", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Zipcode", plot.Zipcode));
            command.Parameters.Add(new SqlParameter("@PlotAddress", plot.Address));
            command.Parameters.Add(new SqlParameter("@City", plot.City));
            command.Parameters.Add(new SqlParameter("@Area", plot.Area));
            command.Parameters.Add(new SqlParameter("@Municipality", plot.Municipality));
            command.Parameters.Add(new SqlParameter("@AvailabilityDate", plot.AvalibilityDate));

            SqlParameter returnParameter = command.Parameters.Add("@PlotId", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            command.ExecuteNonQuery();

            command.Dispose();

            return int.Parse(returnParameter.Value.ToString());
        }

        private string InsertEmployee(IEmployee employee)
        {
            return employee.Email;
        }

        private int InsertMoneyInstitute(IMoneyInstitute moneyInstitute)
        {
            SqlCommand command = new SqlCommand("CH_SP_InsertOrEditMoneyInstitute", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Name", moneyInstitute.Name));
            command.Parameters.Add(new SqlParameter("@MoneyInstituteAddress", moneyInstitute.Address));
            command.Parameters.Add(new SqlParameter("@Zipcode", moneyInstitute.Zipcode));
            command.Parameters.Add(new SqlParameter("@City", moneyInstitute.City));
            command.Parameters.Add(new SqlParameter("@PhoneNb", moneyInstitute.PhoneNb));

            SqlParameter returnParameter = command.Parameters.Add("@MoneyInstituteId", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            command.ExecuteNonQuery();

            command.Dispose();

            return int.Parse(returnParameter.Value.ToString());
        }

        private string InsertCustomer(ICustomer customer)
        {
            SqlCommand command = new SqlCommand("CH_SP_InsertOrEditCustomer", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@FirstName", customer.FirstName));
            command.Parameters.Add(new SqlParameter("@LastName", customer.LastName));
            command.Parameters.Add(new SqlParameter("@Email", customer.Email));
            command.Parameters.Add(new SqlParameter("@City", customer.City));
            command.Parameters.Add(new SqlParameter("@CustomerAddress", customer.Address));
            command.Parameters.Add(new SqlParameter("@Zipcode", customer.Zipcode));
            command.Parameters.Add(new SqlParameter("@PhoneNb1", customer.PhoneNb1));
            command.Parameters.Add(new SqlParameter("@PhoneNb2", customer.PhoneNb2));

            command.ExecuteNonQuery();

            command.Dispose();

            return customer.Email;
        }

        public List<ICustomer> GetAllCustomersByName()
        {
            throw new NotImplementedException();
        }

        public void SearchForCustomer(string query)
        {
            throw new NotImplementedException();
        }
    }
}
