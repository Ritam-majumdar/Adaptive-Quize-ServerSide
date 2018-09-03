using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using QuizServer.Models;

namespace QuizServer
{
    public class QuestionHub : Hub
    {
      //public  Dictionary<int, Dictionary<string, List<string>>> dict = new Dictionary<int, Dictionary<string, List<string>>>();
        public static int count = 0;
        List<Question> Questions = new List<Question>()
        {
            new Question() {
            Quesid = 1,
            QuestionText = "Who is the CM of WestBengal?",
            Options = new List<Option>
                {
                    new Option{
                        Opid = 1,
                        OptionText ="Siddu"},
                    
                    new Option{
                        Opid = 2,
                        OptionText ="Didi"},
                    
                    new Option{
                        Opid = 3,
                        OptionText ="Modi"},
                    
                    new Option{
                        Opid = 4,
                        OptionText ="RaGa"}
                }
        },
        new Question()
        {
            Quesid = 2,
            QuestionText = "Who is the CM of Karnataka?",
            Options = new List<Option>
                {
                    new Option{
                        Opid = 1,
                        OptionText ="Siddu"},

                    new Option{
                        Opid = 2,
                        OptionText ="Didi"},

                    new Option{
                        Opid = 3,
                        OptionText ="Modi"},

                    new Option{
                        Opid = 4,
                        OptionText ="RaGa"}
                }
            },
            new Question()
        {
            Quesid = 3,
            QuestionText = "Who is the CM of Kerala?",
            Options = new List<Option>
                {
                    new Option{
                        Opid = 1,
                        OptionText ="Siddu"},

                    new Option{
                        Opid = 2,
                        OptionText ="Didi"},

                    new Option{
                        Opid = 3,
                        OptionText ="Modi"},

                    new Option{
                        Opid = 4,
                        OptionText ="RaGa"}
                }
            }
        };

        // public Task StoreResponse()
        // {

        // }

        // Emit's Next Question from the collection of Questions
        public Task GetNextQuestion()
        {
            if (count < Questions.Count) 
            {
                Question question = Questions[count];
                count++;
                string q = question.QuestionText;
                return Clients.Caller.SendAsync("NextQuestion", q);
            }
            else
                return Clients.Caller.SendAsync("EndOfQuestions");
        }


        public override Task OnConnectedAsync()
        {

            Console.WriteLine("Client Connected");
            Console.WriteLine("count before is " + count);
           
            Console.WriteLine("count is " + count);
            return GetNextQuestion();
        }
        
    }
}
