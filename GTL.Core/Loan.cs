using System;

namespace GTLCore
{
    public class Loan
    {
        public int id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime return_date { get; set; }
        public int m_ssn { get; set; }
        public int member_loan_no { get; set; }
    }
}
