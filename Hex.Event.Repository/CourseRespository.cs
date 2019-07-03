using Hex.Event.Core.Domain.Entities;
using Hex.Event.Core.Domain.Respositories;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hex.Event.Repository
{
    public class CourseRespository : ICourseRespository
    {
        public async Task SaveSubscribe(string course, Student student)
        {
            //TODO: implement repository patner
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("_____________________________________________________________________");
            Console.WriteLine($"Sucess: {JsonConvert.SerializeObject(student)} subscribed on course {course}");
            Console.WriteLine("_____________________________________________________________________");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
