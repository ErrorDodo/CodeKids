var question = "What is your name?";
Console.WriteLine(question);
var name = Console.ReadLine();

var qnA = $"{question}\n{name}";

File.AppendAllText("/home/dylan/Documents/QnA.txt", qnA);