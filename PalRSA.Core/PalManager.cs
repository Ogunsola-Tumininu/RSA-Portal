using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.SqlServer;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.UI.WebControls;
using PalRSA.Core.DataAccess;
using PalRSA.Core.Models;
using Image = System.Drawing.Image;


namespace PalRSA.Core
{
    [Serializable]
    public class PalManager
    {
        private readonly PALSiteDBEntities _db;

        private static readonly string DocPath = ConfigurationManager.AppSettings["document-folder"];
        private static readonly string DocPathThumb = ConfigurationManager.AppSettings["document-folder-thumb"];
        private readonly string _error = ConfigurationManager.AppSettings["error"];


        public PalManager()
        {
            _db = new PALSiteDBEntities();
            _db.Database.Log = Console.Write;
        }
        public bool CheckRetirement(string pin)
        {
            return _db.Employees.Count(x => x.Pin == pin && x.FundId == 10000053) > 0;
        }

        private static readonly string PublicationPath = ConfigurationManager.AppSettings["publications"];
        private static readonly string TempExcelPath = ConfigurationManager.AppSettings["excel-temp"];

        public bool IsAccountDisabled(string username)
        {
            //var disabled = _db.UserProfiles.Where(x => x.UserName == username).Select(x => x.IsDisabled).SingleOrDefault();
            //return disabled == true;

            var disabled = _db.UserProfiles.Where(x => x.UserName == username).Select(x => x.IsDisabled).SingleOrDefault();
            return disabled;
        }

        public IEnumerable<TempCustomerInformation> GetAllUpdates()
        {
            return _db.TempCustomerInformations.OrderByDescending(x => x.date_created).ToList();
        }

        public void EnableAccount(string username)
        {
            var user = _db.UserProfiles.SingleOrDefault(x => x.UserName == username);
            if (user != null) user.IsDisabled = false;
            _db.SaveChanges();
        }

        public int GetTotalNumberOfApplications()
        {
            return _db.BenefitApplications.Count(x => x.Status1.StatusValue != "Not Complete" && x.Status1.StatusValue != "Rejected");
        }

        public string GetUserName(string username)
        {
            return _db.Employees.Where(x => x.Email == username).Select(x => x.Email).FirstOrDefault();
        }
        // Added 18/10/2019
        public Employee GetUserDetails(string username)
        {
            return _db.Employees.Where(x => x.Email == username || x.Pin == username || x.MobileNumber == username).FirstOrDefault();
            // _db.Employees.Where(x => x.Email == username).Select(x => x.Email).FirstOrDefault();
        }

        public Employee Employee(string pin)
        {
            var emp = _db.Employees.Where(x => x.Pin == pin).FirstOrDefault();
            return emp;
        }

        public bool EmailExistsInDb(string email)
        {
            return (_db.UserProfiles.Count(x => x.Email == email) > 0 || _db.Employees.Count(x => x.Email == email) > 0);
        }

        public int GetTotalNumberOfCompletedApplications()
        {
            return _db.BenefitApplications.Count(x => x.Status1.StatusValue == "Completed" | x.Status1.StatusValue == "Rejected");
        }

        public int GetTotalNumberOfProfileChanges()
        {
            var changeOfName = _db.ChangeOfNameProfiles.Count(x => x.Status == "Pending");
            var changeOfAddress = _db.ChangeOfAddressProfiles.Count(x => x.Status == "Pending");
            var profileChange = _db.TempCustomerInformations.Count(x => x.status == "Pending");

            return changeOfAddress + changeOfName + profileChange;
        }

        public bool FirstSignOn(string username)
        {
            var status = _db.UserProfiles.Where(x => x.UserName == username).Select(x => x.FirstSignOn).FirstOrDefault();
            if (status == false) return false;
            return status;
        }

        public List<ChangeOfNameProfile> GetAllChangeOfName()
        {
            return _db.ChangeOfNameProfiles.OrderByDescending(x => x.DateUploaded).ToList();
        }

        public List<ChangeOfNameProfile> GetAllChangeOfName(string pin)
        {
            var c = _db.ChangeOfNameProfiles.Where(x => x.Pin == pin).OrderByDescending(x => x.DateUploaded).ToList();
            return c;
        }

        public void LogDate(string username)
        {
            var profile = _db.UserProfiles.SingleOrDefault(x => x.UserName == username);
            if (profile != null) profile.LastLogin = DateTime.Now;
            _db.SaveChanges();
        }

        public bool IsNotAdmin(string username)
        {
            var user = _db.UserProfiles.SingleOrDefault(x => x.UserName == username);
            return user?.Employee_Pin != null;
        }

        public bool UsernameExists(string username)
        {
            return _db.UserProfiles.Count(x => x.UserName == username) > 0;
        }

        public void UpdateChangeOfNameDetails(ChangeOfNameProfile model, string documentId)
        {
            var x = _db.ChangeOfNameProfiles.Find(model.Id);
            x.NewFirstName = model.NewFirstName;
            x.NewMiddleName = model.NewMiddleName;
            x.NewName = model.NewName;

            _db.SaveChanges();
        }

        public void DisableAccount(string username)
        {
            var user = _db.UserProfiles.SingleOrDefault(x => x.UserName == username);
            if (user != null) user.IsDisabled = true;
            _db.SaveChanges();
        }

        public void UpdateChangeOfAddressDetails(ChangeOfAddressProfile model, string documentId)
        {
            var x = _db.ChangeOfAddressProfiles.Find(model.Id);
            x.NewAddress = model.NewAddress;

            _db.SaveChanges();
        }

        public TempCustomerInformation GetUpdateInformation(int id)
        {
            return _db.TempCustomerInformations.FirstOrDefault(x => x.id == id);
        }

        public List<SummaryModel> GetDashboardValues(string pin)
        {
            var list = _db.Contributions.Where(x => x.Pin == pin).ToList();
            return CalculateValues(list);
        }

        public void ChangeOfNameApproved(ChangeOfNameProfile model)
        {
            var x = _db.Employees.Find(model.Pin);
            x.Surname = model.NewName;
            x.FirstName = model.NewFirstName;
            x.OtherNames = model.NewMiddleName;

            _db.SaveChanges();
        }

        public void UpdateTempStatus(string status, int id)
        {
            var x = _db.TempCustomerInformations.Find(id);
            x.status = status;

            _db.SaveChanges();
        }

        public string UpdateEmployeeProfile(TempCustomerInformation model)
        {
            var x = _db.Employees.Find(model.pin);
            x.MobileNumber = model.mobile_number;
            x.MobileNumber2 = model.mobile_number2;
            x.Email = model.email;

            _db.SaveChanges();
            return "success";
        }

        public IEnumerable<webpages_Roles> GetRoles()
        {
            return _db.webpages_Roles.ToList();
        }

        public void UpdateAdminInfo(AdminProfile profile, int id)
        {
            var x = _db.UserProfiles.Find(id);
            x.AdminName = profile.AdminName;
            x.Email = profile.Email;

            _db.SaveChanges();
        }

        public UserProfile GetAdminProfile(string user)
        {
            return _db.UserProfiles.FirstOrDefault(x => x.UserName == user);
        }

        public AdminProfile GetAdminProfileForEdit(string user)
        {
            return _db.UserProfiles.Where(x => x.UserName == user).Select(x => new AdminProfile
            { AdminName = x.AdminName, Email = x.Email, Username = x.UserName }).FirstOrDefault();
        }

        public void RejectedNameReasonUpdate(int id, string reason)
        {
            var x = _db.ChangeOfNameProfiles.Find(id);
            x.Reason = reason;

            _db.SaveChanges();
        }

        public IEnumerable<ExpressionOfInterest> GetAllInterests()
        {
            return _db.ExpressionOfInterests.ToList();
        }

        public ExpressionOfInterest GetExpressionDetails(int id)
        {
            return _db.ExpressionOfInterests.Find(id);
        }

        public void ChangeOfAddressApproved(ChangeOfAddressProfile model)
        {
            var x = _db.Employees.Find(model.Pin);
            x.PermanentAddress = model.NewAddress;

            _db.SaveChanges();
        }

        public void SetFirstLogonToFalse(int id)
        {
            var x = _db.UserProfiles.Find(id);
            x.FirstSignOn = false;

            _db.SaveChanges();
        }

        private List<SummaryModel> CalculateValues(List<Contribution> list)
        {
            var values = CalculateTotalAmountContributed(list);
            values = GetValuationSummary(values, list);

            return CreateAccountSummaryList(values);
        }

        public void RejectedAddressReasonUpdate(int id, string reason)
        {
            var x = _db.ChangeOfAddressProfiles.Find(id);
            x.Reason = reason;
            _db.SaveChanges();
        }

        private List<SummaryModel> CreateAccountSummaryList(AccountSummary values)
        {
            var dash = new List<SummaryModel>
            {
                new SummaryModel() {Description = "Total Amount Contributed", Rsa = values.TotalMandatoryStr, Avc = values.TotalAvcStr, Total = values.TotalAmountContributedStr},
                new SummaryModel() {Description = "Total Income On Contributions", Rsa = values.IncomeRsaStr, Avc = values.IncomeAvcStr, Total = values.IncomeStr},
                new SummaryModel() {Description = "Balance Before Withdrawal", Rsa = values.BalBeforeWithdrawalRsaStr, Avc = values.BalBeforeWithdrawalAvcStr, Total = values.BalBeforeWithdrawalStr},
                new SummaryModel() {Description = "Withdrawal", Rsa = Convert.ToDouble(values.TotalWithdrawal), Avc = Convert.ToDouble(values.TotalAvcWithdrawal), Total = values.TotalWithdrawalStr},
                new SummaryModel() {Description = "Current Balance", Rsa = values.CurrentValueRsaStr, Avc = values.CurrentValueAvcStr, Total = values.CurrentValueStr},
                new SummaryModel() {Description = "Units Held", Rsa = Convert.ToDouble(values.TotalUnitsR), Avc = Convert.ToDouble(values.TotalUnitsV), Total = Convert.ToDouble(values.TotalUnits)},
                new SummaryModel() {Description = "Units Price", Rsa = values.UnitPriceStr, Avc = values.UnitPriceAvcStr, Total = 0}
            };

            return dash;
        }
        public List<Pfa> GetPFA()
        {
            var x = _db.Pfas.Where(d => d.PFACode != null).OrderBy(d => d.Description);
            return x.ToList();
        }

