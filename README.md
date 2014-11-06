Query
=======

Queries retreive information from the Domain Model. An IQuery describes the query, an IQueryHandler handles an IQuery and returns an IQueryResult.

## Install

```
Install-Package Bocami.Practices.Query -Source https://www.myget.org/F/bocami/
```

## Usage

Query:
```csharp
public class IsUserNameAvailableQuery : IQuery
{
  public string UserName { get; set;}
}
```

Query Result:
```csharp
public class IsUserNameAvailableQueryResult : IQueryResult
{
  public bool IsUserNameAvailable { get; set;}
}
```

Query Handler:
```csharp
public class IsUserNameAvailableQueryHandler : IQueryHandler<IsUserNameAvailableQuery, IsUserNameAvailableQueryResult>
{
  private readonly IUserNameRepository userNameRepository;
  
  public IsUserNameAvailableQueryHandler(IUserNameRepository userNameRepository)
  {
    if(userNameRepository == null)
      throw new ArgumentNullException("userNameRepository");
      
    this.userNameRepository = userNameRepository;
  }
  
  public IsUserNameAvailableQueryResult Handle(IsUserNameAvailableQuery query) 
  {
    var isUserNameAvailable = userNameRepository.All(userName => userName != query.UserName);
    
    return new IsUserNameAvailableQueryResult
    {
      IsUserNameAvailable = isUserNameAvailable
    };
  }
}
```
