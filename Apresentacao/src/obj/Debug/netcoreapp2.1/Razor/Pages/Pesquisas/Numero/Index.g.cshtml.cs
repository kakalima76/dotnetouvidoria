#pragma checksum "/home/developer/SISGO/Apresentacao/src/Pages/Pesquisas/Numero/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "573333afcae6b7b634c8ba0e849d42cf56f3cc1c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Rio.SMF.CCU.Ouvidoria.Apresentacao.Pages.Pesquisas.Numero.Pages_Pesquisas_Numero_Index), @"mvc.1.0.razor-page", @"/Pages/Pesquisas/Numero/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Pesquisas/Numero/Index.cshtml", typeof(Rio.SMF.CCU.Ouvidoria.Apresentacao.Pages.Pesquisas.Numero.Pages_Pesquisas_Numero_Index), @"{handler?}")]
namespace Rio.SMF.CCU.Ouvidoria.Apresentacao.Pages.Pesquisas.Numero
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/home/developer/SISGO/Apresentacao/src/Pages/_ViewImports.cshtml"
using Rio.SMF.CCU.Ouvidoria.Apresentacao;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{handler?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"573333afcae6b7b634c8ba0e849d42cf56f3cc1c", @"/Pages/Pesquisas/Numero/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"334db423cdaf3a25e262f00aaa0431af8103189c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Pesquisas_Numero_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_LoginPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(37, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(38, 32, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a9433283c3be4760a13c794597a32703", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(70, 1151, true);
            WriteLiteral(@"


<div class=""conteiner formulario"">
    

            <div class=""form-group"">
                <label><span class=""glyphicon glyphicon-th-large""></span>  Número</label>
            </div>

            <div class=""input-group"">
                <span class=""input-group-btn"" id=""limparCampo"">
                    <button class=""btn btn-default"" type=""button""><span class=""glyphicon glyphicon-trash"" id=""limparCampo""></span></button>
                </span>
                <input type=""text"" class=""form-control"" placeholder=""Informe o número do chamado"" id=""queryNumero"">
            </div>

            <div>
                
            </div>


            <div class=""formulario"">
                <div class=""row"">
                <div class=""col-sm-4""></div>
                <div class=""col-sm-4"">
                    <button type=""botton"" id=""pesquisarNumero"" class=""btn btn-primary btn-lg btn-block""><span class=""glyphicon  glyphicon-check""></span></button>
                </div>
                <div class=""col-sm-");
            WriteLiteral("4\"></div>\n                </div>\n            </div>\n            \n            <div id=\"queryNumeroEncontrado\"></div>\n\n</div>\n\n \n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1241, 1, true);
                WriteLiteral("\n");
                EndContext();
#line 42 "/home/developer/SISGO/Apresentacao/src/Pages/Pesquisas/Numero/Index.cshtml"
       await Html.RenderPartialAsync("_ValidationScriptsPartial"); 

#line default
#line hidden
                BeginContext(1311, 2, true);
                WriteLiteral("  ");
                EndContext();
            }
            );
            BeginContext(1315, 2, true);
            WriteLiteral("\n\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
