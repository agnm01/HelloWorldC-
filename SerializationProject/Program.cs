using System;
using System.IO;
using System.Text.Json;

namespace SerializationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Member member = new Member() { Name = "Member1" };
            
            string jsonString = JsonSerializer.Serialize(member);
            Console.WriteLine(jsonString);
            File.WriteAllText("file.json", jsonString);
            var readText = File.ReadAllTextAsync("file.json");
            readText.Wait();
            var expectedOutput = readText.Result;
            var teamMemberDeserialized = JsonSerializer.Deserialize<Member>(expectedOutput);

        }
    }
}
