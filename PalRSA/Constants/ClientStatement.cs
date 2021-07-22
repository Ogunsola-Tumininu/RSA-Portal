using PalRSA.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalRSA.Constants
{
    public class ClientStatement
    {
        private readonly Statement _statement = new Statement();


        public Statement GetClientStatement(string pin, string clientStatus, int fundid)
        //client status for either retiree or rsa contributor
        {


            using (var ctxt = new PALSiteDBEntities())
            {
                var contributions = ctxt.Contributions.Where(x => x.Pin == pin && x.FundId == fundid).ToList();
                var dd = ctxt.PriceHistories.Where(x => x.scheme_id == fundid).OrderByDescending(x => x.valuation_date).First();
                _statement.TotalCountributionCount = contributions.Count();
                var rsaUnitPrice = Convert.ToDecimal(dd.offer_price);
                //if (clientStatus == "Retiree")
                //{
                //    ctxt.PRICE_HISTORY.Where(x => x.SCHEME_ID == 10000073)
                //        .OrderByDescending(x => x.VALUATION_DATE)
                //        .First(); //10000073 is retiree unit price
                //}
                var asAt = DateTime.Now.Date.ToShortDateString();
                switch (fundid)
                {
                    case 1:
                        _statement.StatementHeader = "PAL RSA Fund II Account Summary as at " + asAt;
                        break;
                    case 10000175:
                        _statement.StatementHeader = "PAL RSA Fund I Account Summary as at " + asAt;
                        break;
                    case 10000176:
                        _statement.StatementHeader = "PAL RSA Fund III Account Summary as at " + asAt;
                        break;
                    case 10000053:
                        _statement.StatementHeader = "PAL RSA Fund IV (Retiree) Account Summary as at " + asAt;
                        break;
                    case 10000073:
                        _statement.StatementHeader = "Emenite Gratuity Account Summary as at " + asAt;
                        break;
                    case 10000093:
                        _statement.StatementHeader = "Guinness Gratuity Account Summary as at " + asAt;
                        break;
                }
                if (contributions.Any())
                {
                    foreach (var contribution in contributions)
                    {
                        _statement.Units += Convert.ToDecimal(contribution.TransUnitsR);
                        _statement.UnitsVc += Convert.ToDecimal(contribution.TransUnitsV);

                        _statement.EmployeeContribution += Convert.ToDecimal(contribution.EmployeeContribution);
                        _statement.EmployerContribution += Convert.ToDecimal(contribution.EmployerContribution);

                        _statement.TotalVc += Convert.ToDecimal(contribution.OtherContribution);

                        //fees
                        _statement.TotalFees += Convert.ToDecimal(contribution.TotalFee);
                        _statement.OtherFee += Convert.ToDecimal(contribution.OtherFee);
                        _statement.TotalVat += Convert.ToDecimal(contribution.VatFee);

                        _statement.Withdrawal += Convert.ToDecimal(contribution.Withdrawal);
                        _statement.WithdrawalVc += Convert.ToDecimal(contribution.WithdrawalVc);
                        //report.VcWithdrawal += Convert.ToDecimal(contribution.WithdrawalVc);

                        _statement.NetContribution += Convert.ToDecimal(contribution.EmployeeContribution + contribution.EmployerContribution);
                        _statement.NetContributionVc += Convert.ToDecimal(contribution.OtherContribution);

                        if (contribution.OtherFee > 0)
                        {
                            _statement.AvcVat += Convert.ToDecimal(contribution.VatFee);
                        }
                    }

                    //turn to absolute value of withdrawals
                    _statement.Withdrawal = Math.Abs(_statement.Withdrawal);
                    _statement.WithdrawalVc = Math.Abs(_statement.WithdrawalVc);

                    //  report.TotalVat = report.TotalVat - report.AvcVat;
                    var totalfee = _statement.TotalFees + _statement.OtherFee + _statement.TotalVat;
                    _statement.NetContribution = _statement.NetContribution - _statement.TotalFees - _statement.TotalVat;
                    //net contribution rsa
                    _statement.NetContributionVc = _statement.NetContributionVc - _statement.OtherFee - _statement.AvcVat;
                    //net contribution vc

                    var currentValue = _statement.Units * Convert.ToDecimal(rsaUnitPrice);
                    var vcCurrentValue = _statement.UnitsVc * Convert.ToDecimal(rsaUnitPrice);

                    _statement.Growth = (currentValue - (_statement.NetContribution - _statement.Withdrawal));
                    _statement.GrowthVc = (vcCurrentValue - (_statement.NetContributionVc - _statement.WithdrawalVc));
                    _statement.TotalGrowth = _statement.Growth + _statement.GrowthVc;

                    _statement.BalanceBeforeWithdrawal = _statement.NetContribution + _statement.Growth;
                    _statement.BalanceBeforeWithdrawalVc = _statement.NetContributionVc + _statement.GrowthVc;
                    _statement.TotalBalanceBeforeWithdrawal = _statement.BalanceBeforeWithdrawal +
                                                             _statement.BalanceBeforeWithdrawalVc;
                    _statement.TotalWithdrawal = _statement.Withdrawal + _statement.WithdrawalVc;

                    _statement.CurrentBalance = _statement.Units * rsaUnitPrice;
                    _statement.CurrentBalanceVc = _statement.UnitsVc * rsaUnitPrice;
                    _statement.TotalBalance = decimal.Round(_statement.CurrentBalance + _statement.CurrentBalanceVc, 2);

                    _statement.TotalNetContribution = decimal.Round(_statement.NetContribution + _statement.NetContributionVc, 2);
                    //report.TotalVat = report.TotalVat - report.AvcVat;
                    //decimal totalcaont = report.SumEmployee + report.SumEmployer;
                    //report.NetContribution = ((report.SumEmployee + report.SumEmployer -report.SumFees -report.SumVat)+ (report.SumAvc - report.SumOtherfee - report.SumVat));
                    _statement.TotalUnits = decimal.Round(_statement.Units + _statement.UnitsVc, 2);
                    //report.Contributions = employee.Contributions;
                    //report.Manager = employee.AccountManager;
                    _statement.UnitPrice = rsaUnitPrice;
                    _statement.ValueDate = dd.valuation_date.Value;
                }
                return _statement;
            }
        }
        public Statement GetClientStatement(string pin, string clientStatus, int fundid, DateTime startdate, DateTime endDate)
        //client status for either retiree or rsa contributor
        {


            using (var ctxt = new PALSiteDBEntities())
            {
                var contributions = ctxt.Contributions.Where(x => x.Pin == pin && x.FundId == fundid && x.ValueDate >= startdate && x.ValueDate <= endDate).ToList();
                var dd = ctxt.PriceHistories.Where(x => x.scheme_id == fundid && x.valuation_date <= endDate).FirstOrDefault();
                var rsaUnitPrice = Convert.ToDecimal(dd.offer_price);

                if (clientStatus == "Retiree")
                {
                    ctxt.PriceHistories.Where(x => x.scheme_id == 10000053)
                        .OrderByDescending(x => x.valuation_date)
                        .First(); //10000073 is retiree unit price
                }
                var asAt = endDate.ToShortDateString();
                switch (fundid)
                {
                    case 1:
                        _statement.StatementHeader = "PAL RSA Fund II Account Summary as at " + asAt;
                        break;
                    case 10000175:
                        _statement.StatementHeader = "PAL RSA Fund I Account Summary as at " + asAt;
                        break;
                    case 10000176:
                        _statement.StatementHeader = "PAL RSA Fund III Account Summary as at " + asAt;
                        break;
                    case 10000053:
                        _statement.StatementHeader = "PAL RSA Fund IV (Retiree) Account Summary as at " + asAt;
                        break;
                    case 10000073:
                        _statement.StatementHeader = "Emenite Gratuity Account Summary as at " + asAt;
                        break;
                    case 10000093:
                        _statement.StatementHeader = "Guinness Gratuity Account Summary as at " + asAt;
                        break;
                }
                if (contributions.Any())
                {
                    foreach (var contribution in contributions)
                    {
                        _statement.Units += Convert.ToDecimal(contribution.TransUnitsR);
                        _statement.UnitsVc += Convert.ToDecimal(contribution.TransUnitsV);

                        _statement.EmployeeContribution += Convert.ToDecimal(contribution.EmployeeContribution);
                        _statement.EmployerContribution += Convert.ToDecimal(contribution.EmployerContribution);

                        _statement.TotalVc += Convert.ToDecimal(contribution.OtherContribution);

                        //fees
                        _statement.TotalFees += Convert.ToDecimal(contribution.TotalFee);
                        _statement.OtherFee += Convert.ToDecimal(contribution.OtherFee);
                        _statement.TotalVat += Convert.ToDecimal(contribution.VatFee);

                        _statement.Withdrawal += Convert.ToDecimal(contribution.Withdrawal);
                        _statement.WithdrawalVc += Convert.ToDecimal(contribution.WithdrawalVc);
                        //report.VcWithdrawal += Convert.ToDecimal(contribution.WithdrawalVc);

                        _statement.NetContribution += Convert.ToDecimal(contribution.EmployeeContribution + contribution.EmployerContribution);
                        _statement.NetContributionVc += Convert.ToDecimal(contribution.OtherContribution);

                        if (contribution.OtherFee > 0)
                        {
                            _statement.AvcVat += Convert.ToDecimal(contribution.VatFee);
                        }
                    }

                    //turn to absolute value of withdrawals
                    _statement.Withdrawal = Math.Abs(_statement.Withdrawal);
                    _statement.WithdrawalVc = Math.Abs(_statement.WithdrawalVc);

                    //  report.TotalVat = report.TotalVat - report.AvcVat;
                    var totalfee = _statement.TotalFees + _statement.OtherFee + _statement.TotalVat;
                    _statement.NetContribution = _statement.NetContribution - _statement.TotalFees - _statement.TotalVat;
                    //net contribution rsa
                    _statement.NetContributionVc = _statement.NetContributionVc - _statement.OtherFee - _statement.AvcVat;
                    //net contribution vc

                    var currentValue = _statement.Units * Convert.ToDecimal(rsaUnitPrice);
                    var vcCurrentValue = _statement.UnitsVc * Convert.ToDecimal(rsaUnitPrice);

                    _statement.Growth = (currentValue - (_statement.NetContribution - _statement.Withdrawal));
                    _statement.GrowthVc = (vcCurrentValue - (_statement.NetContributionVc - _statement.WithdrawalVc));
                    _statement.TotalGrowth = _statement.Growth + _statement.GrowthVc;

                    _statement.BalanceBeforeWithdrawal = _statement.NetContribution + _statement.Growth;
                    _statement.BalanceBeforeWithdrawalVc = _statement.NetContributionVc + _statement.GrowthVc;
                    _statement.TotalBalanceBeforeWithdrawal = _statement.BalanceBeforeWithdrawal +
                                                             _statement.BalanceBeforeWithdrawalVc;
                    _statement.TotalWithdrawal = _statement.Withdrawal + _statement.WithdrawalVc;

                    _statement.CurrentBalance = _statement.Units * rsaUnitPrice;
                    _statement.CurrentBalanceVc = _statement.UnitsVc * rsaUnitPrice;
                    _statement.TotalBalance = _statement.CurrentBalance + _statement.CurrentBalanceVc;

                    _statement.TotalNetContribution = _statement.NetContribution + _statement.NetContributionVc;
                    //report.TotalVat = report.TotalVat - report.AvcVat;
                    //decimal totalcaont = report.SumEmployee + report.SumEmployer;
                    //report.NetContribution = ((report.SumEmployee + report.SumEmployer -report.SumFees -report.SumVat)+ (report.SumAvc - report.SumOtherfee - report.SumVat));
                    _statement.TotalUnits = _statement.Units + _statement.UnitsVc;
                    //report.Contributions = employee.Contributions;
                    //report.Manager = employee.AccountManager;
                    _statement.UnitPrice = rsaUnitPrice;
                    _statement.ValueDate = dd.valuation_date.Value;
                }
                return _statement;
            }
        }


        public class Statement
        {
            public string ResponseMessage { get; set; }
            public string ResponseCode { get; set; }
            public string StatementHeader { get; set; }
            public decimal Units { get; set; }
            public decimal UnitsVc { get; set; }
            public decimal TotalUnits { get; set; }
            public int TotalCountributionCount { get; set; }
            public decimal TotalFees { get; set; }
            public decimal TotalVat { get; set; }
            public decimal AvcVat { get; set; }
            public decimal OtherFee { get; set; }

            public decimal EmployeeContribution { get; set; }
            public decimal EmployerContribution { get; set; }
            public decimal TotalContribution { get; set; }

            public decimal NetContribution { get; set; }
            public decimal NetContributionVc { get; set; }
            public decimal TotalNetContribution { get; set; }

            public decimal Growth { get; set; }
            public decimal GrowthVc { get; set; }
            public decimal TotalGrowth { get; set; }

            public decimal Withdrawal { get; set; }
            public decimal WithdrawalVc { get; set; }
            public decimal TotalWithdrawal { get; set; }

            public decimal BalanceBeforeWithdrawal { get; set; }
            public decimal BalanceBeforeWithdrawalVc { get; set; }
            public decimal TotalBalanceBeforeWithdrawal { get; set; }

            public decimal CurrentBalance { get; set; }
            public decimal CurrentBalanceVc { get; set; }
            public decimal TotalBalance { get; set; }

            public decimal UnitPrice { get; set; }
            public decimal TotalVc { get; set; }
            public DateTime ValueDate { get; internal set; }
        }
    }
}