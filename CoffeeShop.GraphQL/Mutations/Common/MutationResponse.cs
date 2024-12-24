using HotChocolate;

namespace CoffeeShop.GraphQL.Mutations.Common;
public class MutationResponse
{
    [GraphQLDescription("Similar to HTTP status code, represents the status of the mutation.")]
    public int Code { get; set; }

    [GraphQLDescription("Indicates whether the mutation was successful.")]
    public bool Success { get; set; }

    [GraphQLDescription("Human-readable message for the UI.")]
    public string Message { get; set; }

    public MutationResponse(int code, bool success, string message)
    {
        Code = code;
        Success = success;
        Message = message;
    }
}
