using MeridianApp.Models;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static MeridianApp.Models.Participant;
using PhysicalAddress = MeridianApp.Models.Participant.PhysicalAddress;

namespace MeridianApp.Utils
{
    public class InputReader
    {
        private IWorkbook workbook;
        private DataFormatter dataFormatter;
        private IFormulaEvaluator formulaEvaluator;
        private Participant participant;

        //
        // Initialize from a stream of Excel file
        //
        private void Init()
        {
            var inputPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\Input\\Input.xlsx";
            this.workbook = WorkbookFactory.Create(new FileStream(inputPath, FileMode.Open, FileAccess.Read));
            if (this.workbook != null)
            {
                this.dataFormatter = new DataFormatter(CultureInfo.InvariantCulture);
                this.formulaEvaluator = WorkbookFactory.CreateFormulaEvaluator(this.workbook);
            }
        }

        public Participant Read(int sampleNo)
        {            
            try
            {
                Init();
                var sheet = workbook.GetSheetAt(0);

                Participant.Id Id = new Participant.Id();
                Participant.PhysicalAddress physicalAddress = new PhysicalAddress();
                Participant.PostalAddress postalAddress = new PostalAddress();
                Participant.Contacts contacts = new Contacts();
                Participant.ExternalSystemsReferences externalSystemsReferences = new ExternalSystemsReferences();
                Participant.NOTES notes = new NOTES();
                Participant.BankingDetails bankingDetails = new BankingDetails();
                Participant.Conventions conventions = new Conventions();
                Participant.BillingPracticeDetails billingPracticeDetails = new BillingPracticeDetails();
                Participant.PenaltyGracePeriod penaltyGracePeriod = new PenaltyGracePeriod();
                Participant.PenaltyGracePeriodforGuarantor penaltyGracePeriodforGuarantor = new PenaltyGracePeriodforGuarantor();
                Participant.BusinessDayConvention businessDayConvention = new BusinessDayConvention();
                Participant.IssuerPractices issuerPractices = new IssuerPractices();
                Participant.LimitsandRatings limitsandRatings = new LimitsandRatings();
                Participant.CreditLimit creditLimit = new CreditLimit();
                Participant.CreditRatings creditRatings = new CreditRatings();
                foreach (IRow row in sheet)



                {
                    var attrib = row.GetCell(1).StringCellValue.ToUpper();
                    var value = GetUnformattedValue(row.GetCell(2 + sampleNo));

                    switch (row.GetCell(1).StringCellValue.ToUpper())
                    {
                        case "IDENTIFICATION":
                            
                            if (attrib == "NAME")
                            {
                                Id.Name = value;
                            }else if(attrib == "COUNTRY OF RESIDENCE")
                            {                                
                                Id.CountryOfResidence = value;
                            
                             }else if(attrib == "COUNTRY OF DOMICILE")
                            {                                
                                Id.CountryOfDomicile = value;
                            
                             }else if(attrib == "RESIDENCY")
                            {                                
                                Id.Residency = value;
                             }else if(attrib == "ROLE")
                            {                                
                                Id.Role = value;
                            
                             }else if(attrib == "CATEGORY")
                            {                                
                                Id.Category = value;
                            
                    }else if (attrib == "NATIONALSECTOR")
                    {
                        Id.NationalSector = value;
                    
                }else if (attrib == "INSTTITUTINALSECTOR")
                {
                    Id.InsttitutinalSector = value;
                
                 }else if(attrib == "PARENTCOMPANY")
                            {                                
                                Id.ParentCompany = value;
                            }
                            else if (attrib == "STATUS")
                            {
                                Id.Status = value;

                            }
                            else if (attrib == "PARTICIPANTNOTUSED")
                            {
                                Id.ParticipantNotUsed = value;
                            }
                            else if (attrib == "PARTICIPANTISOWNER")
                            {
                                Id.ParticipantIsOwner = value;

                            }
                            else if (attrib == "EXPORTCODE")
                            {
                                Id.ExportCode = value;
                            }
                            else if (attrib == "EXTERNALCODE")
                            {
                                Id.ExternalCode = value;
                            }
                            break;

                        case "PHYSICAL ADDRESS":
                            if (attrib == "ADDRESSLINE1")
                            {
                                physicalAddress.AddressLine1 = value;
                            }
                            else if (attrib == "ADDRESSLINE2")
                            {
                                physicalAddress.AddressLine2 = value;
                            }
                            else if (attrib == "ADDRESSLINE3")
                            {
                                physicalAddress.AddressLine3 = value;
                            }
                            else if (attrib == "CODE")
                            {
                                physicalAddress.Code = value;
                            }
                            else if (attrib == "COUNTRY")
                            {
                                physicalAddress.Country = value;
                            }
                            else if (attrib == "CITY")
                            {
                                physicalAddress.City = value;
                            }
                            break;

                        case "POSTAL ADDRESS":
                            if (attrib == "ADDRESSLINE1")
                            {
                                postalAddress.AddressLine1 = value;
                            }
                            else if (attrib == "ADDRESSLINE2")
                            {
                                postalAddress.AddressLine2 = value;
                            }
                            else if (attrib == "ADDRESSLINE3")
                            {
                                postalAddress.AddressLine3 = value;
                            }
                            else if (attrib == "CODE")
                            {
                                postalAddress.Code = value;
                            }
                            else if (attrib == "CITY")
                            {
                                postalAddress.City = value;
                            }
                            else if (attrib == "WEBADDRESS")
                            {
                                postalAddress.WebAddress = value;
                            }
                            
                            break;

                        case "CONTACTS":
                            if (attrib == "CONTACTNAME")
                            {
                                contacts.ContactName = value;
                            }
                            else if (attrib == "CONTACTTELEPHONENUMBER")
                            {
                                contacts.ContactTelephoneNumber = value;
                            }
                            else if (attrib == "CONTACTFAXNUMBER")
                            {
                                contacts.ContactFaxNumber = value;
                            }
                            else if (attrib == "CONTACTEMAIL")
                            {
                                contacts.ContactEmail = value;
                            }
                            else if (attrib == "PRIMARYCONTACTINDICATOR")
                            {
                                contacts.PrimaryContactIndicator = value;
                            }
                            break;
                        case "EXTERNAL SYSTEMS REFERENCES":
                            if (attrib == "EXTERNALSYSTEM")
                            {
                                externalSystemsReferences.Externalsystem = value;
                            }
                            else if (attrib == "REFERENCE")
                            {
                                externalSystemsReferences.Reference = value;
                            }
                            break;
                        case "NOTES":
                            if (attrib == "NOTESDATE")
                            {
                                notes.NotesDate = value;
                            }
                            else if (attrib == "NOTES")
                            {
                                notes.Notes = value;
                            }
                            break;
                        case "BANKING DETAILS":
                            if (attrib == "BANKNAME")
                            {
                                bankingDetails.BankName = value;
                            }
                            else if (attrib == "ACCOUNTNAME")
                            {
                                bankingDetails.AccountName = value;
                            }
                            else if (attrib == "CURRENCY")
                            {
                                bankingDetails.Currency = value;
                            }
                            else if (attrib == "IBAN")
                            {
                                bankingDetails.IBAN = value;
                            }
                            else if (attrib == "SWIFTBICNUMBER")
                            {
                                bankingDetails.SWIFTBICNumber = value;
                            }
                            else if (attrib == "COUNTRY")
                            {
                                bankingDetails.Country = value;
                            }
                            else if (attrib == "CITY")
                            {
                                bankingDetails.City = value;
                            }
                            else if (attrib == "STARTDATE")
                            {
                                bankingDetails.StartDate = value;
                            }
                            else if (attrib == "ENDDATE")
                            {
                                bankingDetails.EndDate = value;
                            }
                            else if (attrib == "ACCOUNTUSE")
                            {
                                bankingDetails.AccountUse = value;
                            }
                            else if (attrib == "BANKACCOUNTSTATUS")
                            {
                                bankingDetails.BankAccountStatus = value;
                            }
                            else if (attrib == "APPLICABLEINSTRUMENTTYPES")
                            {
                                bankingDetails.ApplicableInstrumentTypes = value;
                            }
                            else if (attrib == "DEFAULTDEBITACCOUNT")
                            {
                                bankingDetails.DefaultDebitAccount = value;
                            }
                            else if (attrib == "DEFAULTDEBITSTARTDATE")
                            {
                                bankingDetails.DefaultDebitStartDate = value;
                            }
                            else if (attrib == "DEFAULTDEBITENDDATE")
                            {
                                bankingDetails.DefaultDebitEndDate = value;
                            }
                            else if (attrib == "DEFAULTCREDITACCOUNT")
                            {
                                bankingDetails.DefaultCreditAccount = value;
                            }
                            else if (attrib == "DEFAULTCREDITSTARTDATE")
                            {
                                bankingDetails.DefaultCreditStartDate = value;
                            }
                            else if (attrib == "DEFAULTCREDITENDDATE")
                            {
                                bankingDetails.DefaultCreditEndDate = value;
                            }
                            else if (attrib == "INTERMEDIARYBANKINGDETAILS")
                            {
                                bankingDetails.IntermediaryBankingdetails = value;
                            }
                            break;
                        case "BILLING PRACTICE DETAILS":
                             if (attrib == "OPTIONS")
                            {
                                billingPracticeDetails.Options = value;
                            }
                            else if (attrib == "INTERMEDIARYBANKINGDETAILS")
                            {
                                billingPracticeDetails.Period = value;
                            }
                            break;
                        case "PENALTY GRACE PERIOD":
                            if (attrib == "PERIOD")
                            {
                                penaltyGracePeriod.Period = value;
                            }
                            else if (attrib == "PERIODICITY")
                            {
                                penaltyGracePeriod.Periodicity = value;
                            }
                            break;

                        case "PENALTY GRACE PERIOD (FOR GUARANTOR)":
                            if (attrib == "PERIOD")
                            {
                                penaltyGracePeriodforGuarantor.Period = value;
                            }
                            else if (attrib == "PERIODICITY")
                            {
                                penaltyGracePeriodforGuarantor.Periodicity = value;
                            }
                            else if(attrib == "PAYMENTFREQUENCY")
                            {
                                penaltyGracePeriodforGuarantor.PaymentFrequency = value;
                            }
                            else if (attrib == "EXPECTEDTIMEFORCLAIMSETTLEMENTINDAYS")
                            {
                                penaltyGracePeriodforGuarantor.ExpectedTimeforClaimSettlementindays = value;
                            }
                            else if (attrib == "PAYMENTAPPLICATIONMETHOD")
                            {
                                penaltyGracePeriodforGuarantor.PaymentApplicationMethod = value;
                            }
                            else if (attrib == "MINIMUMBILLAMOUNT")
                            {
                                penaltyGracePeriodforGuarantor.MinimumBillAmount = value;
                            }
                            else if (attrib == "PREPAYMENTMETHODS")
                            {
                                penaltyGracePeriodforGuarantor.Prepaymentmethods = value;
                            }
                            else if (attrib == "LEGALCLAUSES")
                            {
                                penaltyGracePeriodforGuarantor.LegalClauses = value;
                            }
                            break;

                        case "BUSINESS DAY CONVENTION":
                            if (attrib == "CASHFLOWTYPE")
                            {
                                businessDayConvention.CashFlowType = value;
                            }
                            else if (attrib == "DATEROLL")
                            {
                                businessDayConvention.DateRoll = value;
                            }
                            else if (attrib == "CALCULATEARREARSFROM")
                            {
                                businessDayConvention.Calculatearrearsfrom = value;
                            }
                            else if (attrib == "ENDMONTHINDICATOR")
                            {
                                businessDayConvention.EndMonthIndicator = value;
                            }
                            else if (attrib == "INTERESTCALCULATEDTO")
                            {
                                businessDayConvention.InterestCalculatedTo = value;
                            }
                            break;
                        case "ISSUER PRACTICES":
                            if (attrib == "OPTIONS")
                            {
                                issuerPractices.Options = value;
                            }
                            else if (attrib == "BOOKCLOSEDPERIODPERIOD")
                            {
                                issuerPractices.BookClosedPeriodPeriod = value;
                            }
                            else if (attrib == "PERIODICITY")
                            {
                                issuerPractices.Periodicity = value;
                            }
                            break;
                        case "CREDIT LIMIT":
                            if (attrib == "CATEGORY")
                            {
                                creditLimit.Category = value;
                            }
                            else if (attrib == "AMOUNTPERIOD")
                            {
                                creditLimit.AmountPeriod = value;
                            }
                            break;
                        case "CREDIT RATINGS":
                            if (attrib == "RATINGAGENCY")
                            {
                                creditRatings.RatingAgency = value;
                            }
                            else if (attrib == "RATINGDATE")
                            {
                                creditRatings.RatingDate = value;
                            }
                            else if (attrib == "CREDITRATING")
                            {
                                creditRatings.CreditRating = value;
                            }
                            else if (attrib == "RATINGOUTLOOK")
                            {
                                creditRatings.RatingOutlook = value;
                            }
                            else if (attrib == "WATCHDATE")
                            {
                                creditRatings.WatchDate = value;
                            }
                            break; 
                    }
                }
                

                participant = new Participant();
                participant._Id = Id;
                //participant._PhysicalAddress = 

                return participant;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Reading Input Excel file");
                throw (ex);
            }
        }


