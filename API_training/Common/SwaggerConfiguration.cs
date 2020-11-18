using Microsoft.Extensions.DependencyInjection;

namespace API_training.Common
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerDocument(c =>
            {
                c.Title = "Books";
                c.DocumentName = DocumentPartsConst.Books;
                c.ApiGroupNames = new[] { DocumentPartsConst.Books };
                c.GenerateXmlObjects = true;
            });
        }
    }
}
