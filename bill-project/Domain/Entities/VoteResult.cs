using bill_project.Domain.Enum;

namespace bill_project.Domain.Entities;

public record VoteResult(long Id, long PersonId, long VoteId, Person Legislator, Vote Vote, VoteTypeEnum VoteType);
