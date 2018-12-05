﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace monacotest.Examples
{
    /// <summary>
    /// Interaction logic for JsonUserControl.xaml
    /// </summary>
    public partial class JsonUserControl : UserControl
    {
        public JsonUserControl()
        {
            InitializeComponent();
            var schema = new WebClient().DownloadString("https://raw.githubusercontent.com/SchemaStore/schemastore/master/src/schemas/json/tsconfig.json");
            editor.OnEditorInitialized += (o, e) =>
            {

                var schem2a = NJsonSchema.JsonSchema4.FromTypeAsync(typeof(List<DisplayTypeConfig>)).Result;
                var schemaData = schem2a.ToJson();
               
                var langs = editor.GetEditorLanguages();
                editor.SetLanguage("json");
                // editor.RegisterJsonSchema(schema);
                editor.RegisterJsonSchema(schemaData);
            };
            var vm = new ViewModel
            {
                Value = ""

                //                Value = @"{
                //  ""compilerOptions"": {

                //    ""noImplicitAny"": false,
                //    ""noEmitOnError"": true,
                //    ""removeComments"": false,

                //    ""module"": ""none"",
                //    ""moduleResolution"": ""classic"",

                //    ""target"": ""es5"",
                //    ""lib"": [ ""es6"", ""dom""],
                //    ""sourceMap"": false,

                //    ""outFile"": ""Site/Out/editor.js""
                //  },
                //  ""include"": [ ""Site/Src/**/*.ts"" ],
                //  ""exclude"": [
                //    ""node_modules"",
                //    ""wwwroot""
                //  ]
                //}
                //" 
            };

            DataContext = vm;
        }
    }

    public partial class DisplayTypeConfig
    {
        public string Device { get; set; }
        public string Type { get; set; }
        public Dictionary<string, string> Custom { get; set; }
    }
}
