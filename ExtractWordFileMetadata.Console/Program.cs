// See https://aka.ms/new-console-template for more information

using ExtractWordFileMetadata.Application.Exceptions;
using ExtractWordFileMetadata.Application;
using Microsoft.Extensions.DependencyInjection;

string[] inputFilePaths = new string[] { @"C:\Users\Moham\Documents\test01.docx" };
string outPutFilePath = @"C:\Users\Moham\Documents\ExtractWordFileMetadata.json";

if (inputFilePaths.Length < 1 || string.IsNullOrEmpty(outPutFilePath) || !File.Exists(outPutFilePath))
{
    Console.WriteLine("File Paths Is Empty!");
    return;
}

//DI
var serviceProvider = new ServiceCollection();
serviceProvider.AddApplication()
    .BuildServiceProvider()
    ;


try
{
    //ProcessFileUseCase

    //Extract

    //Report
}
catch (Exception ex)
{
    ExceptionHandler.Handle(ex, "Unhandled exception in the app");
}
