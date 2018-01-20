using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.CodeDom;
using System.IO;

namespace killercodes_in.CompileOnFly
{

//This class compiles and executes a dot.net snippets on the fly in memory.
    public class Compile
    {
        string _codeStatement;
        string _completeCode;

        public Compile(string Code)
        {
            this._codeStatement = Code;
        }

        private string CompleteCode()
        {
            StringBuilder sb = new StringBuilder("using System;");
            sb.AppendLine("namespace killercodes_in.CompileOnFly");
            sb.AppendLine("{");
            sb.AppendLine("public class Program");
            sb.AppendLine("{");
            sb.AppendLine("public static void Main()");
            sb.AppendLine("{").Append(this._codeStatement).Append("}");
            sb.AppendLine("}").AppendLine("}");
            return sb.ToString();
        }

        public bool Execute()
        {
            try
            {
                _completeCode = CompleteCode();
                CompilerParameters compilerParameters = new CompilerParameters();
                // Reference to System.Drawing library
                compilerParameters.ReferencedAssemblies.Add("System.Drawing.dll");
                compilerParameters.ReferencedAssemblies.Add("system.dll");
                //rest of the references can be added as compilerParameters.ReferencedAssemblies.Add("System.Console");
                
                // True - memory generation, false - external file generation
                compilerParameters.GenerateInMemory = true;
                // True - exe file generation, false - dll file generation
                compilerParameters.GenerateExecutable = true;
                
                CodeNamespace _nameSpace = new CodeNamespace("CompileOnFly");
                CSharpCodeProvider codeProvider = new CSharpCodeProvider();
                CompilerResults results = codeProvider.CompileAssemblyFromSource(compilerParameters, _completeCode);

                if (results.Errors.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (CompilerError error in results.Errors)
                    {
                        sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
                    }
                    throw new InvalidOperationException(sb.ToString());
                }

                //Get assembly, type and the Main method:
                Assembly assembly = results.CompiledAssembly;
                Type program = assembly.GetType("killercodes_in.CompileOnFly.Program");
                MethodInfo main = program.GetMethod("Main");

                //runti
                main.Invoke(null, null);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
