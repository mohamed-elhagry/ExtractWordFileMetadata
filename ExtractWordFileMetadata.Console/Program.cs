// See https://aka.ms/new-console-template for more information

using ExtractWordFileMetadata.Application.Exceptions;
using ExtractWordFileMetadata.Application;
using ExtractWordFileMetadata.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using ExtractWordFileMetadata.Application.Interfaces;
using ExtractWordFileMetadata.Application.UseCases;

string[] inputFilePaths = new string[] { @"C:\Users\Moham\Documents\test01.docx" };
string outPutFilePath = @"C:\Users\Moham\Documents\ExtractWordFileMetadata.json";

if (inputFilePaths.Length < 1 || string.IsNullOrEmpty(outPutFilePath) || !File.Exists(outPutFilePath))
{
    Console.WriteLine("File Paths Is Empty!");
    return;
}

//DI
var serviceProvider = new ServiceCollection()
    .AddApplication()
    .AddInfrastructure()
    .BuildServiceProvider()
    ;


try
{
    var processFilesUseCase = serviceProvider.GetRequiredService<IProcessFileUseCase>();
    var reportGenerator = serviceProvider.GetRequiredService<IReportGenerator>();

    //ProcessFileUseCase --> Extract
    var (processedFiles, invalidFiles) = processFilesUseCase.Execute(inputFilePaths);

    //Report
    reportGenerator.Generate(outPutFilePath, processedFiles, invalidFiles);
}
catch (Exception ex)
{
    ExceptionHandler.Handle(ex, "Unhandled exception in the app");
}
