using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SDKLibV5.Functionality
{
    internal sealed class CSharp : FunctionalityBase
    {
        #region IDescribeMyFunctionality
        private static DescribeMyFunctionality<InputParamsBase> _info;

        /// <summary>
        ///     Functionality Info
        /// </summary>
        internal static DescribeMyFunctionality<InputParamsBase> Info
        {
            get
            {
                if (_info is null)
                {
                    #region Class Functionality Definitions and sample inputs
                    var desc4Class = @"This class provides CSharp code related data manipulations";
                    var desc4EscapeString = @"Escapes double quotes in the given string of C# code";
                    var desc4EscapeStringV2 = @"Escapes double quotes in the given string of C# code - @$ version";
                    var desc4FindRelatedClasses = @"Finds and lists all the related C# classes in a given root folder";

                    FunctionalityInfo<InputParamsBase> funcEscapeString = new(nameof(EscapeString), desc4EscapeString,
                        new List<InputParams> {
                            new InputParams(SDKLibV5.Constants.MultiLineIndicator + @"        /// <summary>
        ///     Functionality Info
        /// </summary>
        internal static DescribeMyFunctionality<InputParamsBase> Info
        {
            get
            {
                if (_info is null)
                {
                    #region Class Functionality Definitions and sample inputs
                    var desc4Class = @""This class provides CSharp code related data manipulations"";
                    var desc4EscapeString = @""Escapes double quotes in the given string of C# code"";

                    FunctionalityInfo<InputParamsBase> funcEscapeString = new(""EscapeString"", desc4EscapeString,
                        new List<InputParams> {
                            new InputParams(SDKLibV5.Constants.MultiLineIndicator + @""c# code goes in here"")  });

                    List<FunctionalityInfo<InputParamsBase>> functionalities = new()
                    {
                        funcEscapeString,
                    };
                    #endregion

                    _info = new DescribeMyFunctionality<InputParamsBase>(desc4Class, functionalities, new DateTime(2021, 5, 10));
                }
                return _info;
            }
        }
"), new InputParams("TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT")  });

                    FunctionalityInfo<InputParamsBase> funcEscapeStringV2 = new(nameof(EscapeStringV2), desc4EscapeStringV2,
                        new List<InputParams> {
                            new InputParams(SDKLibV5.Constants.MultiLineIndicator + @"        /// <summary>
        ///     Functionality Info
        /// </summary>
        internal static DescribeMyFunctionality<InputParamsBase> Info
        {
            get
            {
                if (_info is null)
                {
                    #region Class Functionality Definitions and sample inputs
                    var desc4Class = @""This class provides CSharp code related data manipulations"";
                    var desc4EscapeString = @""Escapes double quotes in the given string of C# code"";

                    FunctionalityInfo<InputParamsBase> funcEscapeString = new(""EscapeString"", desc4EscapeString,
                        new List<InputParams> {
                            new InputParams(SDKLibV5.Constants.MultiLineIndicator + @""c# code goes in here"")  });

                    List<FunctionalityInfo<InputParamsBase>> functionalities = new()
                    {
                        funcEscapeString,
                    };
                    #endregion

                    _info = new DescribeMyFunctionality<InputParamsBase>(desc4Class, functionalities, new DateTime(2021, 5, 10));
                }
                return _info;
            }
        }
"), new InputParams("TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT")  });


                    var desc4DataTable2HtmlTable = @"Converts a given tab delimited table to HTML table";
                    FunctionalityInfo<InputParamsBase> funcFindRelatedClasses = new(nameof(RelatedClasses), desc4FindRelatedClasses,
                        new List<InputParams> {
                            new InputParams { RootPath = @"C:\SDK\Dev\src\temp\BlogPosts\An_Architecture_for_WPF_Applications\WPFArchSamples" }
                            });

                    FunctionalityInfo<InputParamsBase> funcNumSuffix = new(nameof(NumSfx), "Show suffixes for numbers to denote specific numeric types in C#",
                        new List<InputParams> { new InputParams() });

                    List<FunctionalityInfo<InputParamsBase>> functionalities = new()
                    {
                        funcEscapeString,
                        funcEscapeStringV2,
                        funcFindRelatedClasses,
                        funcNumSuffix,
                    };
                    #endregion

                    _info = new DescribeMyFunctionality<InputParamsBase>(desc4Class, functionalities, new DateTime(2021, 5, 10));
                }
                return _info;
            }
        }

        internal class InputParams : InputParamsBase
        {
            public string CSharpCode { get; set; } = null;
            public string RootPath { get; set; } = null;
            public InputParams() { }
            public InputParams(string cSharpCode)
            {
                CSharpCode = cSharpCode;
            }
        }
        #endregion



        #region Implementation
        private sealed class Constants
        {
            internal const string CommentChar = "//";
            internal const string CommandChar = ">";
            internal static string HTMLDocHeadTemplate = @$"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"" />
    <title>GetARide - Notes / Classes</title>
    <style>
        body {{
            font-family: 'Lato', sans-serif;
            color: #757374;
            font-size: larger;
        }}
        h2 {{
            color: black;
        }}
        li.happy {{
            color: green;
        }}
        /*  --------  table styles --------  */
        table {{
            color: #333; /* Lighten up font color */
            font-family: Helvetica, Arial, sans-serif; /* Nicer font */
            width: 640px;
            border-collapse: collapse;
            border-spacing: 0;
        }}
        td, th {{
            border: 1px solid #CCC;
            height: 30px;
            text-align:left;
            padding: 4px 10px 4px 10px;
        }}
        /* Make cells a bit taller */
        th {{
            background: #F3F3F3; /* Light grey background */
            font-weight: bold; /* Make sure they're bold */
        }}
        td {{
            background: #FAFAFA; /* Lighter grey background */
            text-align: left;
        }}
        tr:nth-child(even) td {{
            background: #F1F1F1;
        }}
        tr:nth-child(odd) td {{
            background: #FEFEFE;
        }}
        tr td:hover {{
            background: #666;
            color: #FFF;
        }}
        th {{
            background: #45a3de;
            color: navy;
        }}
        /*  eo--------  table styles --------  */
        
    </style>
</head>
";
        }


        internal string NumSfx(InputParams inputParams)
        {
            var suffixes = @"
From C# specifications:

var f = 0f; // float
var d = 0d; // double
var m = 0m; // decimal (money)
var u = 0u; // unsigned int
var l = 0l; // long
var ul = 0ul; // unsigned long

";
            return suffixes;
        }



        #region Related Classes

        internal string RelatedClasses(InputParams inputParams)
        {
            Dictionary<string, SortedSet<string>> classesAndParents = TraverseDirsAndGetClassesAndParents(inputParams.RootPath);
            StringBuilder sb = new("...☞ List of encountered Types and their Parent types (parent types denoted with ──ᐅ) ☚...\r\n\r\n");
            foreach (var classAndParents in classesAndParents)
            {
                sb.AppendLine($"{classAndParents.Key} ──ᐅ {string.Join(", ", classAndParents.Value)}");
            }

            sb.AppendLine($"\r\n...☞ Number of classes that inherit from other classes: {classesAndParents.Count}");
            return sb.ToString()
                + DrawTopLogerTrees(classesAndParents);
        }

        private int maxWidthNodeName = 0;
        private string DrawTopLogerTrees(Dictionary<string, SortedSet<string>> classesAndParents)
        {
            StringBuilder sb = new($"\r\n\r\n ======== HIERARCHY OF INHERITING CLASSES ========\r\n\r\n");

            // step 1 - get terminal nodes
            SortedSet<string> terminalNodes = GetTerminalNodes(classesAndParents);

            List<Progeny> descendantsList = new();
            foreach (string termNode in terminalNodes)
            {
                Progeny progeny = new(termNode);
                progeny.Children = GetPotentialPaths(termNode, classesAndParents);
                descendantsList.Add(progeny);
            }

            List<Progeny> longerPaths = descendantsList.OrderByDescending(p => p.Depth).ToList();
            SetMaxNameWidth(longerPaths);
            TextOps textOps = new TextOps();

            for (int i = 0; i < longerPaths.Count; i++)
            {
                var longerPath = longerPaths[i];
                var verticalDiagramInTabs = NodeToString(longerPath).Trim();
                var verticalDiagramInText = textOps.Hierarchy2View(new TextOps.InputParams { HierarchicalData = verticalDiagramInTabs, OutputType = "Text" });
                sb.AppendLine($"\r\n\r\n===== ({i + 1}/{longerPaths.Count}) ☞ Vertical View...\r\n\r\n"
                                + verticalDiagramInText
                                + "\r\n\r\n...☞ Horizontal View...\r\n\r\n"
                                + NodeToString(longerPath, " ──ᐅ ")
                                + "\r\n\r\n"
                                + "PS. These graphs may not be 100% accurate");
            }

            return sb.ToString();
        }

        private void SetMaxNameWidth(List<Progeny> longerPaths)
        {
            for (int i = 0; i < longerPaths.Count; i++)
            {
                if (maxWidthNodeName < longerPaths[i].ClassName.Length)
                    maxWidthNodeName = longerPaths[i].ClassName.Length;

                CompareMaxWidthToChildNodeNames(longerPaths[i]);
            }
        }

        private void CompareMaxWidthToChildNodeNames(Progeny progeny)
        {
            foreach (Progeny child in progeny.Children)
            {
                if (maxWidthNodeName < child.ClassName.Length)
                    maxWidthNodeName = child.ClassName.Length;

                CompareMaxWidthToChildNodeNames(child);
            }
        }

        private SortedSet<string> GetTerminalNodes(Dictionary<string, SortedSet<string>> classesAndParents)
        {
            SortedSet<string> terminalNodes = new();

            foreach (var classAndParents in classesAndParents)
            {
                var topNodes = classAndParents.Value.Where(c => !classesAndParents.ContainsKey(c));
                foreach (var node in topNodes)
                    terminalNodes.Add(node);
            }

            return terminalNodes;
        }

        private string NodeToString(Progeny progeny, int tabs = 0)
        {
            StringBuilder sb = new();
            sb.AppendLine(new string('\t', tabs) + progeny.ClassName);
            if (progeny.Children.Count > 0)
            {
                tabs++;
                var potentialPaths = progeny.Children.OrderBy(p => p.ClassName);
                foreach (var path in potentialPaths)
                {
                    string childNodeName = NodeToString(path, tabs);
                    // sb.Append(childNodeName.Trim().PadRight(maxWidthNodeName + 2));
                    sb.Append(childNodeName);
                }
            }

            return sb.ToString();
        }

        private List<string> GetLongestPathInList(Progeny progeny)
        {
            List<string> list = new();
            list.Add(progeny.ClassName);
            if (progeny.Children.Count > 0)
            {
                var longestPath = progeny.Children.OrderByDescending(p => p.Depth).First();
                list.AddRange(GetLongestPathInList(longestPath));
            }

            return list;
        }


        private string NodeToString(Progeny progeny, string seperator)
        {
            var listOfNodes = GetLongestPathInList(progeny);
            StringBuilder sb = new();
            for (int i = listOfNodes.Count - 1; i >= 0; i--)
            {
                sb.Append(GetSiblings(listOfNodes[i], progeny));
                if (i > 0)
                    sb.Append(seperator);
            }

            sb.Append(listOfNodes[0]);
            return sb.ToString();
        }

        private string GetSiblings(string nodeName, Progeny progeny)
        {
            StringBuilder sb = new();
            if (progeny.Children.Any(c => c.ClassName == nodeName))
                sb.Append(string.Join("|", progeny.Children.Select(c => c.ClassName)));
            else
                foreach (var child in progeny.Children)
                {
                    sb.Append(GetSiblings(nodeName, child));
                }

            return sb.ToString();
        }

        private List<Progeny> GetPotentialPaths(string termNode, Dictionary<string, SortedSet<string>> classesAndParents)
        {
            List<Progeny> progenies = new();
            var paths = classesAndParents.Where(c => c.Value.Contains(termNode));

            foreach (var path in paths)
            {
                var pro = new Progeny(path.Key);
                pro.Children.AddRange(GetPotentialPaths(pro.ClassName, classesAndParents));
                progenies.Add(pro);
            }

            return progenies;
        }

        private class Progeny
        {

            public string ClassName { get; set; }

            public List<Progeny> Children { get; set; }

            public Progeny(string clsName)
            {
                ClassName = clsName;
                Children = new List<Progeny>();
            }

            private int _depth;
            public int Depth
            {
                get
                {
                    return GetDepth(this);
                }

                set { _depth = value; }
            }


            private int GetDepth(Progeny progeny)
            {
                int i = 0;
                if (progeny.Children.Count > 0)
                    i = 1;

                foreach (var item in progeny.Children)
                {
                    i += GetDepth(item);
                }

                return i;
            }

        }


        private Dictionary<string, SortedSet<string>> TraverseDirsAndGetClassesAndParents(string path)
        {
            Dictionary<string, SortedSet<string>> classes = new();
            var files = Directory.GetFiles(path, "*.cs");
            foreach (var file in files)
            {
                string content = File.ReadAllText(file);
                ProcessMatches(classes, content);
            }

            var dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                var ssss = TraverseDirsAndGetClassesAndParents(dir);
                foreach (var item in ssss)
                {
                    if (classes.ContainsKey(item.Key))
                    {
                        var existingClass = classes.First(c => c.Key == item.Key);
                        foreach (var pr in item.Value)
                            existingClass.Value.Add(pr);
                    }
                    else
                        classes.Add(item.Key, item.Value);
                }
            }

            return classes;
        }

        private static void ProcessMatches(Dictionary<string, SortedSet<string>> classes, string content)
        {
            Regex regex = new Regex(@"\w*\s+class\s+\w+\s*:");
            MatchCollection matches = regex.Matches(content);

            foreach (Match match in matches)
            {
                var matchedValue = match.Value;
                StringBuilder sb = new();
                for (int i = match.Index + matchedValue.Length; i < content.Length; i++)
                {
                    if (content[i] == '{') break;

                    sb.Append(content[i]);
                }

                string isAbstract = "";
                if (matchedValue.Contains("abstract"))
                    isAbstract = " (abstract)";

                matchedValue = matchedValue.Split(new string[] { "class" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                matchedValue = matchedValue.Replace(":", "").Trim() + isAbstract;

                SortedSet<string> parents = new SortedSet<string>();

                var parentClassNames = sb.ToString().Trim().Split(',');
                foreach (var parCls in parentClassNames)
                {
                    parents.Add(parCls.Trim());
                }


                if (classes.ContainsKey(matchedValue))
                {
                    var existingClass = classes.First(c => c.Key == matchedValue);
                    foreach (var pr in parents)
                        existingClass.Value.Add(pr);
                }
                else
                    classes.Add(matchedValue, parents);
            }
        }


        #endregion

        private static string ToHTMLTable(ClassDef clsDef, Dictionary<string, ClassDef> allClasses, bool includeTableCaption = false)
        {
            if (!clsDef.HasComplexTypes)
                return clsDef.ToHTMLTable();

            StringBuilder sb = new StringBuilder();

            string tableCaption = string.Empty;

            if (includeTableCaption)
                tableCaption = clsDef.Name;

            sb.AppendLine(@"    <table>
        <caption><strong>" + tableCaption + @"</strong></caption>
        <tr>	<th>Property</th><th>Type</th></tr>");

            //foreach (var prop in Properties)
            //    sb.AppendLine("\t<tr><td>" + prop.AccessModifier + "</td><td>" + prop.DataType + "</td><td>" + prop.Name + "</td></tr>");
            foreach (var prop in clsDef.Properties)
            {
                sb.Append("\t<tr><td>" + prop.Name + "</td><td style=\"color: gray;\">" + prop.DataType);
                if (!Primitives.Any(x => x == prop.DataType.ToLower().Replace("[]", "")))
                {
                    var typeName = prop.DataType.Replace("[]", "")
                        .Replace("List<", "")
                        .Replace(">", "")
                        .Replace("Dictionary<", "");

                    sb.AppendLine(ToHTMLTable(allClasses[typeName], allClasses));
                }

                sb.AppendLine("\t</td></tr>");
            }

            sb.AppendLine("</table>");
            return Environment.NewLine + sb.ToString();
        }

        private class ClassDef
        {
            public ClassDef()
            {
                Properties = new List<PropertyDef>();
            }

            public string Name { get; set; }
            public string AccessModifier { get; set; } // public, protected, internal, private, protected internal, private protected
            public List<PropertyDef> Properties { get; set; }

            public bool HasComplexTypes
            {
                get
                {
                    foreach (var prop in Properties)
                        if (Primitives.Any(x => x != prop.DataType))
                            return true;

                    return false;
                }
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                foreach (var prop in Properties)
                    sb.AppendLine("\t" + prop.AccessModifier + " " + prop.DataType + " " + prop.Name);

                return Name + Environment.NewLine + sb.ToString();
            }

            public string ToHTMLTable(bool includeTableCaption = false)
            {
                StringBuilder sb = new StringBuilder();

                string tableCaption = string.Empty;

                if (includeTableCaption)
                    tableCaption = Name;

                sb.AppendLine(@"    <table>
        <caption>" + tableCaption + @"</caption>
        <tr>	<th>Property Name</th><th>Type</th></tr>");

                //foreach (var prop in Properties)
                //    sb.AppendLine("\t<tr><td>" + prop.AccessModifier + "</td><td>" + prop.DataType + "</td><td>" + prop.Name + "</td></tr>");

                foreach (var prop in Properties)
                    sb.AppendLine("\t<tr><td>" + prop.Name + "</td><td>" + prop.DataType + "</td></tr>");

                sb.AppendLine("</table>");

                return Environment.NewLine + sb.ToString();
            }
        }

        private class PropertyDef
        {
            public string Name { get; set; }
            public string DataType { get; set; } // public, internal, private 
            public string AccessModifier { get; set; }

            public PropertyDef(string accessmodifier, string datatype, string name)
            {
                Name = name.Trim();
                DataType = datatype.Trim();
                AccessModifier = accessmodifier.Trim();
            }

            public PropertyDef(string datatype, string name)
            {
                Name = name;
                DataType = datatype;
            }
        }

        private static string[] Primitives = { "byte","sbyte","int","uint","short","ushort","long","ulong","float","double","char","bool","object","string","decimal","datetime",
                                                "Byte","SByte","Int32","UInt32","Int16","UInt16","Int64","UInt64","Single","Double","Char","Boolean","Object","String","Decimal","DateTime"};

        internal string EscapeString(InputParams inParams)
        {
            return "string strValue = @\""
                + inParams.CSharpCode.Replace("\"", "\"\"")
                + "\";";
        }

        internal string EscapeStringV2(InputParams inParams)
        {
            return "string strValue = @$\""
                + inParams.CSharpCode.Replace("\"", "\"\"")
                                     .Replace("{", "{{")
                                     .Replace("}", "}}") + "\";";
        }


        #endregion
    }
}
