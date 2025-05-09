using GraphQlClientGenerator;
using EnvironmentManager.Extensions;
using Poolz.Finance.CSharp.Strapi.Generator;

var url = Env.GRAPHQL_STRAPI_URL.GetRequired();
var schema = await GraphQlGenerator.RetrieveSchema(HttpMethod.Post, url);
var configuration = new GraphQlGeneratorConfiguration
{
    TargetNamespace = Env.TARGET_NAMESPACE.GetRequired(),
    IdTypeMapping = IdTypeMapping.String
};
var generator = new GraphQlGenerator(configuration);
var csharpCode = generator.GenerateFullClientCSharpFile(schema);
await File.WriteAllTextAsync(Env.GENERATED_FILE_PATH.GetRequired(), csharpCode);