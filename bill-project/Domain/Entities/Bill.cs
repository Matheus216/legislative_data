namespace bill_project.Domain.Entities;

public record Bill(long Id, string Title, int SponsorId, Sponsor Sponsor); 


