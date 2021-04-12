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
            public string AddresslLine1 { get; set; }
            public string AddresslLine2 { get; set; }
            public string AddresslLine3 { get; set; }
            public string Code { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
        }
    }
}
