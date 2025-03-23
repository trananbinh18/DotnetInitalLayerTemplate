using System.Text.RegularExpressions;

private var pattern = @"^(?=.{1,90}$)(?:feat|chore|fix|docs|test|refactor|style|ci|perf|build|revert)\([a-zA-Z0-9-_.]+\):\s(\u00a9|\u00ae|[\u2000-\u3300]|\ud83c[\ud000-\udfff]|\ud83d[\ud000-\udfff]|\ud83e[\ud000-\udfff])\s.{4,}$";
private var specialPattern = @"^(.*Merge.*|.*Rebase.*)";
private var msg = File.ReadAllLines(Args[0])[0];

if (Regex.IsMatch(msg, pattern)|| Regex.IsMatch(msg, specialPattern))
   return 0;

var YELLOW_START = "\u001b[33m";
var YELLOW_END = "\u001b[0m";
var RED_START = "\u001b[31m";
var RED_END = "\u001b[0m";

Console.WriteLine(GetColorMessage("❌ Invalid commit message", RED_START, RED_END));
Console.WriteLine(GetColorMessage("Commit must follow the format: '<type>(<scope>): <emoji> <descriptions>'", YELLOW_START, YELLOW_END));
Console.WriteLine(GetColorMessage("<type>: feat|chore|fix|docs|test|refactor|style|ci|perf|build|revert.", YELLOW_START, YELLOW_END));
Console.WriteLine(GetColorMessage("<emoji>: standard follow https://gitmoji.dev", YELLOW_START, YELLOW_END));
Console.WriteLine(GetColorMessage("e.g: \n - 'feat(TransactionRepository): ✨ add Code field for employee report' \n - 'fix(Component): 🐛 resolve null pointer exception'", YELLOW_START, YELLOW_END));
Console.WriteLine(GetColorMessage("Special case merging or rebase can use like: 'Merge branch 'staging' of https://github.com/BLOGICSYSTEMS/auth-api into staging'", YELLOW_START, YELLOW_END));
Console.WriteLine(GetColorMessage("more info: https://www.conventionalcommits.org/en/v1.0.0/", YELLOW_START, YELLOW_END));

return 1;

private string GetColorMessage(string message, string colorStart, string colorEnd) {
   return colorStart + message + " " + colorEnd;
}