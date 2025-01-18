using bill_project.Application.Services;

var service = new BillVoteService();   

service.GenerateResultBillVote().Wait(); 

Console.ReadLine();