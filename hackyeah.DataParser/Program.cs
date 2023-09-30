using System.ComponentModel.DataAnnotations;
using System.Text;

string path = "db.csv";

var enumLines = File.ReadLines(path, Encoding.UTF8);

foreach (var line in enumLines)
{
}