        public ChangeOfAddress GetProfileForChangeOfAddress(string pin)
        {
            var x = _db.Employees.Find(pin);
            return new ChangeOfAddress { OldAddress = x.PermanentAddress, Pin = x.Pin };
        }

        public IEnumerable<AssetAllocationJson> JsonAssetAllocationWeb(int type)
        {
            return
                _db.AssetAllocations.Where(x => x.asset_allocation_type == type)
                    .OrderByDescending(x => x.date_created).Take(7).AsEnumerable().Select(x => new AssetAllocationJson
                    {
                        date_created = x.date_created.Value.ToString("MMM dd, yyyy"),
                        asset_allocation_type = x.asset_allocation_type,
                        equity = x.equity,
                        money_market = x.money_market,
                        others = x.others,
                        fixed_income = x.fixed_income
                    }).ToList();
        }

        public void SaveChangeOfNameDetails(ChangeOfName model, string documentId)
        {
            var uploadName = model.Sex == "M" ? "Court Affidavit" : "Marriage Certificate";
            var x = new ChangeOfNameProfile
            {
                Doc1 = uploadName,
                Ext1 = Path.GetExtension(model.Doc1.FileName),
                Doc2 = "Newspaper Publication",
                Ext2 = Path.GetExtension(model.Doc2.FileName),
                Pin = model.Pin,
                OldName = model.OldName,
                NewName = model.NewName,
                OldMiddleName = model.OldMiddleName,
                NewMiddleName = model.NewMiddleName,
                OldFirstName = model.OldFirstName,
                NewFirstName = model.NewFirstName,
                DocumentId = documentId,
                DateUploaded = DateTime.Now,
                Status = "Pending",
                Description = model.Description
            };

            _db.ChangeOfNameProfiles.Add(x);
            _db.SaveChanges();
        }

        public void SaveExpressionToDb(ExpressionOfInterest model)
        {

            try
            {
                //// check of exists

                //var ei = _db.ExpressionOfInterests.FirstOrDefault(d => d.RsaPin == model.RsaPin);
                //if (ei != null)
                //{
                //    return;
                //}

                model.DateCreated = DateTime.Now;
                _db.ExpressionOfInterests.Add(model);
                //
                if (model.RsaPin.Equals("NoPin", StringComparison.CurrentCultureIgnoreCase))
                {
                    notifyRegistrationInterest(model);
                }
                else
                {
                    notifyClientInterest(model);
                }

                notifyPscInterest(model);

                //
                int chged = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Library.WriteErrorLog(ex, "SaveExpressionToDb");

            }


        }

