using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDotNet;
using System.IO;
using System.Collections.ObjectModel;

namespace SalaryPrediction
{
    class RdotNetCaller
    {
        private REngine engine;

        public RdotNetCaller(String scriptPath)
        {
            var oldPath = Environment.GetEnvironmentVariable("PATH");
            var rPath1 = @"C:\Program Files\Microsoft\R Client\R_SERVER\bin\x64";
            var rPath2 = @"C:\Program Files\Microsoft\R Client\R_SERVER\library\caret\R";
            if (!Directory.Exists(rPath1))
                throw new DirectoryNotFoundException(string.Format(" R.dll not found in : {0}", rPath1));
            var newPath = string.Format("{0}{1}{2}", rPath1, Path.PathSeparator, oldPath);
            newPath = string.Format("{0}{1}{2}", rPath2, Path.PathSeparator, newPath);
            Environment.SetEnvironmentVariable("PATH", newPath);
            REngine.SetEnvironmentVariables(
                "C:\\Program Files\\R\\R-3.4.4\\bin\\i386",
                "C:\\Program Files\\R\\R-3.4.4"
                );
            engine = REngine.GetInstance();
            engine.Initialize();
            engine.Evaluate($"source('{scriptPath}')");
        }

        public string CallMyModel(params string[] parameters)
        {
            engine.Evaluate(string.Format($"parameters <- data.frame(dataFrameUnPr$A[dataFrameUnPr$N == {parameters[0]}], dataFrameUnSex$A[dataFrameUnSex$N == {parameters[1]}], dataFrameUnReg$A[dataFrameUnReg$N == {parameters[2]}])"));
            engine.Evaluate("names(parameters) <- c('Profession', 'Sex', 'Region')");
            engine.Evaluate("predictions <- predict(lin.model.1, parameters)");
            return engine.Evaluate("as.character(predictions)").AsCharacter().ToArray()[0];
        }
    }
}
