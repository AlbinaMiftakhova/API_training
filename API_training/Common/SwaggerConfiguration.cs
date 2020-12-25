using Microsoft.Extensions.DependencyInjection;

namespace API_training.Common
{
    /// <summary>
    /// Расширения для конфигурации Swagger
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Настройка документов Swagger
        /// </summary>
        /// <param name="services">Коллекция сервисов для DI</param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
        //    services.AddSwaggerDocument(c =>
        //    {
        //        c.Title = "Books";
        //        c.DocumentName = DocumentPartsConst.Books;
        //        c.ApiGroupNames = new[] { DocumentPartsConst.Books };
        //        c.GenerateXmlObjects = true;
        //    });
        //    services.AddSwaggerDocument(c =>
        //    {
        //        c.Title = "Genre";
        //        c.DocumentName = DocumentPartsConst.Genre;
        //        c.ApiGroupNames = new[] { DocumentPartsConst.Genre };
        //        c.GenerateXmlObjects = true;
        //    });
        //    services.AddSwaggerDocument(c =>
        //    {
        //        c.Title = "User";
        //        c.DocumentName = DocumentPartsConst.User;
        //        c.ApiGroupNames = new[] { DocumentPartsConst.User };
        //        c.GenerateXmlObjects = true;
        //    });
        }
    }
}