        //
        // Get formatted value as string from the specified cell
        //
        protected string GetFormattedValue(ICell cell)
        {
            string returnValue = string.Empty;
            if (cell != null)
            {
                try
                {
                    // Get evaluated and formatted cell value
                    returnValue = this.dataFormatter.FormatCellValue(cell, this.formulaEvaluator);
                }
                catch
                {
                    // When failed in evaluating the formula, use stored values instead...
                    // and set cell value for reference from formulae in other cells...
                    if (cell.CellType == CellType.Formula)
                    {
                        switch (cell.CachedFormulaResultType)
                        {
                            case CellType.String:
                                returnValue = cell.StringCellValue;
                                cell.SetCellValue(cell.StringCellValue);
                                break;
                            case CellType.Numeric:
                                returnValue = dataFormatter.FormatRawCellContents(cell.NumericCellValue, 0, cell.CellStyle.GetDataFormatString());
                                cell.SetCellValue(cell.NumericCellValue);
                                break;
                            case CellType.Boolean:
                                returnValue = cell.BooleanCellValue.ToString();
                                cell.SetCellValue(cell.BooleanCellValue);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return (returnValue ?? string.Empty).Trim();
        }

        //
        // Get unformatted value as string from the specified cell
        //
        protected string GetUnformattedValue(ICell cell)
        {
            string returnValue = string.Empty;
            if (cell != null)
            {
                try
                {
                    // Get evaluated cell value
                    returnValue = (cell.CellType == CellType.Numeric ||
                    (cell.CellType == CellType.Formula &&
                    cell.CachedFormulaResultType == CellType.Numeric)) ?
                        formulaEvaluator.EvaluateInCell(cell).NumericCellValue.ToString() :
                        this.dataFormatter.FormatCellValue(cell, this.formulaEvaluator);
                }
                catch
                {
                    // When failed in evaluating the formula, use stored values instead...
                    // and set cell value for reference from formulae in other cells...
                    if (cell.CellType == CellType.Formula)
                    {
                        switch (cell.CachedFormulaResultType)
                        {
                            case CellType.String:
                                returnValue = cell.StringCellValue;
                                cell.SetCellValue(cell.StringCellValue);
                                break;
                            case CellType.Numeric:
                                returnValue = cell.NumericCellValue.ToString();
                                cell.SetCellValue(cell.NumericCellValue);
                                break;
                            case CellType.Boolean:
                                returnValue = cell.BooleanCellValue.ToString();
                                cell.SetCellValue(cell.BooleanCellValue);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return (returnValue ?? string.Empty).Trim();
        }
    }
}



