namespace MIP_API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IdNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class Investment
    {
        public int InvestmentId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public decimal AmountInvested { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double ReturnRate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public User User { get; set; }
    }

    public class Report
    {
        public int ReportId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string Notes { get; set; }
        public DateTime DateGenerated { get; set; }

        // Navigation property
        public User User { get; set; }
    }

    public class Message
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending";

        // Navigation property
        public User User { get; set; }
    }
}
