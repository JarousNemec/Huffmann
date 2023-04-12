// See https://aka.ms/new-console-template for more information

using Huffmann;

var huffmann = new HuffmannCompressor();
var input = "abrakadabra";
var output = huffmann.Compress(input);
Console.WriteLine(input);
Console.WriteLine(input.Length*8);
Console.WriteLine(output);
Console.WriteLine(output.Length);
