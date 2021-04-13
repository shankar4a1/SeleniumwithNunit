using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeridianApp.Models
{
    public class Participant
    {
        public Id _Id { get; set; }
        public PhysicalAddress _PhysicalAddress { get; set; }
        public PostalAddress _PostalAddress { get; set; }
        public Contacts _contacts { get; set; }
        public ExternalSystemsReferences _ExternalSystemsReferences { get; set; }
        public NOTES _NOTES { get; set; }
        public BankingDetails _BankingDetails { get; set; }
        public Conventions _Conventions { get; set; }
        public BillingPracticeDetails _BillingPracticeDetails { get; set; }
        public PenaltyGracePeriod _PenaltyGracePeriod { get; set; }
        public PenaltyGracePeriodforGuarantor _PenaltyGracePeriodforGuarantor { get; set; }
        public BusinessDayConvention _BusinessDayConvention { get; set; }
        public IssuerPractices _IssuerPractices { get; set; }
        public LimitsandRatings _LimitsandRatings { get; set; }
        public CreditLimit _CreditLimit { get; set; }
        public CreditRatings _CreditRatings { get; set; }
        

        public partial class Id
        {
            public string Name { get; set; }
            public string CountryOfResidence { get; set; }
            public string CountryOfDomicile { get; set; }
            public string Residency { get; set; }
            public string Role { get; set; }
            public string Category { get; set; }
            public string NationalSector { get; set; }
            public string InsttitutinalSector { get; set; }
            public string ParentCompany { get; set; }
            public string Status { get; set; }
            public string ParticipantNotUsed { get; set; }
            public string ParticipantIsOwner { get; set; }
            public string ExportCode { get; set; }
            public string ExternalCode { get; set; }
        }
        public partial class PhysicalAddress
        {
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string AddressLine3 { get; set; }
            public string Code { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
        }
        public partial class PostalAddress
        {
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string AddressLine3 { get; set; }
            public string Code { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public string  WebAddress{ get; set; }
        }
        public partial class Contacts
        {
            public string ContactName { get; set; }
            public string ContactTelephoneNumber { get; set; }
            public string ContactFaxNumber { get; set; }
            public string ContactEmail { get; set; }
            public string PrimaryContactIndicator { get; set; }
        }
        public partial class ExternalSystemsReferences
        {
            public string Externalsystem { get; set; }
            public string Reference { get; set; }
        }
        public partial class NOTES
        {
            public string NotesDate { get; set; }
            public string Notes { get; set; }
            
        }
        public partial class BankingDetails
        {
            public string BankName { get; set; }
            public string AccountName { get; set; }
            public string AccountNumber { get; set; }
            public string Currency { get; set; }
            public string IBAN { get; set; }
            public string SWIFTBICNumber { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public string AccountUse { get; set; }
            public string BankAccountStatus { get; set; }
            public string ApplicableInstrumentTypes { get; set; }
            public string DefaultDebitAccount { get; set; }
            public string DefaultDebitStartDate { get; set; }
            public string DefaultDebitEndDate { get; set; }
            public string DefaultCreditAccount { get; set; }
            public string DefaultCreditStartDate { get; set; }
            public string DefaultCreditEndDate { get; set; }
            public string IntermediaryBankingdetails { get; set; }
            

        }
        public partial class Conventions
        {
           

    }
    public partial class BillingPracticeDetails
        {
            public string Options { get; set; }
            public string Period { get; set; }

        }
        public partial class PenaltyGracePeriod
        {
            public string Period { get; set; }
            public string Periodicity { get; set; }

        }
       

        public partial class PenaltyGracePeriodforGuarantor
            {
            public string Period { get; set; }
            public string Periodicity { get; set; }
            public string PaymentFrequency { get; set; }
            public string ExpectedTimeforClaimSettlementindays { get; set; }
            public string PaymentApplicationMethod { get; set; }
            public string MinimumBillAmount { get; set; }
            public string Prepaymentmethods { get; set; }
            public string LegalClauses { get; set; }


        }
        public partial class BusinessDayConvention
        {
            public string CashFlowType { get; set; }
            public string DateRoll { get; set; }
            public string Calculatearrearsfrom { get; set; }
            public string EndMonthIndicator { get; set; }
            public string InterestCalculatedTo { get; set; }
           
        }
        public partial class IssuerPractices
        {
            public string Options { get; set; }
            public string BookClosedPeriodPeriod { get; set; }
            public string Periodicity { get; set; }
        }
       
        public partial class LimitsandRatings
        {
           
            
        }
        public partial class CreditLimit
        {
            public string Category { get; set; }
            public string AmountPeriod { get; set; }

        }
        public partial class CreditRatings
        {
            public string RatingAgency { get; set; }
            public string RatingDate { get; set; }
            public string CreditRating { get; set; }
            public string RatingOutlook { get; set; }
            public string WatchDate { get; set; }

        }
    }
}
