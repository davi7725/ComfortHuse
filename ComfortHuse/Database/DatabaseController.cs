using Comforthuse.Interfaces;
using Comforthuse.Models;
using Comforthuse.Models.SpecificationDerivatives;
using Comforthuse.Utility;
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

        public Dictionary<int, ProductType> GetAllProductTypes()
        {
            Dictionary<int, ProductType> listOfProductTypes = new Dictionary<int, ProductType>();

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand("CH_SP_GetAllProductTypesWithCategoryName", conn);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int productTypeId = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string productCategoryName = reader.GetString(2);

                        ProductType pt = new ProductType(productTypeId, name, productCategoryName);
                        listOfProductTypes.Add(productTypeId, pt);
                    }
                }
                reader.Close();
                reader.Dispose();

            }
            catch (SqlException)
            {

            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return listOfProductTypes;
        }

        public Dictionary<int, ProductOption> GetAllProductOptions()
        {
            Dictionary<int, ProductOption> listOfProductOptions = new Dictionary<int, ProductOption>();

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand("CH_SP_GetAllProductOptions", conn);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int productOptionId = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        decimal priceF = reader.GetDecimal(2);
                        decimal priceS = reader.GetDecimal(3);
                        string unit = reader.GetString(4);
                        bool isStandard = reader.GetBoolean(5);
                        int productType = reader.GetInt32(6);

                        ProductOption po = new ProductOption(productOptionId, name, priceF, priceS, unit, isStandard, productType);
                        listOfProductOptions.Add(productOptionId, po);
                    }
                }
                reader.Close();
                reader.Dispose();
            }
            catch (SqlException)
            { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return listOfProductOptions;
        }

        public List<ICase> GetAllCases()
        {
            List<ICase> listOfCases = new List<ICase>();
            List<TempCase> tempCases = new List<TempCase>();

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand("CH_SP_GetAllCases", conn);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int caseNumber = reader.GetInt32(0);

                        DateTime? constructionStartDate;
                        if (reader.IsDBNull(1))
                        {
                            constructionStartDate = null;
                        }
                        else
                        {
                            constructionStartDate = reader.GetDateTime(1);
                        }

                        DateTime? moveInDate;
                        if (reader.IsDBNull(2))
                        {
                            moveInDate = null;
                        }
                        else
                        {
                            moveInDate = reader.GetDateTime(2);
                        }
                        string description;
                        if (reader.IsDBNull(3))
                        {
                            description = null;
                        }
                        else
                        {
                            description = reader.GetString(3);
                        }

                        int amountOfRevisions = reader.GetInt32(4);
                        DateTime dateOfCreation = reader.GetDateTime(5);
                        DateTime dateOfLastRevision = reader.GetDateTime(6);

                        bool sold = reader.GetBoolean(7);
                        string customerEmail = reader.GetString(8);

                        int? moneyInstituteId;
                        if (reader.IsDBNull(9))
                        {
                            moneyInstituteId = null;
                        }
                        else
                        {
                            moneyInstituteId = reader.GetInt32(9);
                        }
                        string employeeEmail = reader.GetString(10);

                        int? plotId;
                        if (reader.IsDBNull(11))
                        {
                            plotId = null;
                        }
                        else
                        {
                            plotId = reader.GetInt32(11);
                        }

                        int? imageId;
                        if (reader.IsDBNull(12))
                        {
                            imageId = null;
                        }
                        else
                        {
                            imageId = reader.GetInt32(12);
                        }


                        Case caseObj = (Case)ObjectFactory.Instance.CreateNewCase();
                        caseObj.CaseNumber = caseNumber;
                        caseObj.ConstructionStartDate = constructionStartDate;
                        caseObj.MoveInDate = moveInDate;
                        caseObj.Description = description;
                        caseObj.AmountOfRevisions = amountOfRevisions;
                        caseObj.DateOfCreation = dateOfCreation;
                        caseObj.DateOfLastRevision = dateOfLastRevision;
                        caseObj.Sold = sold;

                        TempCase tempCase = new TempCase(caseObj, customerEmail, moneyInstituteId, employeeEmail, plotId, imageId);

                        tempCases.Add(tempCase);

                        listOfCases.Add(caseObj);

                    }
                }

                reader.Close();
                reader.Dispose();
                command.Dispose();
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }


            GetCaseDependencies(tempCases);

            return listOfCases;
        }

        private void GetCaseDependencies(List<TempCase> tempCases)
        {
            foreach (TempCase tc in tempCases)
            {
                tc.Case.Customer = GetCustomerByEmail(tc.CustomerEmail);

                if (tc.MoneyInstituteId == null)
                    tc.Case.MoneyInstitute = new MoneyInstitute();
                else
                    tc.Case.MoneyInstitute = GetMoneyInstituteById(Convert.ToInt32(tc.MoneyInstituteId));

                if (tc.PlotId == null)
                    tc.Case.Plot = ObjectFactory.Instance.CreatePlot();
                else
                    tc.Case.Plot = GetPlotById(Convert.ToInt32(tc.PlotId));


                if (tc.ImageId == null)
                    tc.Case.Image = new Image();
                else
                    tc.Case.Image = GetImageById(Convert.ToInt32(tc.ImageId));

                IExpenseCategory iec = tc.Case.GetExpenseCategory(Category.HouseType);
                IHouseTypeExpenses ihte = (IHouseTypeExpenses)iec;
                ihte.HouseType = GetHouseType(tc);

                tc.Case.Employee = EmployeeRepository.Instance.Load(tc.EmployeeEmail);

                GetAllTechnicalSpecificationForCase(tc.Case);
                GetAllExtraExpenseForCase(tc.Case);
            }
        }

        private void GetAllExtraExpenseForCase(Case @case)
        {
            Dictionary<IExtraExpenseSpecification, Category> listOfExtraExpenses = new Dictionary<IExtraExpenseSpecification, Category>();

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand("CH_SP_GetAllExtraExpensesForCase", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CaseYear", @case.DateOfCreation.Year));
                command.Parameters.Add(new SqlParameter("@CaseNumber", @case.CaseNumber));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        int amount = reader.GetInt32(1);
                        decimal price = reader.GetDecimal(2);
                        string title = reader.GetString(3);
                        int categoryId = reader.GetInt32(4) - 1;

                        IExtraExpenseSpecification iExpSpec = new ExtraExpenseSpecification();
                        iExpSpec.Title = title;
                        iExpSpec.Description = name;
                        iExpSpec.Amount = amount;
                        iExpSpec.PricePerUnit = price;

                        listOfExtraExpenses.Add(iExpSpec, (Category)categoryId);
                    }

                }
                reader.Close();
                reader.Dispose();

            }
            catch (SqlException)
            { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            foreach (KeyValuePair<IExtraExpenseSpecification, Category> kvp in listOfExtraExpenses)
            {
                @case.GetExpenseCategory(kvp.Value).ExtraExpenses.Add(kvp.Key);
            }
        }

        private void GetAllTechnicalSpecificationForCase(Case @case)
        {
            Dictionary<ITechnicalSpecification, Category> listOfTechnicalSpecifications = new Dictionary<ITechnicalSpecification, Category>();

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand("CH_SP_GetAllTechnicalSpecificationOfACase", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CaseYear", @case.DateOfCreation.Year));
                command.Parameters.Add(new SqlParameter("@CaseNumber", @case.CaseNumber));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string description = reader.GetString(0);
                        bool isTicked = reader.GetBoolean(1);
                        int categoryId = reader.GetInt32(2) - 1;

                        ITechnicalSpecification iTechSpec = new TechnicalSpecification();
                        iTechSpec.Description = description;
                        iTechSpec.Editable = isTicked;

                        listOfTechnicalSpecifications.Add(iTechSpec, (Category)categoryId);
                    }

                }
                reader.Close();
                reader.Dispose();

            }
            catch (SqlException)
            { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            foreach (KeyValuePair<ITechnicalSpecification, Category> kvp in listOfTechnicalSpecifications)
            {
                @case.GetExpenseCategory(kvp.Value).TechnicalSpecifications.Add(kvp.Key);
            }
        }

        private IHouseType GetHouseType(TempCase tc)
        {
            IHouseType houseType = new HouseType();

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand("CH_SP_SelectHouseType", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CaseNumber", tc.Case.CaseNumber));
                command.Parameters.Add(new SqlParameter("@CaseYear", tc.Case.DateOfCreation.Year));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string name;
                    if (reader.IsDBNull(0))
                    {
                        name = null;
                    }
                    else
                    {
                        name = reader.GetString(0);
                    }

                    string description;
                    if (reader.IsDBNull(1))
                    {
                        description = null;
                    }
                    else
                    {
                        description = reader.GetString(1);
                    }

                    int? area;
                    if (reader.IsDBNull(2))
                    {
                        area = null;
                    }
                    else
                    {
                        area = reader.GetInt32(2);
                    }

                    decimal? price;
                    if (reader.IsDBNull(3))
                    {
                        price = null;
                    }
                    else
                    {
                        price = reader.GetDecimal(3);
                    }

                    houseType.Name = name;
                    houseType.Description = description;
                    houseType.Area = area;
                    houseType.TotalPrice = price;
                }
                reader.Close();
                reader.Dispose();

            }
            catch (SqlException)
            { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return houseType;
        }

        public List<IEmployee> GetAllEmployees()
        {
            List<IEmployee> listOfEmployees = new List<IEmployee>();

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand("CH_SP_GetAllEmployees", conn);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string firstName = reader.GetString(0);
                        string lastName = reader.GetString(1);
                        string phoneNb = reader.GetString(2);
                        string email = reader.GetString(3);

                        IEmployee emp = new Employee(firstName, lastName, email, phoneNb);
                        listOfEmployees.Add(emp);
                    }
                }
                reader.Close();
                reader.Dispose();

            }
            catch (SqlException)
            {

            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return listOfEmployees;
        }

        private IImage GetImageById(int imageId)
        {
            IImage image = ObjectFactory.Instance.CreateNewImage();

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand("CH_SP_GetImageById", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ImageId", imageId));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string path = reader.GetString(0);
                    string description = reader.GetString(1);
                    image.Path = path;
                    image.Description = description;
                }
                reader.Close();
                reader.Dispose();

            }
            catch (SqlException)
            { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return image;
        }

        private IPlot GetPlotById(int plotId)
        {
            IPlot plot = ObjectFactory.Instance.CreatePlot();


            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand("CH_SP_GetPlotById", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PlotId", plotId));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string zipcode = reader.GetString(0);
                    string address = reader.GetString(1);
                    string city = reader.GetString(2);
                    int area = reader.GetInt32(3);
                    string municipality = reader.GetString(4);
                    DateTime? availabilityDate;
                    if (reader.IsDBNull(5))
                    {
                        availabilityDate = null;
                    }
                    else
                    {
                        availabilityDate = reader.GetDateTime(5);
                    }

                    plot.Zipcode = zipcode;
                    plot.Address = address;
                    plot.City = city;
                    plot.Area = area;
                    plot.Municipality = municipality;
                    plot.AvailabilityDate = availabilityDate;

                }
                reader.Close();
                reader.Dispose();
            }
            catch (SqlException)
            { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return plot;
        }

        private IMoneyInstitute GetMoneyInstituteById(int moneyInstituteId)
        {
            IMoneyInstitute moneyInstitute = new MoneyInstitute();

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand("CH_SP_GetMoneyInstituteById", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@MoneyInstituteId", moneyInstituteId));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string name = reader.GetString(0);
                    string address = reader.GetString(1);
                    string zipcode = reader.GetString(2);
                    string city = reader.GetString(3);
                    string phoneNb = reader.GetString(4);
                    moneyInstitute = ObjectFactory.Instance.CreateMoneyInstitute(name, address, zipcode, city, phoneNb);
                }
                reader.Close();
                reader.Dispose();

            }
            catch (SqlException)
            { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return moneyInstitute;
        }

        private ICustomer GetCustomerByEmail(string customerEmail)
        {
            Customer customer = new Customer();

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand("CH_SP_GetCustomerByEmail", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Email", customerEmail));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string firstName = reader.GetString(0);
                    string lastName = reader.GetString(1);
                    string city = reader.GetString(3);
                    string address = reader.GetString(4);
                    string zipcode = reader.GetString(5);
                    string phoneNb1 = reader.GetString(6);
                    string phoneNb2;
                    if (reader.IsDBNull(7))
                    {
                        phoneNb2 = "";
                    }
                    else
                    {
                        phoneNb2 = reader.GetString(7);
                    }
                    customer.FirstName = firstName;
                    customer.LastName = lastName;
                    customer.Email = customerEmail;
                    customer.City = city;
                    customer.Address = address;
                    customer.Zipcode = zipcode;
                    customer.PhoneNb1 = phoneNb1;
                    customer.PhoneNb2 = phoneNb2;
                }
                reader.Close();
                reader.Dispose();

            }
            catch (SqlException)
            { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return customer;
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
                int? imageId = InsertImage(c.Image);
                int moneyInstituteId = InsertMoneyInstitute(c.MoneyInstitute);
                string employeeEmail = InsertEmployee(c.Employee);
                int plotId = InsertPlot(c.Plot);

                c.CaseNumber = InsertCase(c, customerEmail, moneyInstituteId, employeeEmail, plotId, imageId);
                InsertTechnicalSpecifications(c.GetAllCategories(), c.DateOfCreation.Year, c.CaseNumber);
                InsertExtraExpenses(c.GetAllCategories(), c.DateOfCreation.Year, c.CaseNumber);
                InsertProducts(c, c.DateOfCreation.Year, c.CaseNumber);
                InsertHouseType(c, c.DateOfCreation.Year, c.CaseNumber);

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
                }
            }
            return isSuccessful;
        }

        private void InsertHouseType(ICase c, int year, int caseNumber)
        {
            DeleteHouseType(year, caseNumber);

            IHouseTypeExpenses houseTypeEx = (IHouseTypeExpenses)c.GetExpenseCategory(Category.HouseType);
            SqlCommand command = new SqlCommand("CH_SP_InsertHouseType", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Name", houseTypeEx.HouseType.Name));
            command.Parameters.Add(new SqlParameter("@HouseTypeDescription", houseTypeEx.HouseType.Description));
            command.Parameters.Add(new SqlParameter("@Area", houseTypeEx.HouseType.Area));
            command.Parameters.Add(new SqlParameter("@TotalPrice", houseTypeEx.HouseType.TotalPrice));
            command.Parameters.Add(new SqlParameter("@CaseNumber", caseNumber));
            command.Parameters.Add(new SqlParameter("@CaseYear", year));

            command.ExecuteNonQuery();

            command.Dispose();
        }

        private void DeleteHouseType(int year, int caseNumber)
        {

            SqlCommand command = new SqlCommand("CH_SP_DeleteHouseType", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@CaseNumber", caseNumber));
            command.Parameters.Add(new SqlParameter("@CaseYear", year));

            command.ExecuteNonQuery();

            command.Dispose();
        }

        private void InsertProducts(ICase c, int caseYear, int caseNumber)
        {
            DeleteCaseProducts(caseYear, caseNumber);

            Dictionary<Category, IExpenseCategory> dictionary = c.GetAllCategories();

            foreach (IExpenseCategory iec in dictionary.Values)
            {
                foreach (ProductType pt in iec.ListOfProductTypes)
                {
                    foreach (ProductOption po in pt.ListOfProductOptions)
                    {
                        if (po.Selected == true)
                        {
                            InsertCaseProductOption(po.ProductId, caseNumber, caseYear, po.Amount, po.SpecialPrice, po.Special);
                        }
                    }
                }
            }
        }

        private void InsertCaseProductOption(int productId, int caseNumber, int caseYear, int amount, decimal specialPrice, bool special)
        {
            SqlCommand command = new SqlCommand("CH_SP_InsertCaseProduct", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@CaseNumber", caseNumber));
            command.Parameters.Add(new SqlParameter("@CaseYear", caseYear));
            command.Parameters.Add(new SqlParameter("@ProductOptionId", productId));
            command.Parameters.Add(new SqlParameter("@Amount", amount));
            command.Parameters.Add(new SqlParameter("@SpecialPrice", specialPrice));
            command.Parameters.Add(new SqlParameter("@Special", special));

            command.ExecuteNonQuery();

            command.Dispose();
        }

        private void DeleteCaseProducts(object caseYear, int caseNumber)
        {
            SqlCommand command = new SqlCommand("CH_SP_DeleteCaseProducts", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@CaseNumber", caseNumber));
            command.Parameters.Add(new SqlParameter("@CaseYear", caseYear));

            command.ExecuteNonQuery();

            command.Dispose();
        }

        private void InsertTechnicalSpecifications(Dictionary<Category, IExpenseCategory> dictionary, int caseYear, int caseNumber)
        {
            DeleteCaseTechnicalSpecifications(caseYear, caseNumber);
            foreach (KeyValuePair<Category,IExpenseCategory> kvp in dictionary)
            {
                IExpenseCategory iec = kvp.Value;
                foreach (ITechnicalSpecification iees in iec.TechnicalSpecifications)
                {
                    if (iees.Description != null)
                    {
                        InsertTechnicalSpecification(iees.Description, iees.Editable, caseNumber, caseYear, kvp.Key.ToString());
                    }
                }
            }
        }

        private void InsertTechnicalSpecification(string description, bool editAble, int caseNumber, int caseYear, string categoryName)
        {
            SqlCommand command = new SqlCommand("CH_SP_InsertTechnicalSpecification", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@TechnicalSpDescription", description));
            command.Parameters.Add(new SqlParameter("@IsTicked", editAble));
            command.Parameters.Add(new SqlParameter("@CaseNumber", caseNumber));
            command.Parameters.Add(new SqlParameter("@CaseYear", caseYear));
            command.Parameters.Add(new SqlParameter("@CategoryName", categoryName));

            command.ExecuteNonQuery();

            command.Dispose();
        }

        private void DeleteCaseTechnicalSpecifications(int caseYear, int caseNumber)
        {
            SqlCommand command = new SqlCommand("CH_SP_DeleteCaseTechincalSpecifiication", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@CaseNumber", caseNumber));
            command.Parameters.Add(new SqlParameter("@CaseYear", caseYear));

            command.ExecuteNonQuery();

            command.Dispose();
        }

        private void InsertExtraExpenses(Dictionary<Category, IExpenseCategory> expenseCategories, int caseYear, int caseNumber)
        {
            DeleteCaseExtraExpenses(caseYear, caseNumber);
            foreach (KeyValuePair<Category, IExpenseCategory> kvp in expenseCategories)
            {
                IExpenseCategory iec = kvp.Value;
                string category = kvp.Key.ToString();
                foreach (IExtraExpenseSpecification iees in iec.ExtraExpenses)
                {
                    if (iees.Title != "" && iees.Description != "" && iees.Amount != 0)
                        InsertExtraExpense(iees.Description, iees.Amount, iees.PricePerUnit, caseNumber, caseYear, iees.Title, category);
                }
            }
        }

        private void InsertExtraExpense(string description, int amount, decimal pricePerUnit, int caseNumber, int caseYear, string title, string category)
        {
            SqlCommand command = new SqlCommand("CH_SP_InsertAndReturnProductExpenseId", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ProductExpenseName", description));
            command.Parameters.Add(new SqlParameter("@Amount", amount));
            command.Parameters.Add(new SqlParameter("@Price", pricePerUnit));
            command.Parameters.Add(new SqlParameter("@CaseNumber", caseNumber));
            command.Parameters.Add(new SqlParameter("@CaseYear", caseYear));
            command.Parameters.Add(new SqlParameter("@ProductExpenseTypeName", title));
            command.Parameters.Add(new SqlParameter("@ProductCategoryName", category));

            command.ExecuteNonQuery();

            command.Dispose();

        }

        private void DeleteCaseExtraExpenses(int caseYear, int caseNumber)
        {
            SqlCommand command = new SqlCommand("CH_SP_DeleteCaseProductExpenses", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@CaseNumber", caseNumber));
            command.Parameters.Add(new SqlParameter("@CaseYear", caseYear));

            command.ExecuteNonQuery();

            command.Dispose();
        }

        public int InsertCase(ICase c, string customerEmail, int moneyInstituteId, string employeeEmail, int plotId, int? imageId)
        {
            int caseNumber = c.CaseNumber;
            int caseYear = c.DateOfCreation.Year;
            DateTime? constructionStartDate = c.ConstructionStartDate;
            DateTime? moveInDate = c.MoveInDate;
            string caseDescription = c.Description;

            SqlCommand command = new SqlCommand("CH_SP_InsertOrEditCase", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@CaseNumber", caseNumber));
            command.Parameters.Add(new SqlParameter("@CaseYear", caseYear));
            command.Parameters.Add(new SqlParameter("@ConstructionStartDate", constructionStartDate));
            command.Parameters.Add(new SqlParameter("@MoveInDate", moveInDate));
            command.Parameters.Add(new SqlParameter("@CaseDescription", caseDescription));
            command.Parameters.Add(new SqlParameter("@CustomerEmail", customerEmail));
            command.Parameters.Add(new SqlParameter("@MoneyInstituteId", moneyInstituteId));
            command.Parameters.Add(new SqlParameter("@EmployeeEmail", employeeEmail));
            command.Parameters.Add(new SqlParameter("@PlotId", plotId));
            command.Parameters.Add(new SqlParameter("@ImageId", imageId));
            SqlParameter returnParameter = command.Parameters.Add("@CaseNumber", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            command.ExecuteNonQuery();

            command.Dispose();

            return int.Parse(returnParameter.Value.ToString());
        }

        private int? InsertImage(IImage image)
        {
            if (image == null)
            {
                return null;
            }

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
            command.Parameters.Add(new SqlParameter("@ZipCode", plot.Zipcode));
            command.Parameters.Add(new SqlParameter("@PlotAddress", plot.Address));
            command.Parameters.Add(new SqlParameter("@City", plot.City));
            command.Parameters.Add(new SqlParameter("@Area", plot.Area));
            command.Parameters.Add(new SqlParameter("@Municipality", plot.Municipality));
            command.Parameters.Add(new SqlParameter("@AvailabilityDate", plot.AvailabilityDate));

            SqlParameter returnParameter = command.Parameters.Add("@PlotId", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            command.ExecuteNonQuery();

            command.Dispose();

            return int.Parse(returnParameter.Value.ToString());
        }

        private string InsertEmployee(IEmployee employee)
        {
            if (employee == null)
            {
                return new Employee("Allan", "Boje", "ab@comforthuse.dk", "25874565").Email;
            }
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
