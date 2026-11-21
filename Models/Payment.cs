namespace SdaTithe.Models;

public class Payment
{
    public int Id { get; set; }
    public string ReceiptNo { get; set; } = "";
    public int MemberId { get; set; }
    public string MemberName { get; set; } = "";
    public int ChurchId { get; set; }
    public string ChurchName { get; set; } = "";
    public int Amount { get; set; }
    public DateTime PaidOn { get; set; }
    public string Method { get; set; } = "";      // MTN, Airtel, Card, Cash
    public string? ReceivedBy { get; set; }
    public int? ReceivedById { get; set; }
}