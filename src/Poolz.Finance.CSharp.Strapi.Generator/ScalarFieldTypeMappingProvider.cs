using GraphQlClientGenerator;

namespace Poolz.Finance.CSharp.Strapi.Generator;

public sealed class ScalarFieldTypeMappingProvider : IScalarFieldTypeMappingProvider
{
    public ScalarFieldTypeDescription GetCustomScalarFieldType(ScalarFieldTypeProviderContext context)
    {
        var unwrapped = context.FieldType.UnwrapIfNonNull();

        return unwrapped.Name switch
        {
            "DateTime" => new ScalarFieldTypeDescription
            {
                NetTypeName = GenerationContext.GetNullableNetTypeName(context, "DateTime", isReferenceType: false)
            },
            "Long" => new ScalarFieldTypeDescription
            {
                NetTypeName = GenerationContext.GetNullableNetTypeName(context, "long", isReferenceType: false)
            },
            _ => DefaultScalarFieldTypeMappingProvider.GetFallbackFieldType(context)
        };
    }
}