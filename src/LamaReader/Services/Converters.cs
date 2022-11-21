using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using SautinSoft.Document;
using System;
using Markdig;
using Path = System.IO.Path;

namespace LamaReader.Services
{
    class Converters
    {
        private HtmlLoadOptions html_load_settings {get;} = new HtmlLoadOptions()
                {
                    PageSetup = new PageSetup()
                    {
                        Orientation = Orientation.Landscape,
                        PageMargins = new PageMargins()
                        {
                            Left = 10,
                            Right = 20
                        }
                    },
                    DefaultFontFamily = "Verdana",
                    DefaultFontSize = 10
                };

        public string doc_txt_to_pdf(string path)
        {
            // doc, docx, txt
            string output_path = Path.GetFileName(path) + ".pdf";
            DocumentCore dc = DocumentCore.Load(path);
            dc.Save(output_path);
            return output_path;
        }
        public string html_to_pdf(string path)
        {
            string output_path = Path.GetFileName(path) + ".pdf";
            DocumentCore dc = DocumentCore.Load(path, html_load_settings);
            dc.Save(output_path, new PdfSaveOptions { });
            return output_path;
        }
        public string md_to_pdf(string path)
        {
            string output_path = Path.GetFileName(path) + ".pdf";
            var text = File.ReadAllText("Input.md");
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            string html_text = Markdown.ToHtml(text, pipeline);
            using (MemoryStream msInp = new MemoryStream(Encoding.ASCII.GetBytes(html_text)))
            {
                DocumentCore dc = DocumentCore.Load(msInp, html_load_settings);
                dc.Save(output_path, new PdfSaveOptions());
            }
            return output_path;
        }
            public string to_pdf(string path)
        {
            return (new Dictionary<string, Func<string, string>> {
                {"doc", doc_txt_to_pdf },
                {"docx", doc_txt_to_pdf },
                {"txt", doc_txt_to_pdf },
                {"html", html_to_pdf },
                {"md", md_to_pdf }
            })[Path.GetExtension(path)](path);
        }
                    
    }
}