        private void notifyPscInterest(ExpressionOfInterest model)
        {
            string pfaName = "";
            int pfaId = 0;
            bool isInt = Int32.TryParse(model.CurrentPFACode, out pfaId);
            if (isInt)
            {
                pfaName = _db.Pfas.FirstOrDefault(d => d.Id == pfaId).Description;
            }
            else
            {
                pfaName = model.CurrentPfa;
            }

            var msg = PalLibrary.Messaging.SendEmail("info@palpensions.com", "info@palpensions.com",
                     $"Expression of Interest Notification - {model.Surname} {model.Firstname}", $@"
                                    <p>Hello Info,<br/>

                                    <p>Please be informed that an Expression of Interest has been submitted. The detail of the submitter is as follow: <br />
                                <p> Current PFA:  <strong> {pfaName}   <br/>
                                   RSA PIN  <strong> {model.RsaPin}   <br/>
                                   Surname: <strong> {model.Surname}   <br/>
                                 Firstname <strong> {model.Firstname}   <br/>                                
                                  Phone number: <strong> {model.Telephone1}   <br/>
                                 Employer Name: <strong> {model.EmployerName}   <br/>
                                 Email Address: <strong> {model.Email}   <br/>

                For a list of expression of interest, please visit https://pallite.palpensions.com/Staff/ExpressInterest <br />


                            <p>         Regards<br/>

                                    PAL Pensions</p>", "PAL Pensions <palcustomercare@airmail.palpensions.com>");
        }

        private void notifyClientInterest(ExpressionOfInterest model)
        {
            var msg = PalLibrary.Messaging.SendEmail(model.Email, "info@palpensions.com",
                    $"Welcome to PAL Pensions", $@"
                                  <p>Dear {model.Firstname},</p>
            <p>Thank you for your interest in PAL Pensions. Your details have been submitted successfully and we will remain in constant touch and notify you once the transfer window is opened.<br/>
         </p>
<p>      Thank you for giving us the opportunity to secure your future.
             </p>
<p>
 <br /><br />
            <strong>Your PAL For Life </strong>
            </p>", "PAL Pensions <palcustomercare@airmail.palpensions.com>");
        }


        private void notifyRegistrationInterest(ExpressionOfInterest model)
        {

            var msg = PalLibrary.Messaging.SendEmail(model.Email, "info@palpensions.com",
                    $"Welcome to PAL Pensions", $@"
                                    <p>Dear {model.Firstname},</p>
            <p>Your details have been submitted successfully and one of our agents will be in touch shortly.<br/>
            </p>
<p>  Thank you for choosing PAL Pensions as your retirement savings partner.
             </p><p>
            <br /><br />
           <strong>Your PAL For Life </strong>
            </p>", "PAL Pensions <palcustomercare@airmail.palpensions.com>");
        }

        public string SaveNewExpressionToDb(NewExpressionOfInterest model)
        {
            _db.NewExpressionOfInterests.Add(model);
            try
            {
                model.DateCreated = DateTime.Now;
                int chged = _db.SaveChanges();
                // notifyRegistrationInterest(model);
                //
                return "S";
            }
            catch (Exception ex)
            {
                Library.WriteErrorLog(ex, "SaveNewExpressionToDb");
                return ex.Message;

            }

        }
        public object JsonFilterPriceForWeb(DateTime from, DateTime to, double schemeId)
        {
            var list = _db.PriceHistories.Where(x => x.scheme_id == schemeId && x.valuation_date.Value >= from && x.valuation_date.Value <= to).ToList();

            return list.Select(o => new RsaHistory
            {
                Date = o.valuation_date.Value.ToString("MMM dd, yyyy"),
                Value = string.Format(new System.Globalization.CultureInfo("yo-NG"), "{0:C4}", @Math.Round((decimal)o.offer_price, 4))
            }).ToList();
        }

        public int TotalUnApprovedChanges()
        {
            return _db.TempCustomerInformations.Count(x => x.status == "Pending");
        }

        private RsaRetiree GetRetireeFund()
        {
            var r = _db.PriceHistories.Where(x => x.scheme_id == 10000053)
                    .OrderByDescending(x => x.valuation_date).FirstOrDefault();

            return new RsaRetiree
            {
                Date = r.valuation_date.Value.ToString("MMM dd, yyyy"),
                Value = string.Format(new System.Globalization.CultureInfo("yo-NG"), "{0:C4}", @Math.Round((decimal)r.offer_price, 4)),
                Type = "RSA Fund IV"
            };
        }



        public void SaveFeedbackToDb(Feedback feedback)
        {
            _db.Feedbacks.Add(feedback);
            _db.SaveChanges();
        }

        public void UpdateDateModified(int applicationId)
        {
            var x = _db.BenefitApplications.Find(applicationId);
            x.DateModified = DateTime.Now;

            _db.SaveChanges();
        }

        private RsaRetiree GetFundValue(int scheme_id, String fund_name)
        {
            var r = _db.PriceHistories.Where(x => x.scheme_id == scheme_id)
                    .OrderByDescending(x => x.valuation_date).FirstOrDefault();
            return new RsaRetiree
            {
                Date = r.valuation_date.Value.ToString("MMM dd, yyyy"),
                Value = string.Format(new System.Globalization.CultureInfo("yo-NG"), "{0:C4}", @Math.Round((decimal)r.offer_price, 4)),
                Type = fund_name
            };
        }
        private RsaRetiree GetFundOfferPrice()
        {
            var r = _db.PriceHistories.Where(x => x.scheme_id == 1)
                    .OrderByDescending(x => x.valuation_date).FirstOrDefault();

            return new RsaRetiree
            {
                Date = r.valuation_date.Value.ToString("MMM dd, yyyy"),
                Value = string.Format(new System.Globalization.CultureInfo("yo-NG"), "{0:C4}", @Math.Round((decimal)r.offer_price, 4)),
                Type = "RSA"
            };
        }

        public List<RsaHistory> JsonRsaPriceForWeb(int month, int year)
        {
            var list = _db.PriceHistories.Where(x => x.scheme_id == 1 && x.valuation_date.Value.Month == month && x.valuation_date.Value.Year == year).ToList();

            return list.Select(o => new RsaHistory
            {
                Date = o.valuation_date.Value.ToString("MMM dd, yyyy"),
                Value = o.offer_price.ToString()
            }).ToList();
        }

        public bool ApplicationIsSubmitted(int applicationId)
        {
            return
                _db.BenefitApplications.Where(x => x.BenefitApplicationId == applicationId)
                    .Select(x => x.Status1.StatusValue)
                    .FirstOrDefault() != "Not Complete";
        }

        public List<RsaHistory> JsonPriceForWebType(double scheme)
        {
            var list = _db.PriceHistories.Where(x => x.scheme_id == scheme).OrderByDescending(x => x.valuation_date).Take(7).ToList();

            return list.Select(o => new RsaHistory
            {
                Date = o.valuation_date.Value.ToString("MMM dd, yyyy"),
                Value = string.Format(new System.Globalization.CultureInfo("yo-NG"), "{0:C4}", @Math.Round((decimal)o.offer_price, 4))
            }).OrderBy(x => x.Date).ToList();
        }

        public List<AdminDashboard> GetLoginsForLastSevenDays()
        {
            var sevenDays = DateTime.Now.AddDays(-7);

            return (from up in _db.UserProfiles
                    join e in _db.Employees on up.Employee_Pin equals e.Pin
                    where up.LastLogin.Value >= sevenDays
                    select new AdminDashboard
                    {
                        Email = e.Email,
                        Employer = e.EmployerDetail.EmployerName,
                        FullName = e.FirstName + " " + e.Surname,
                        LastLogin = up.LastLogin.Value,
                        Pin = up.Employee_Pin
                    }).ToList();
        }

        public List<RsaHistory> JsonRetireePriceForWeb(int month, int year)
        {
            var list = _db.PriceHistories.Where(x => x.scheme_id == 10000053 && x.valuation_date.Value.Month == month && x.valuation_date.Value.Year == year).ToList();

            return list.Select(o => new RsaHistory
            {
                Date = o.valuation_date.Value.ToString("MMM dd, yyyy"),
                Value = string.Format(new System.Globalization.CultureInfo("yo-NG"), "{0:C4}", @Math.Round((decimal)o.offer_price, 4))
            }).ToList();
        }

        public GenerateReport GenerateStatement(string pin, DateTime startDate, DateTime endDate)
        {
            var statement = new GenerateReport { Details = _db.Employees.Find(pin) };
            if (statement.Details.Contributions == null) return statement;
            statement.Records = DeriveRecords(statement.Details.Contributions.Where(x => x.TransDate >= startDate && x.TransDate <= endDate).ToList());
            statement.VoluntaryContribution = DeriveVoluntaryRecords(statement.Details.Contributions.Where(x => x.TransDate >= startDate && x.TransDate <= endDate).ToList());
            statement.RegularContributionClosing = ComputeRegularContributionClosingBalance(statement.Records);
            statement.VoluntaryContributionClosing = ComputeRegularContributionClosingBalance(statement.VoluntaryContribution);
            statement.Rsa = ComputeFinalComputation(statement.RegularContributionClosing);
            statement.Voluntary = ComputeFinalComputation(statement.VoluntaryContributionClosing);
            return statement;
        }

        public Employee GetEmployeeDetails(string pin)
        {
            var employee = _db.Employees.Include("Contributions").Include("AccountManager").First(x => x.Pin == pin);
            return employee;
        }
        public Employee GetEmployee(string pin)
        {
            var employee = _db.Employees.Include("EmployerDetail").Include("NextOfKins").First(d => d.Pin == pin);
            //  var employers = _db.EmployerDetails;

            //    var result = employees.GroupJoin(employers,
            //    u => u.Employer_Recno,
            //    p => p.Recno,
            //    (u, p) =>
            //        new { Employee = u, Employer = p.DefaultIfEmpty() })
            //.SelectMany(a => a.Employer.
            //Select(b => new { Employee = a.Employee, Employer = b })).Where(d=>d.Employee.Pin==pin).FirstOrDefault();

            // var employee = _db.Employees.Include("Contributions").Include("AccountManager").First(x => x.Pin == pin);
            return employee;
        }
        public Employee GetEmployeeDetails(string pin, DateTime startDate, DateTime endDate)
        {
            var employee = _db.Employees.First(x => x.Pin == pin); //.Include("Contributions").Include("EmployerDetail")
            employee.Contributions = employee.Contributions.Where(x => x.TransDate >= startDate && x.TransDate <= endDate).OrderByDescending(d => d.ValueDate).ToList();

            return employee;
        }

        public GenerateReport GenerateStatement(string pin)
        {

            Employee employee = _db.Employees.Find(pin);
            var statement = new GenerateReport { Details = employee };
            if (statement.Details.Contributions == null) return statement;
            //var statement = new GenerateReport { Details = _db.Employees.Find(pin) };
            statement.Records = DeriveRecords(statement.Details.Contributions);
            statement.VoluntaryContribution = DeriveVoluntaryRecords(statement.Details.Contributions);
            statement.RegularContributionClosing = ComputeRegularContributionClosingBalance(statement.Records);
            statement.VoluntaryContributionClosing = ComputeRegularContributionClosingBalance(statement.VoluntaryContribution);
            statement.Rsa = ComputeFinalComputation(statement.RegularContributionClosing);
            statement.Voluntary = ComputeFinalComputation(statement.VoluntaryContributionClosing);
            return statement;
        }

        private FinalComputation ComputeFinalComputation(ReportSummation x)
        {
            return new FinalComputation
            {
                ContributionsFromInception = x.SumEmployee + x.SumEmployer,
                TotalDeduction = x.SumFees + x.SumVat,
                TotalWithdrawalFromInception = x.SumWithdrawal,
                NetContribution = x.SumNetContribution,
                GainLossFromInception = GetGainLossValue(x.SumUnits, x.CurrentUnitPrice, x.SumNetContribution),
                CurrentValue = x.SumUnits * x.CurrentUnitPrice,
                NumOfUnitsHeld = x.SumUnits,
                UnitPrice = x.CurrentUnitPrice
            };
        }

        private decimal GetGainLossValue(decimal sumUnits, decimal unitPrice, decimal sumNetContribution)
        {
            return (sumUnits * unitPrice) - sumNetContribution;
        }

        private decimal GetCurrentOfferPrice(int schemeId, DateTime? date)
        {
            _db.Database.Log = Console.Write;
            if (date == null)
                return
                   _db.PriceHistories.Where(x => x.scheme_id == schemeId)
                       .OrderByDescending(x => x.valuation_date).Take(1).Select(x => x.offer_price.Value)
                       .FirstOrDefault();
            date = date.Value.Date;
            return
                _db.PriceHistories.SqlQuery(@"select top 1 * from PriceHistory 
where scheme_id=" + schemeId + " and valuation_date<='" + date + "' order by valuation_date desc").Select(x => x.offer_price.Value).FirstOrDefault();
            //_db.PriceHistories.Where(x => x.scheme_id == schemeId && x.valuation_date <= date.Value)
            //    .OrderByDescending(x => x.valuation_date).Take(1).Select(x => x.offer_price.Value)
            //    .FirstOrDefault();
        }

        private ReportSummation ComputeRegularContributionClosingBalance(IEnumerable<StatementGeneration> statementGenerations)
        {
            var generations = statementGenerations as IList<StatementGeneration> ?? statementGenerations.ToList();
            return new ReportSummation
            {
                //SumEmployee = generations.Sum(x => x.Employee),
                //SumEmployer = generations.Sum(x => x.Employer),
                //SumFees = generations.Sum(x => x.Fees),
                //SumVat = generations.Sum(x => x.Vat),
                //SumNetContribution = generations.Sum(x => x.NetContribution),
                //SumWithdrawal = generations.Sum(x => x.Withdrawal),
                //SumPrice = generations.Sum(x => x.Price),
                //SumUnits = generations.Sum(x => x.Units),
                //CurrentUnitPrice = GetCurrentOfferPrice(1)
            };
        }

        private IEnumerable<StatementGeneration> DeriveVoluntaryRecords(ICollection<Contribution> contributions)
        {
            var vc = new List<StatementGeneration>();

            foreach (var s in contributions)
            {
                if (s.OtherContribution > 0 || s.Withdrawal > 0)
                {
                    vc.Add(new StatementGeneration()
                    {
                        ValueDate = s.ValueDate ?? DateTime.Today,
                        Employee = s.OtherContribution ?? 0.0,
                        Employer = 0.00,
                        Fees = 0.00,
                        Vat = 0.00,
                        NetContribution = s.OtherContribution ?? 0.0,
                        Withdrawal = s.Withdrawal ?? 0.0,
                        Price = s.Price ?? 0,
                        Units = ((s.OtherContribution ?? 0.0) - ((s.TotalFee ?? 0.0) + ((s.TotalFee ?? 0.0) * .05))) / (double)s.Price
                    });
                }
            }

            return vc;
        }

        private static IEnumerable<StatementGeneration> DeriveRecords(IEnumerable<Contribution> contributions)
        {
            return contributions.Select(x => new StatementGeneration()
            {
                ValueDate = x.ValueDate ?? DateTime.Today,
                Employee = x.EmployeeContribution ?? 0,
                Employer = x.EmployerContribution ?? 0,
                Fees = x.TotalFee ?? 0.0,
                Vat = (x.TotalFee ?? 0.0) * .05,
                NetContribution = ((x.EmployeeContribution ?? 0) + (x.EmployerContribution ?? 0)) - ((x.TotalFee ?? 0.0) + ((x.TotalFee ?? 0.0) * .05)),
                Withdrawal = x.Withdrawal ?? 0.0,
                Price = x.Price ?? 0,
                Units = ((x.EmployeeContribution ?? 0 + x.EmployerContribution ?? 0) - ((x.TotalFee ?? 0.0) + ((x.TotalFee ?? 0.0) * .05))) / (double)x.Price
            }).ToList();
        }

        public List<RsaRetiree> FundForWeb()
        {
            var fund1 = GetFundValue(10000175, "RSA Fund I");
            var fund2 = GetFundValue(1, "RSA Fund II");
            var fund3 = GetFundValue(10000176, "PAL RSA Fund III"); // 
            var fund4 = GetFundValue(10000053, "PAL RSA Fund IV"); //
            var fund5 = GetFundValue(10000188, "PAL RSA Fund V"); //
            var offer = new List<RsaRetiree> { fund1, fund2, fund3, fund4, fund5 };

            return offer;
        }

        public List<RsaRetiree> JsonRsaForWeb()
        {
            var offer = new List<RsaRetiree> { GetRetireeFund(), GetFundOfferPrice() };

            return offer;
        }

        private AccountSummary GetValuationSummary(AccountSummary values, List<Contribution> list)
        {
            values.TotalAvcvat = GetTotalVatFee(list);
            values.TotalVat = values.TotalVat - values.TotalAvcvat;
            values.TotalUnits = values.TotalUnitsR + values.TotalUnitsV;
            values.TotalAvcStr = values.TotalAvc - values.TotalAvcFee - (double)values.TotalAvcvat;
            values.TotalWithdrawalStr = (double)(values.TotalAvcWithdrawal + values.TotalWithdrawal);
            values.TotalMandatoryStr = (values.TotalMandatory - values.TotalFee - (double)values.TotalVat);
            values.TotalAmountContributedStr = ((values.TotalMandatory - values.TotalFee - (double)values.TotalVat) + (values.TotalAvc - values.TotalAvcFee - (double)values.TotalAvcvat));

            values.UnitPrice = GetUnitPrice("R");

            values.CurrentValueRsaStr = (double)((double)values.TotalUnitsR * values.UnitPrice);
            values.CurrentValueAvcStr = (double)((double)values.TotalUnitsV * values.UnitPrice);
            values.CurrentValueStr = (double)(((double)values.TotalUnitsR * values.UnitPrice) + ((double)values.TotalUnitsV * values.UnitPrice));

            values.BalBeforeWithdrawalRsaStr = (double)(((double)values.TotalUnitsR * values.UnitPrice) - values.TotalWithdrawal);
            values.BalBeforeWithdrawalAvcStr = (double)(((double)values.TotalUnitsV * values.UnitPrice) - values.TotalAvcWithdrawal);
            values.BalBeforeWithdrawalStr = (double)(((double)values.TotalUnitsR * values.UnitPrice) - values.TotalWithdrawal) + (double)(((double)values.TotalUnitsV * values.UnitPrice) - values.TotalWithdrawal);

            values.IncomeRsaStr = (double)(((double)values.TotalUnitsR * values.UnitPrice) - values.TotalWithdrawal) -
                                  (values.TotalMandatory - values.TotalFee - (double)values.TotalVat);
            values.IncomeAvcStr = (double)(((double)values.TotalUnitsR * values.UnitPrice) - values.TotalAvcWithdrawal) -
                                  (values.TotalAvc - values.TotalAvcFee - (double)values.TotalAvcvat);
            values.IncomeStr = (double)(((double)values.TotalUnitsR * values.UnitPrice) - values.TotalWithdrawal) -
                                  (values.TotalMandatory - values.TotalFee - (double)values.TotalVat) + (double)(((double)values.TotalUnitsR * values.UnitPrice) - values.TotalAvcWithdrawal) -
                                  (values.TotalAvc - values.TotalAvcFee - (double)values.TotalAvcvat);

            return values;
        }

        private double? GetUnitPrice(string type)
        {
            var offer = _db.Shemes.SingleOrDefault(x => x.SCHEME_ID == 1);
            return offer.OFFER_PRICE;
        }

        public void SaveSupportDetails(Support model)
        {
            var x = new SupportLog
            {
                CategoryId = model.Category,
                DateSubmitted = DateTime.Now,
                Pin = model.Pin,
                Summary = model.Summary,
                Explanation = model.Explanation
            };

            _db.SupportLogs.Add(x);
            _db.SaveChanges();
        }

        private decimal GetTotalVatFee(List<Contribution> list)
        {
            return list.Where(x => x.OtherFee > 0).Sum(x => x.VatFee ?? 0);
        }

        public IEnumerable<Status> GetStatus()
        {
            return _db.Status.ToList();
        }

        public IEnumerable<SecretQuestionsStore> GetQuestions()
        {
            return _db.SecretQuestionsStores.ToList();
        }

        public IEnumerable<BenefitApplication> GetAllSubmittedApplications()
        {
            return _db.BenefitApplications.Where(x => x.Status1.StatusValue != "Not Complete").ToList();
        }

        public string ReturnAdminEmail()
        {
            return _db.UserProfiles.Where(x => x.UserName == "admin").Select(x => x.Email).FirstOrDefault();
        }

        public bool UploadProfileChangeForConfirmation(EmployeeViewModel model)
        {
            var x = new TempCustomerInformation
            {
                pin = model.Pin,
                email = model.Email,
                mobile_number = model.MobileNumber,
                mobile_number2 = model.MobileNumber2,
                name = model.FullName,
                EmployerCode = model.EmployerDetail.Recno,
                EmployerName = model.EmployerDetail.EmployerName,
                City = model.City,
                //CountryOfResidanceId = model.CountryOfResidanceId,
                CountryCode = model.CountryCode,
                IsNigerian = model.IsNigerian,
                status = "Pending",
                date_created = DateTime.Now,
                Createdby = model.Pin,
                Portal = "RSA Portal"
            };

            _db.TempCustomerInformations.Add(x);
            _db.SaveChanges();
            return true;
        }

        private AccountSummary CalculateTotalAmountContributed(List<Contribution> list)
        {

            var a = new AccountSummary
            {
                TotalUnitsR = list.Sum(x => x.TransUnitsR ?? 0),
                TotalUnitsV = list.Sum(x => x.TransUnitsV ?? 0),
                Eecont = list.Sum(x => x.EmployeeContribution ?? 0),
                Ercont = list.Sum(x => x.EmployerContribution ?? 0),
                TotalAvc = list.Sum(x => x.OtherContribution ?? 0),
                TotalFee = list.Sum(x => x.TotalFee ?? 0),
                TotalAvcFee = list.Sum(x => x.OtherFee ?? 0),
                TotalVat = list.Sum(x => x.VatFee ?? 0),
                TotalWithdrawal = list.Sum(x => x.Withdrawal),
                TotalAvcWithdrawal = list.Sum(x => x.WithdrawalVc)
            };

            a.TotalMandatory = a.Eecont + a.Ercont;

            return a;
        }

        public void SetAsRead(string pin, int pubId)
        {
            var x = new UserPublication
            {
                EmployeePin = pin,
                PublicationsId = pubId
            };

            _db.UserPublications.Add(x);
            _db.SaveChanges();
        }

        public string UpdateStatus(int statusId, int benefitId, string description)
        {
            var x = _db.BenefitApplications.Find(benefitId);
            x.Status = statusId;
            x.Description = description;
            x.DateModified = DateTime.Now;
            _db.SaveChanges();
            return "Done";
        }

        public Employee GetEmployeeTransactions(string pin)
        {
            return _db.Employees.Find(pin);
        }

        public EmployeeViewModel GetProfile(string pin)
        {
            var x = _db.Employees.Find(pin);
            return new EmployeeViewModel
            {
                Pin = x.Pin,
                RegistrationCode = x.RegistrationCode,
                FirstName = x.FirstName,
                Surname = x.Surname,
                OtherNames = x.OtherNames,
                Gender = x.Gender,
                DateOfBirth = x.DateOfBirth,
                MobileNumber = x.MobileNumber,
                MobileNumber2 = x.MobileNumber2,
                Email = x.Email,
                Employer_Recno = x.Employer_Recno,
                HomeAddress = x.HomeAddress,
                StreetName = x.StreetName,
                HouseNo = x.HouseNo,
                IsNigerian = x.IsNigerian == null || x.IsNigerian == false ? false : true,
                PermanentAddress = x.PermanentAddress,
                NextOfKins = x.NextOfKins.ToList(),
                EmployerDetail = x.EmployerDetail,
                FullName = x.Surname + " " + x.FirstName + " " + x.OtherNames,    //Added by Tunde
                CountryCode = x.CountryCode,
                StateCode = x.StateCode,
                lgaCode = x.LGACode,
                Account_Officer_Email = x.Account_Officer_Email,
                Account_Officer = x.Account_Officer,
                Account_Officer_Mobile = x.Account_Officer_Mobile
            };
        }




        //Added by Tunde
        public BenefitProcess GetBenefitApplication(long? id)
        {
            return _db.BenefitProcesses.FirstOrDefault(x => x.Id == id);
        }

        public BenefitProcessViewModel GetBenefit(string pin)
        {
            var x = _db.Employees.Find(pin);
            return new BenefitProcessViewModel
            {
                EmployeeId = x.EmployeeId,
                Pin = x.Pin,
                RegistrationCode = x.RegistrationCode,
                FirstName = x.FirstName,
                Surname = x.Surname,
                OtherNames = x.OtherNames,
                Gender = x.Gender,
                DateOfBirth = x.DateOfBirth,
                MobileNumber = x.MobileNumber,
                MobileNumber2 = x.MobileNumber2,
                Email = x.Email,
                Employer_Recno = x.Employer_Recno,
                HomeAddress = x.HomeAddress,
                PermanentAddress = x.PermanentAddress,
                NextOfKins = x.NextOfKins.ToList(),
                EmployerDetail = x.EmployerDetail
            };
        }


        public Employee GetFullProfile(string pin)
        {
            return _db.Employees.Find(pin);
        }

        public bool UpdateProfile(EmployeeViewModel model)
        {
            var x = _db.Employees.Find(model.Pin);
            x.Pin = model.Pin;
            x.RegistrationCode = model.RegistrationCode;
            x.FirstName = model.FirstName;
            x.Surname = model.Surname;
            x.OtherNames = model.OtherNames;
            x.Gender = model.Gender;
            x.DateOfBirth = model.DateOfBirth;
            x.MobileNumber = model.MobileNumber;
            x.MobileNumber2 = model.MobileNumber2;
            x.Email = model.Email;
            x.Employer_Recno = model.Employer_Recno;
            x.HomeAddress = model.HomeAddress;
            x.PermanentAddress = model.PermanentAddress;
            x.NextOfKins = model.NextOfKins.ToList();
            _db.SaveChanges();
            return true;
        }

        public bool HasBeenRead(string pin, int publicationsId)
        {
            return _db.UserPublications.Count(x => x.EmployeePin == pin && x.PublicationsId == publicationsId) == 0;
        }

        public int GetTotalUnread(string pin)
        {
            var read = _db.UserPublications.Count(x => x.EmployeePin == pin);
            var allPublications = _db.Publications.Count();

            if (allPublications > read) return allPublications - read;
            return 0;
        }

        public IEnumerable<AccountManager> GetAllManager()
        {
            return _db.AccountManagers.ToList();
        }

        public string CreateManager(AccountManager model)
        {
            if (ManagerNameExists(model.AccountManagers)) return "exists";
            _db.AccountManagers.Add(model);
            _db.SaveChanges();
            return "success";
        }

        private bool ManagerNameExists(string accountManagers)
        {
            return _db.AccountManagers.Count(x => x.AccountManagers == accountManagers) > 0;
        }

        public void SavePublicationInformation(UploadPublications model)
        {
            var x = new Publication
            {
                DateUploaded = DateTime.Now,
                Extension = Path.GetExtension(model.Doc.FileName),
                PublicationName = model.DocName,
                UploadTypeId = model.UploadType
            };

            _db.Publications.Add(x);
            _db.SaveChanges();
        }

        public AccountManager GetManagerInfo(int id)
        {
            return _db.AccountManagers.SingleOrDefault(x => x.ManagerId == id);
        }

        public string UpdateManagerInfo(AccountManager model)
        {
            var x = _db.AccountManagers.Find(model.ManagerId);
            x.AccountManagers = model.AccountManagers;
            x.Region = model.Region;
            x.Phonenumber = model.Phonenumber;
            x.EMAIL = model.EMAIL;

            _db.SaveChanges();
            return "success";
        }

        public IEnumerable<AssetType> GetAssetTypes()
        {
            return _db.AssetTypes.ToList();
        }

        public void UploadPublicationDocument(UploadPublications model)
        {
            SaveDocument(HostingEnvironment.MapPath(PublicationPath + model.DocName + Path.GetExtension(model.Doc.FileName)), model.Doc);
        }

        public bool SaveFileToDb(string path, int type)
        {
            var strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            var excelConnString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Extended Properties=\"Excel 12.0\"";
            //Create Connection to Excel work book 
            using (OleDbConnection excelConnection = new OleDbConnection(excelConnString))
            {
                //Create OleDbCommand to fetch data from Excel 
                using (OleDbCommand cmd = new OleDbCommand("Select [date_created],[equity],[fixed_income],[money_market],[others] from [Sheet1$]", excelConnection))
                {
                    excelConnection.Open();
                    using (OleDbDataReader dReader = cmd.ExecuteReader())
                    {
                        while (dReader != null && dReader.Read())
                        {
                            try
                            {
                                if (dReader.GetValue(0) == DBNull.Value) break;
                                CreatePalValueFund(Convert.ToDateTime(dReader.GetValue(0)),
                                    Convert.ToDouble(dReader.GetValue(1)), Convert.ToDouble(dReader.GetValue(2)),
                                    Convert.ToDouble(dReader.GetValue(3)), Convert.ToDouble(dReader.GetValue(4)), type);
                            }
                            catch (Exception ex)
                            {
                                if (_error != null)
                                    File.WriteAllText(HostingEnvironment.MapPath(_error), ex.Message + ex.InnerException);
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
        }

        public IEnumerable<AssetAllocation> GetAssetAllocations()
        {
            return _db.AssetAllocations.OrderByDescending(x => x.date_created).ToList();
        }

        private void CreatePalValueFund(DateTime dateCreated, double equity, double fixedIncome, double moneyMarket, double others, int type)
        {
            //var date = DateTime.ParseExact(dateCreated, @"MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var x = new AssetAllocation
            {
                date_created = dateCreated,
                equity = equity,
                fixed_income = fixedIncome,
                money_market = moneyMarket,
                others = (type == 1) ? others : 0,
                asset_allocation_type = type
            };

            _db.AssetAllocations.Add(x);
            _db.SaveChanges();
        }

        public bool NameAlreadyExists(string docName)
        {
            return _db.Publications.Count(x => x.PublicationName == docName) > 0;
        }

        public IEnumerable<UploadType> GetUploadType()
        {
            return _db.UploadTypes.ToList();
        }

        public bool UpdateEmployeeManager(string pin, int managerId)
        {
            var x = _db.Employees.Find(pin);
            x.ManagerId = managerId;
            _db.SaveChanges();
            return true;
        }

        public IEnumerable<Publication> GetAllNewsLetters()
        {
            return _db.Publications.Where(x => x.UploadType.UploadTypeValue == "News Letter").ToList();
        }

        public IEnumerable<Publication> GetAllContributionHistory()
        {
            return _db.Publications.Where(x => x.UploadType.UploadTypeValue == "Contribution History").ToList();
        }

        public bool CheckStatus(int? status)
        {
            var x = _db.Status.Find(status);
            return x.StatusValue == "Not Complete";
        }

        public IEnumerable<Contribution> GetReportObject(string pin)
        {
            return _db.Contributions.Where(x => x.Pin == pin).ToList();
        }

        public IEnumerable<Contribution> GetReportQuery(IEnumerable<Contribution> report, DateTime? startDate, DateTime? endDate)
        {
            if (startDate.HasValue && startDate.Value > DateTime.MinValue)
                report = report.Where(r => r.ContributionDate >= startDate.Value.Date).ToList();

            if (endDate.HasValue && endDate.Value > DateTime.MinValue)
                report = report.Where(r => r.ContributionDate <= endDate.Value.Date).ToList();

            return report;
        }

        public string GetSubClassName(int appSubClassId)
        {
            var s =
                _db.BenefitSubClasses.Where(x => x.BenefitSubClassId == appSubClassId)
                    .Select(x => x.BenefitSubClassValue)
                    .FirstOrDefault();
            return s;
        }



        public ICollection<Employee> GetAllClients()
        {
            return _db.Employees.ToList();
        }

        public IEnumerable<BenefitClass> GetBenefitClasses()
        {
            //return _db.BenefitClasses.ToList();
            return _db.BenefitClasses.Where(c => c.Active == true).ToList();
        }

        //public ICollection<BenefitSubClass> GetSubClasses(int id)
        //{
        //    return _db.BenefitSubClasses.Where(x => x.BenefitClassId == id).OrderBy(x => x.BenefitSubClassValue).ToList();
        //}

        public ICollection<BenefitSubClass> GetSubClasses(int id, int id1)
        {
            return _db.BenefitSubClasses.Where(x => x.BenefitClassId == id || x.BenefitClassId == id1).OrderBy(x => x.BenefitSubClassValue).ToList();
        }

        public IEnumerable<BenefitApplication> GetAllUserBenefitApplications(string pin)
        {
            return _db.BenefitApplications.Where(x => x.Employee_Pin == pin).ToList();
        }

        public string GetEmployeePin(string name)
        {
            return _db.UserProfiles.Where(x => x.UserName == name).Select(x => x.Employee_Pin).FirstOrDefault();
        }


        public void MarkPublicationAsRead(string pin, int id)
        {
            var x = new UserPublication
            {
                EmployeePin = pin,
                PublicationsId = id
            };

            _db.UserPublications.Add(x);
            _db.SaveChanges();
        }

        private string GetEmployeePin(int id)
        {
            return _db.UserProfiles.Where(x => x.UserId == id).Select(x => x.Employee_Pin).FirstOrDefault();
        }

        public int? GetBenefitClasses(int id)
        {
            return
                _db.BenefitSubClasses.Where(x => x.BenefitSubClassId == id)
                    .Select(x => x.BenefitClassId)
                    .FirstOrDefault();
        }

        public bool CheckIfApplicationHasAlreadyStarted(string employeePin, int? benefitSubClass)
        {
            var pr =
                _db.BenefitApplications.FirstOrDefault(
                    x => x.Employee_Pin == employeePin && x.BenefitSubClassId == benefitSubClass) != null;

            return pr;
        }

        public void CreateFolder(string documentId)
        {
            var path = HostingEnvironment.MapPath(DocPath + documentId);
            var thumbPath = HostingEnvironment.MapPath(DocPathThumb + documentId);

            if (path != null && !Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (thumbPath != null && !Directory.Exists(thumbPath))
                Directory.CreateDirectory(thumbPath);
        }

        public void CreateFolder(string documentId, string storePath, string storePathThumb)
        {
            var path = HostingEnvironment.MapPath(storePath + documentId);
            var thumbPath = HostingEnvironment.MapPath(storePathThumb + documentId);

            if (path != null && !Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (thumbPath != null && !Directory.Exists(thumbPath))
                Directory.CreateDirectory(thumbPath);
        }

        public int GetStatusId(string status)
        {
            return _db.Status.Where(x => x.StatusValue == status).Select(x => x.StatusId).FirstOrDefault();
        }

        public string GetStatusValue(int? status)
        {
            return _db.Status.Where(x => x.StatusId == status).Select(x => x.StatusValue).FirstOrDefault();
        }

        public void DeclareVariables(int applicationId, int benefitId)
        {
            switch (benefitId)
            {
                case 1:
                    CreateLumpsumProgrammedVariables(applicationId);
                    break;
                case 2:
                    CreateLumpsumAnnuityVariables(applicationId);
                    break;
                case 3:
                    CreateEnblocVariables(applicationId);
                    break;
                case 4:
                    CreateNsitfVariables(applicationId);
                    break;
                case 5:
                    CreateLegacyVariables(applicationId);
                    break;
                case 6:
                    CreateAvcVariables(applicationId);
                    break;
                case 7:
                    CreateDeathVariables(applicationId);
                    break;
                case 8:
                    CreateTempAccessVariables(applicationId);
                    break;
            }
        }

        private void CreateEnblocVariables(int applicationId)
        {
            SaveDocumentInformation("PassportPhoto", applicationId);
            SaveDocumentInformation("BirthCertificate", applicationId);
            SaveDocumentInformation("BankDetails", applicationId);
            SaveDocumentInformation("RetireeDetailForm", applicationId);
            SaveDocumentInformation("ExitLetter", applicationId);
            SaveDocumentInformation("MeansOfId", applicationId);
        }

        private void CreateLumpsumProgrammedVariables(int applicationId)
        {
            SaveDocumentInformation("PassportPhoto", applicationId);
            SaveDocumentInformation("BirthCertificate", applicationId);
            SaveDocumentInformation("BankDetails", applicationId);
            SaveDocumentInformation("RetireeDetailForm", applicationId);
            SaveDocumentInformation("ExitLetter", applicationId);
            SaveDocumentInformation("Payslip", applicationId);
            SaveDocumentInformation("BondSlip", applicationId);
            SaveDocumentInformation("MeansOfId", applicationId);
            SaveDocumentInformation("IndemnityFormAndPrgrammedAgreement", applicationId);
        }

        private void CreateTempAccessVariables(int applicationId)
        {
            SaveDocumentInformation("PassportPhoto", applicationId);
            SaveDocumentInformation("BirthCertificate", applicationId);
            SaveDocumentInformation("BankDetails", applicationId);
            SaveDocumentInformation("RetireeDetailForm", applicationId);
            SaveDocumentInformation("ExitLetter", applicationId);
            SaveDocumentInformation("Payslip", applicationId);
            SaveDocumentInformation("RequestLetter", applicationId);
            SaveDocumentInformation("MeansOfId", applicationId);
        }

        private void CreateLumpsumAnnuityVariables(int applicationId)
        {
            SaveDocumentInformation("PassportPhoto", applicationId);
            SaveDocumentInformation("BirthCertificate", applicationId);
            SaveDocumentInformation("BankDetails", applicationId);
            SaveDocumentInformation("RetireeDetailForm", applicationId);
            SaveDocumentInformation("ExitLetter", applicationId);
            SaveDocumentInformation("Payslip", applicationId);
            SaveDocumentInformation("BondSlip", applicationId);
            SaveDocumentInformation("MeansOfId", applicationId);
            SaveDocumentInformation("IndemnityFormAndPrgrammedAgreement", applicationId);
            SaveDocumentInformation("ProvisionalLifeAnnuityAgreement", applicationId);
        }

        private void CreateNsitfVariables(int applicationId)
        {
            SaveDocumentInformation("NsitfStatement", applicationId);
            SaveDocumentInformation("MeansOfId", applicationId);
            SaveDocumentInformation("PalNsitfForm", applicationId);
        }

        private void CreateLegacyVariables(int applicationId)
        {
            SaveDocumentInformation("RequestLetter", applicationId);
            SaveDocumentInformation("MeansOfId", applicationId);
            SaveDocumentInformation("BankDetails", applicationId);
        }

        private void CreateAvcVariables(int applicationId)
        {
            SaveDocumentInformation("PassportPhoto", applicationId);
            SaveDocumentInformation("MeansOfId", applicationId);
            SaveDocumentInformation("AvcRequestLetter", applicationId);
            SaveDocumentInformation("TaxIdentificationNumber", applicationId);
            SaveDocumentInformation("BankStatement", applicationId);
        }

        private void CreateDeathVariables(int applicationId)
        {
            SaveDocumentInformation("PalDeathNotificationForm", applicationId);
            SaveDocumentInformation("PassportPhoto", applicationId);
            SaveDocumentInformation("LetterOfFirstAppointment", applicationId);
            SaveDocumentInformation("DeseasedAgeDeclarationBirthCertificate", applicationId);
            SaveDocumentInformation("LastPaySlipBeforeDemise", applicationId);
            SaveDocumentInformation("PaySlipAsAtJune2004", applicationId);
            SaveDocumentInformation("LetterOfIntroducttion", applicationId);
            SaveDocumentInformation("AttachedPENCOM", applicationId);
            SaveDocumentInformation("DeathCertificate", applicationId);
            SaveDocumentInformation("AttachedNok", applicationId);
            SaveDocumentInformation("DeclarationOfNok", applicationId);
            SaveDocumentInformation("LetterFromEmployer", applicationId);
            SaveDocumentInformation("PersonalAccount", applicationId);
            SaveDocumentInformation("BankersConfirmation", applicationId);
            SaveDocumentInformation("NOKAdministratorsID", applicationId);
            SaveDocumentInformation("PrivateSectoreInsurance", applicationId);
            SaveDocumentInformation("DeathCertification", applicationId);
            SaveDocumentInformation("LetterOrWill", applicationId);
        }

        public string SaveExcelInTempDir(AssetAllocationsUpload doc)
        {
            var path = HostingEnvironment.MapPath(TempExcelPath + doc.AssetAllocation.FileName);
            SaveDocument(path, doc.AssetAllocation);
            return path;
        }

        public void SaveImageToFolder(int applicationId, HttpPostedFile doc, string filename, string thumbPath)
        {
            var documentId = GetDocumentId(applicationId);
            var extension = Path.GetExtension(doc.FileName);

            SaveDocument(HostingEnvironment.MapPath(DocPath + documentId + "/" + filename + extension), doc);
            PictureFileUploader.UploadPhotoLogo(doc.InputStream, extension, filename, documentId, thumbPath + documentId + "/");
        }

        public void SaveToFolder(string documentId, string uploadName, string path, HttpPostedFileBase doc1, string thumbPath)
        {
            var extension = Path.GetExtension(doc1.FileName);
            SaveDocument(HostingEnvironment.MapPath(path + documentId + "/" + uploadName + extension), doc1);
            PictureFileUploader.UploadPhotoLogo(doc1.InputStream, extension, uploadName, documentId, thumbPath + documentId + "/");
        }

        public void SaveToFolder(string documentId, string uploadName, string path, HttpPostedFile doc1, string thumbPath)
        {
            var extension = Path.GetExtension(doc1.FileName);
            SaveDocument(HostingEnvironment.MapPath(path + documentId + "/" + uploadName + extension), doc1);
            PictureFileUploader.UploadPhotoLogo(doc1.InputStream, extension, uploadName, documentId, thumbPath + documentId + "/");
        }

        private void SaveDocument(string path, HttpPostedFile doc)
        {
            IfFileDelete(path);
            if (path != null) doc.SaveAs(path);
        }

        private void SaveDocument(string path, HttpPostedFileBase doc)
        {
            IfFileDelete(path);
            if (path != null) doc.SaveAs(path);
        }

        public void UpdateDocumentInformation(string filename, string ext, int appId)
        {
            var x = _db.EmployeeBenefitDocuments.Find(GetBenefitDocumentId(filename, appId));
            x.Filename = filename;
            x.DateUploaded = DateTime.Now;
            x.ext = ext;

            _db.SaveChanges();
        }

        private int GetBenefitDocumentId(string filename, int appId)
        {
            return
                _db.EmployeeBenefitDocuments.Where(x => x.BenefitApplicationId == appId && x.Filename == filename)
                    .Select(x => x.Id)
                    .FirstOrDefault();
        }

        private string GetDocumentId(int applicationId)
        {
            return _db.BenefitApplications.Where(x => x.BenefitApplicationId == applicationId).Select(x => x.DocumentId).FirstOrDefault();
        }

        public BenefitApplication GetApplicationInformation(int id)
        {
            return _db.BenefitApplications.Find(id);
        }

        private void SaveDocumentInformation(string filename, int applicationId)
        {
            var x = new EmployeeBenefitDocument
            {
                BenefitApplicationId = applicationId,
                Filename = filename
            };

            _db.EmployeeBenefitDocuments.Add(x);
            _db.SaveChanges();
        }

        private static void IfFileDelete(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        private static string CreateNewGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public string CreateNewDocumentId()
        {
            var id = CreateNewGuid();
            if (_db.BenefitApplications.Count(x => x.DocumentId == id) > 0) CreateNewDocumentId();
            return id;
        }

        public int CreateNewBenefitApplication(string name, int benefitId, int status, DateTime now, string documentId)
        {
            var x = new BenefitApplication
            {
                Employee_Pin = GetEmployeePin(name),
                BenefitSubClassId = benefitId,
                Status = status,
                DateApplied = now,
                DocumentId = documentId
            };

            _db.BenefitApplications.Add(x);
            _db.SaveChanges();
            return x.BenefitApplicationId;
        }

        public Mailer CreateEmailVariables(int id, int user)
        {
            var pin = GetEmployeePin(user);
            var info = _db.Employees.FirstOrDefault(x => x.Pin == pin);
            var appType = GetSubClassName(GetSubclassId(id));

            if (info == null) return null;
            return new Mailer { Name = info.FirstName + ' ' + info.Surname, Email = info.Email, ApplicationType = appType };
        }

        public Mailer CreateEmailVariablesForStatusUpdate(int id, string pin, int status)
        {
            var info = _db.Employees.FirstOrDefault(x => x.Pin == pin);
            var appType = GetSubClassName(GetSubclassId(id));
            var statusName = GetStatusValue(status);

            if (info == null) return null;
            return new Mailer { Name = info.FirstName + ' ' + info.Surname, Email = info.Email, ApplicationType = appType, Status = statusName };
        }

        public void FinializeApplication(int id)
        {
            var x = _db.BenefitApplications.Find(id);
            x.Status = GetStatusId("Submitted");
            x.DateApplied = DateTime.Now;

            _db.SaveChanges();
        }

        private int GetSubclassId(int id)
        {
            var b =
                _db.BenefitApplications.Where(x => x.BenefitApplicationId == id)
                    .Select(x => x.BenefitSubClassId)
                    .FirstOrDefault();
            return b;
        }

        public object GetAllPublications()
        {
            return _db.Publications.Include("UploadType").ToList();
        }

        public ChangeOfName GetProfileForChangeOfName(string employeePin)
        {
            var x = _db.Employees.Find(employeePin);
            return new ChangeOfName { Pin = x.Pin, OldName = x.Surname, Sex = x.Gender, OldFirstName = x.FirstName, OldMiddleName = x.OtherNames };
        }

        public ChangeOfNameProfile GetChangeOfNameDetails(int id)
        {
            return _db.ChangeOfNameProfiles.Find(id);
        }

        public void NameChangeStatus(int id, string approved)
        {
            var x = _db.ChangeOfNameProfiles.Find(id);
            x.Status = approved;

            _db.SaveChanges();
        }

        public string GetEmployeeEmail(string pin)
        {
            return _db.Employees.Where(x => x.Pin == pin).Select(x => x.Email).FirstOrDefault();
        }

        public string GetEmploteeFullName(string pin)
        {
            return _db.Employees.Where(x => x.Pin == pin).Select(x => x.FirstName + " " + x.Surname).FirstOrDefault();
        }

        public void SaveChangeOfAddressDetails(ChangeOfAddress model, string documentId)
        {
            var x = new ChangeOfAddressProfile
            {
                Pin = model.Pin,
                OldAddress = model.OldAddress,
                NewAddress = model.NewAddress,
                Status = "Pending",
                DateUploaded = DateTime.Now,
                DocumentId = documentId,
                Doc = "Utility Bill",
                Ext = Path.GetExtension(model.UtilityBill.FileName)
            };

            _db.ChangeOfAddressProfiles.Add(x);
            _db.SaveChanges();
        }

        public List<ChangeOfAddressProfile> GetAllChangeOfAddress()
        {
            return _db.ChangeOfAddressProfiles.OrderByDescending(x => x.DateUploaded).ToList();
        }

        public List<ChangeOfAddressProfile> GetAllChangeOfAddress(string pin)
        {
            return _db.ChangeOfAddressProfiles.Where(x => x.Pin == pin).OrderByDescending(x => x.DateUploaded).ToList();
        }

        public ChangeOfAddressProfile GetChangeOfAddressDetails(int id)
        {
            return _db.ChangeOfAddressProfiles.Find(id);
        }

        public void AddressChangeStatus(int id, string approved)
        {
            var x = _db.ChangeOfAddressProfiles.Find(id);
            x.Status = approved;

            _db.SaveChanges();
        }

        public int GetAppSubClass(int applicationId)
        {
            return
                _db.BenefitApplications.Where(x => x.BenefitApplicationId == applicationId)
                    .Select(x => x.BenefitSubClassId)
                    .FirstOrDefault();
        }

        public List<SupportType> GetSupportType()
        {
            //return _db.SupportCategories.ToList();      //@Todo change to support type
            return _db.SupportTypes.ToList();
        }

        public string GetcategoryValue(int category)
        {
            return _db.SupportCategories.Where(x => x.Id == category).Select(x => x.Value).FirstOrDefault();
        }

        public void SaveQuestionInformation(int questionId, string questionAnswer, int userId)
        {
            var password = CreateNewGuid();
            var x = _db.UserProfiles.Find(userId);
            x.SecretQuestionId = questionId;
            x.QuestionKey = password;
            x.SecretQuestionAnswer = StringCipher.Encrypt(questionAnswer, password);

            _db.SaveChanges();
        }

        public IEnumerable<Contribution> GetContributions(string rsaPin, decimal? fundId)
        {
            var contributions = _db.Contributions.Where(x => x.Pin == rsaPin && x.FundId == fundId && (x.TransUnitsR != 0 || x.TransUnitsV != 0)).OrderByDescending(d => d.ValueDate).ToList();
            // && x.Interfund == false
            return contributions;
        }

        public EmployeeReportSummation EmployeeReportSummationMethod(Employee emp, decimal? scheme, DateTime? date)
        {
            var report = new EmployeeReportSummation();
            var contributions = _db.Contributions.Where(x => x.Pin == emp.Pin && x.FundId == scheme).OrderByDescending(d => d.ValueDate).ToList();
            var fundId = Convert.ToInt32(scheme); //get latest unit price
            var currentUnitPrice = GetCurrentOfferPrice(fundId, date);
            emp.Contributions = contributions;
            //if funded account
            if (emp.Contributions.Any())
            {
                foreach (var contribution in emp.Contributions)
                {
                    report.SumUnitsRsa += Convert.ToDecimal(contribution.TransUnitsR);
                    report.SumUnitsVc += Convert.ToDecimal(contribution.TransUnitsV);

                    //report.SumEmployee += Convert.ToDecimal(contribution.EmployeeContribution);
                    //report.SumEmployer += Convert.ToDecimal(contribution.EmployerContribution);

                    //report.SumAvc += Convert.ToDecimal(contribution.OtherContribution);

                    ////fees
                    //report.TotalFees += Convert.ToDecimal(contribution.TotalFee);
                    //report.OtherFee += Convert.ToDecimal(contribution.OtherFee);
                    //report.TotalVat += Convert.ToDecimal(contribution.VatFee);

                    //report.RsaWithdrawal += Convert.ToDecimal(contribution.Withdrawal);
                    //report.VcWithdrawal += Convert.ToDecimal(contribution.WithdrawalVc);
                    ////report.VcWithdrawal += Convert.ToDecimal(contribution.WithdrawalVc);

                    //report.NetContributionRsa += Convert.ToDecimal(contribution.EmployeeContribution) + Convert.ToDecimal(contribution.EmployerContribution);
                    //report.NetContributionVc += Convert.ToDecimal(contribution.OtherContribution);

                    //if (contribution.OtherFee > 0)
                    //{
                    //    report.AvcVat += Convert.ToDecimal(contribution.VatFee);
                    //}
                }
                //

                // var valueDate = new PalliteProcDataContext().FnLastValueDate(emp.FundId).Value;
                var valueDate = Convert.ToDateTime("2000-03-26");
                report.LastValueDate = valueDate;
                // Get aggregate 
                var contAgg = _db.GetContributionAggregate(emp.Pin).Single();
                report.SumAvc = Convert.ToDecimal(contAgg.TotalContributionV);
                report.SumEmployee = Convert.ToDecimal(contAgg.TotalContributionEE);
                report.SumEmployer = Convert.ToDecimal(contAgg.TotalContributionER);
                //

                //turn to absolute value of withdrawals
                report.RsaWithdrawal = Math.Abs(Convert.ToDecimal(contAgg.TotalWithdrawal)); // Math.Abs(report.RsaWithdrawal);
                report.VcWithdrawal = Math.Abs(Convert.ToDecimal(contAgg.TotalWithdrawalVC)); // Math.Abs(report.VcWithdrawal);
                                                                                              //
                report.NetContributionRsa = Convert.ToDecimal(report.SumEmployee) + Convert.ToDecimal(report.SumEmployer) - report.RsaWithdrawal + Convert.ToDecimal(contAgg.TotalFee);
                report.NetContributionVc = report.SumAvc - report.VcWithdrawal;  // Convert.ToDecimal(report.NetContributionVc);
                report.totalContribution = report.NetContributionRsa + report.NetContributionVc;

                //  report.TotalVat = report.TotalVat - report.AvcVat;
                var totalfee = Convert.ToDecimal(contAgg.TotalFee); //  report.TotalFees + report.OtherFee + report.TotalVat;
                report.NetContributionRsa = report.NetContributionRsa - report.TotalFees - report.TotalVat; //net contribution rsa
                report.NetContributionVc = report.NetContributionVc - report.OtherFee - report.AvcVat; //net contribution vc

                //report.totalContribution = report.SumEmployee + report.SumEmployer;
                //report.NetContributionRsa = Convert.ToDecimal(report.totalContribution);
                //report.NetContributionVc = Convert.ToDecimal(report.NetContributionVc);
                ////turn to absolute value of withdrawals
                //report.RsaWithdrawal = Math.Abs(report.RsaWithdrawal);
                //report.VcWithdrawal = Math.Abs(report.VcWithdrawal);


                //report.NetContributionRsa = report.NetContributionRsa - report.TotalFees - report.TotalVat; //net contribution rsa
                //report.NetContributionVc = report.NetContributionVc - report.OtherFee - report.AvcVat; //net contribution vc

                var currentValue = report.SumUnitsRsa * Convert.ToDecimal(currentUnitPrice);
                var vcCurrentValue = report.SumUnitsVc * Convert.ToDecimal(currentUnitPrice);

                report.RsaIncome = currentValue == 0 ? 0 : (currentValue - (report.NetContributionRsa)); // - report.RsaWithdrawal 
                report.VcIncome = (vcCurrentValue - (report.SumAvc));// - report.VcWithdrawal
                report.TotalIncome = report.RsaIncome + report.VcIncome;

                report.rsaBeforeWithdrawal = report.NetContributionRsa + report.RsaIncome;
                report.vcBeforeWithdrawal = report.NetContributionVc + report.VcIncome;
                report.totalBeforeWithdrawal = report.rsaBeforeWithdrawal + report.vcBeforeWithdrawal;
                report.TotalWithdrawal = report.RsaWithdrawal + report.VcWithdrawal;

                report.rsaBalance = report.SumUnitsRsa * currentUnitPrice;
                report.vcBalance = report.SumUnitsVc * currentUnitPrice;
                report.totalBalance = report.rsaBalance + report.vcBalance;

                report.totalContribution = report.NetContributionRsa + report.NetContributionVc;
                //report.TotalVat = report.TotalVat - report.AvcVat;
                //decimal totalcaont = report.SumEmployee + report.SumEmployer;
                //report.NetContribution = ((report.SumEmployee + report.SumEmployer -report.SumFees -report.SumVat)+ (report.SumAvc - report.SumOtherfee - report.SumVat));
                report.TotalUnits = report.SumUnitsRsa + report.SumUnitsVc;
                //report.Contributions = employee.Contributions;
                //report.Manager = employee.AccountManager;
                report.CurrentUnitPrice = currentUnitPrice;
            }

            return report;
        }

        public EmployeeReportSummation EmployeeReportSummationMethod(string pin, decimal? scheme, DateTime? date)
        {
            var report = new EmployeeReportSummation();
            var contributions = _db.Contributions.Where(x => x.Pin == pin && x.FundId == scheme).OrderByDescending(d => d.ValueDate).ToList();
            var fundId = Convert.ToInt32(scheme); //get latest unit price
            var currentUnitPrice = GetCurrentOfferPrice(fundId, date);

            //if funded account
            if (contributions.Any())
            {
                foreach (var contribution in contributions)
                {
                    report.SumUnitsRsa += Convert.ToDecimal(contribution.TransUnitsR);
                    report.SumUnitsVc += Convert.ToDecimal(contribution.TransUnitsV);

                }
                //var valueDate = new PalliteProcDataContext().FnLastValueDate(fundId).Value;     //2021-03-26 00:00:00.000
                var valueDate = Convert.ToDateTime("2000-03-26");
                report.LastValueDate = valueDate;
                // Get aggregate 
                var contAgg = _db.GetContributionAggregate(pin).Single();
                report.SumAvc = Convert.ToDecimal(contAgg.TotalContributionV);
                report.SumEmployee = Convert.ToDecimal(contAgg.TotalContributionEE);
                report.SumEmployer = Convert.ToDecimal(contAgg.TotalContributionER);
                //

                //turn to absolute value of withdrawals
                report.RsaWithdrawal = Math.Abs(Convert.ToDecimal(contAgg.TotalWithdrawal)); // Math.Abs(report.RsaWithdrawal);
                report.VcWithdrawal = Math.Abs(Convert.ToDecimal(contAgg.TotalWithdrawalVC)); // Math.Abs(report.VcWithdrawal);


                report.NetContributionRsa = Convert.ToDecimal(report.SumEmployee) + Convert.ToDecimal(report.SumEmployer) - report.RsaWithdrawal + Convert.ToDecimal(contAgg.TotalFee);
                report.NetContributionVc = report.SumAvc - report.VcWithdrawal;  // Convert.ToDecimal(report.NetContributionVc);
                report.totalContribution = report.NetContributionRsa + report.NetContributionVc;



                //  report.TotalVat = report.TotalVat - report.AvcVat;
                var totalfee = Convert.ToDecimal(contAgg.TotalFee); //  report.TotalFees + report.OtherFee + report.TotalVat;
                report.NetContributionRsa = report.NetContributionRsa - report.TotalFees - report.TotalVat; //net contribution rsa
                report.NetContributionVc = report.NetContributionVc - report.OtherFee - report.AvcVat; //net contribution vc

                var currentValue = report.SumUnitsRsa * Convert.ToDecimal(currentUnitPrice);
                var vcCurrentValue = report.SumUnitsVc * Convert.ToDecimal(currentUnitPrice);

                report.RsaIncome = currentValue == 0 ? 0 : (currentValue - report.NetContributionRsa);// - ( report.RsaWithdrawal));
                report.VcIncome = (vcCurrentValue - (report.SumAvc)); //  - report.VcWithdrawal
                report.TotalIncome = report.RsaIncome + report.VcIncome;

                report.rsaBeforeWithdrawal = report.NetContributionRsa + report.RsaIncome;
                report.vcBeforeWithdrawal = report.NetContributionVc + report.VcIncome;
                report.totalBeforeWithdrawal = report.rsaBeforeWithdrawal + report.vcBeforeWithdrawal;
                report.TotalWithdrawal = report.RsaWithdrawal + report.VcWithdrawal;

                report.rsaBalance = report.SumUnitsRsa * currentUnitPrice;
                report.vcBalance = report.SumUnitsVc * currentUnitPrice;
                report.totalBalance = report.rsaBalance + report.vcBalance;

                // report.totalContribution = report.NetContributionRsa + report.NetContributionVc + Convert.ToDecimal(contAgg.TotalFee);
                //report.TotalVat = report.TotalVat - report.AvcVat;
                //decimal totalcaont = report.SumEmployee + report.SumEmployer;
                //report.NetContribution = ((report.SumEmployee + report.SumEmployer -report.SumFees -report.SumVat)+ (report.SumAvc - report.SumOtherfee - report.SumVat));
                report.TotalUnits = report.SumUnitsRsa + report.SumUnitsVc;
                //report.Contributions = employee.Contributions;
                //report.Manager = employee.AccountManager;
                report.CurrentUnitPrice = currentUnitPrice;
            }

            return report;
        }


        public Int32 GetFunId(string pin)
        {
            PalliteProcDataContext proc = new PalliteProcDataContext();
            var fundId = _db.Employees.FirstOrDefault(d => d.Pin == pin).FundId;
            return Convert.ToInt32(fundId);
            /// return proc.GetFundId(pin).Value;
            // return _db.Employees.Where(x => x.Pin == pin).Select(x => x.FundId).FirstOrDefault();
        }
    }

    public static class PictureFileUploader
    {
        /// <summary>
        /// uploads the image to a location on the webserver and returns the new filename of the uploaded image
        /// </summary>
        /// <param name="imageBuffer">input stream for the image</param>
        /// <param name="fileExtension">file extension of uploaded image</param>
        /// <param name="fileName"></param>
        /// <param name="documentId"></param>
        /// <param name="thumbPath"></param>
        /// <returns>the Filename of the image</returns>
        public static void UploadPhotoLogo(Stream imageBuffer, string fileExtension, string fileName, string documentId, string thumbPath)
        {
            ResizeAndSave(thumbPath, fileName, imageBuffer, 300, true);
        }

        private static void ResizeAndSave(string savePath, string fileName, Stream imageBuffer, int maxSideSize, bool makeItSquare)
        {
            int newWidth;
            int newHeight;
            var image = Image.FromStream(imageBuffer);
            var oldWidth = image.Width;
            var oldHeight = image.Height;
            Bitmap newImage;
            if (makeItSquare)
            {
                var smallerSide = oldWidth >= oldHeight ? oldHeight : oldWidth;
                var coeficient = maxSideSize / (double)smallerSide;
                newWidth = Convert.ToInt32(coeficient * oldWidth);
                newHeight = Convert.ToInt32(coeficient * oldHeight);
                var tempImage = new Bitmap(image, newWidth, newHeight);
                var cropX = (newWidth - maxSideSize) / 2;
                var cropY = (newHeight - maxSideSize) / 2;
                newImage = new Bitmap(maxSideSize, maxSideSize);
                var tempGraphic = Graphics.FromImage(newImage);
                tempGraphic.SmoothingMode = SmoothingMode.AntiAlias;
                tempGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                tempGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                tempGraphic.DrawImage(tempImage, new Rectangle(0, 0, maxSideSize, maxSideSize), cropX, cropY, maxSideSize, maxSideSize, GraphicsUnit.Pixel);
            }
            else
            {
                var maxSide = oldWidth >= oldHeight ? oldWidth : oldHeight;
                if (maxSide > maxSideSize)
                {
                    var coeficient = maxSideSize / (double)maxSide;
                    newWidth = Convert.ToInt32(coeficient * oldWidth);
                    newHeight = Convert.ToInt32(coeficient * oldHeight);
                }
                else
                {
                    newWidth = oldWidth;
                    newHeight = oldHeight;
                }
                newImage = new Bitmap(image, newWidth, newHeight);
            }
            var path = HttpContext.Current.Server.MapPath(savePath);
            new Bitmap(newImage).Save(path + fileName + ".jpg", ImageFormat.Jpeg);

            image.Dispose();
            newImage.Dispose();
        }
    }

    public static class StringCipher
    {
        // This constant is used to determine the keysize of the encryption algorithm in bits.
        // We divide this by 8 within the code below to get the equivalent number of bytes.
        private const int Keysize = 256;

        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public static string Encrypt(string plainText, string passPhrase)
        {
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}
