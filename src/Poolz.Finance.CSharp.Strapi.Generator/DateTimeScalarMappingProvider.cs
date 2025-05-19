using GraphQlClientGenerator;

namespace Poolz.Finance.CSharp.Strapi.Generator;

public sealed class DateTimeScalarMappingProvider : IScalarFieldTypeMappingProvider
{
    public ScalarFieldTypeDescription GetCustomScalarFieldType(ScalarFieldTypeProviderContext context)
    {
        var unwrapped = context.FieldType.UnwrapIfNonNull();

        return unwrapped.Name switch
        {
            "DateTime" => new ScalarFieldTypeDescription
            {
                NetTypeName = GenerationContext.GetNullableNetTypeName(context, "DateTime", isReferenceType: false),
                FormatMask = null
            },
            _ => DefaultScalarFieldTypeMappingProvider.GetFallbackFieldType(context)
        };
    }
}